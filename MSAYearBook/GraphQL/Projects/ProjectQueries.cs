using System.Linq;
using HotChocolate;
using HotChocolate.Types;
using MSAYearBook.Data;
using MSAYearBook.Models;
using MSAYearBook.Extensions;

namespace MSAYearBook.GraphQL.Projects
{
    [ExtendObjectType(name: "Query")]
    public class ProjectQueries
    {
        [UseAppDbContext]
        [UsePaging]
        public IQueryable<Project> GetProjects([ScopedService] AppDbContext context)
        {
            return context.Projects.OrderBy(p => p.Created);
        }

        [UseAppDbContext]
        public Project GetProject(int id, [ScopedService] AppDbContext context)
        {
            return context.Projects.Find(id);
        }
    }
}
