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

        public List<T> ListQuery<T>(string sqlQuery)
        {
            List<T> result;

            using (var connection = new SqlConnection(_configuration.GetConnectionString("MembershipDbConnection")))
            {
                result = connection.Query<T>(sqlQuery).ToList();
            }

            return result;
        }
    }
}
