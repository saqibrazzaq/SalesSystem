using Dapper;
using products_api.Data.Repository;
using products_api.Dtos;
using products_api.Models;

namespace products_api.Data.SQLServerRepository
{
    public class SqlServerCategoryRepository : SqlServerRepository<Category>, ICategoryRepository
    {
        public SqlServerCategoryRepository(AppDbContext db, IConfiguration configuration)
            : base(db, configuration)
        {
            
        }

        public async Task<CategorySearchResult> SearchCategories(
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
FROM Category
WHERE 1=1
";

            // Create parameters
            DynamicParameters parameters = new DynamicParameters();
            // Search
            if (string.IsNullOrEmpty(q) == false)
            {
                sqlTableAndConditions += @" AND (
Name LIKE '%' + @q + '%' OR
Description LIKE '%' + @q + '%'
) ";
                parameters.AddDynamicParams(new { q = q });
            }

            // Add table/conditions in result and count sql
            sqlResults += sqlTableAndConditions;
            sqlCount += sqlTableAndConditions;

            // Add sorting in sql results
            sqlResults += @" ORDER BY 
CASE @SortBy
    WHEN 'Name' THEN Name
    ELSE Position
END
";
            // Add sort direction
            sortDirection = string.IsNullOrEmpty(sortDirection) ? "DSC" : sortDirection;
            sqlResults += sortDirection.Equals("DSC", StringComparison.OrdinalIgnoreCase)
                ? "DSC " : "ASC";

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
            CategorySearchResult result = new();
            result.Categories = multi.Read<CategoryDto>().ToList();
            result.TotalResults = multi.ReadFirst<int>();

            return result;
        }
    }
}
