using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Contexts.Membership.Application.Queries.Persons;
using Dapper;
using Microsoft.AspNetCore.Razor.Language.Intermediate;
using Microsoft.Extensions.Configuration;

// Temporary dependency
using Presentation.WebUI.Areas.Membership.Pages.Persons;

namespace Presentation.WebUI.Services
{
    public class DbQueryService

    {
    private IConfiguration _configuration;

    public DbQueryService(IConfiguration configuration)
    {
        _configuration = configuration;
    }

        public IndexModel.Result Query(string sqlQuery)
        {
            var result = new IndexModel.Result();

            using (var connection = new SqlConnection(_configuration.GetConnectionString("MembershipDbConnection")))
            {
                result.Persons = connection.Query<IndexModel.Result.Person>(sqlQuery).ToList();
            }

            return result;
        }
    }
}
