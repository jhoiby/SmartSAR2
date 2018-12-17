using System;
using System.Collections.Generic;
using System.Text;
using MediatR;
using SmartSAR.BC.Membership.Domain.Aggregates;

namespace Contexts.Membership.Application.Queries.Persons
{
    public class GetAllPersonsQuery : IRequest<List<PersonDto>>
    {
    }
}
