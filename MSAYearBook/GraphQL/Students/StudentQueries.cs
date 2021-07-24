using HotChocolate;
using HotChocolate.Types;
using MSAYearBook.Data;
using MSAYearBook.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MSAYearBook.GraphQL.Students
{
    [ExtendObjectType(name: "Query")]
    public class StudentQueries
    {
        public IQueryable<Student> GetStudents([ScopedService] AppDbContext context)
        {
            return context.Students;
        }
    }
}
