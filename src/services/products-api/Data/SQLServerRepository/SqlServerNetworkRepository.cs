using Dapper;
using Microsoft.EntityFrameworkCore;
using products_api.Data.Repository;
using products_api.Dtos;
using products_api.Models;

namespace products_api.Data.SQLServerRepository
{
    public class SqlServerNetworkRepository : SqlServerRepository<Network>, INetworkRepository
    {
        public SqlServerNetworkRepository(AppDbContext db, IConfiguration configuration)
            : base(db, configuration)
        {
            
        }

        public async Task<Network?> GetNetworkWithAllDetails(string name)
        {
            var query = GetAll(
                filter: x => x.Name == name,
                include: i => i.Include(x => x.NetworkDetails)
                ).FirstOrDefault();
            if (query == null) return null;

            return await Task.FromResult(query);
        }

        public async Task<NetworkSearchResult> SearchNetworks(
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
FROM Network
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
            NetworkSearchResult result = new();
            result.Networks = multi.Read<NetworkDto>().ToList();
            result.TotalResults = multi.ReadFirst<int>();

            return result;
        }
    }
}
