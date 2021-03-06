using Dapper;
using products_api.Data.Repository;
using products_api.Dtos;
using products_api.Models;

namespace products_api.Data.SQLServerRepository
{
    public class SqlServerAvailabilityRepository : 
        SqlServerRepository<Availability>, IAvailabilityRepository
    {
        public SqlServerAvailabilityRepository(AppDbContext db, IConfiguration configuration)
            : base(db, configuration)
        {
            
        }

        public async Task<AvailabilitySearchResult> SearchAvailability(
            string? q,
            int? page,
            int? pageSize,
            string? sortBy,
            string? sortDirection)
        {
            // Get connection
            using var connection = SqlConnection;

            // Results query
            string sqlResults = @"SELECT * ";

            // Count query
            string sqlCount = "SELECT COUNT(*) ";

            // Tables and conditions
            string sqlTableAndConditions = @"
FROM Availability
WHERE 1=1
";

            // Create parameters
            DynamicParameters parameters = new DynamicParameters();
            // Search
            if (string.IsNullOrEmpty(q) == false)
            {
                sqlTableAndConditions += @" AND (
Name LIKE '%' + @q + '%' 
) ";
                parameters.AddDynamicParams(new { q = q });
            }

            // Add table/conditions in result and count sql
            sqlResults += sqlTableAndConditions;
            sqlCount += sqlTableAndConditions;

            // Add sort direction
            sortDirection = string.IsNullOrEmpty(sortDirection) ? "ASC" : sortDirection;
            sortDirection = sortDirection.Equals("DESC", StringComparison.OrdinalIgnoreCase)
                ? "DESC " : "ASC";

            // Add sorting in sql results
            sqlResults += @$" ORDER BY 
CASE WHEN @SortBy = 'Name' THEN Name  END {sortDirection},
CASE WHEN @SortBy = 'Position' THEN Position  END {sortDirection}
";
            
            // Add paging in sql results
            sqlResults += @" OFFSET @Offset ROWS
FETCH NEXT @PageSize ROWS ONLY ;
";

            // Add paging and sorting params
            parameters.AddDynamicParams(new { Offset = (page - 1) * pageSize, PageSize = pageSize });
            parameters.AddDynamicParams(new { SortBy = sortBy });

            // Execute query
            var multi = await connection.QueryMultipleAsync(
                sqlResults + sqlCount, parameters);

            // Prepare results
            AvailabilitySearchResult result = new();
            result.Availabilities = multi.Read<AvailabilityDto>().ToList();
            result.TotalResults = multi.ReadFirst<int>();

            return result;
        }
    }
}
