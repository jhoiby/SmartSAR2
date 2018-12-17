using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Contexts.Membership.Data;
using MediatR;
using Microsoft.EntityFrameworkCore;
using SmartSAR.BC.Membership.Domain.Aggregates;

namespace Contexts.Membership.Application.Queries.Persons
{
    public class GetAllPersonsQueryHandler : IRequestHandler<GetAllPersonsQuery, List<PersonDto>>
    {
        private MembershipDbContext _membershipDb;

        public GetAllPersonsQueryHandler(MembershipDbContext membershipDb)
        {
            _membershipDb = membershipDb;
        }

        public async Task<List<PersonDto>> Handle(GetAllPersonsQuery request, CancellationToken cancellationToken)
        {
            
            var personsList = await _membershipDb.Persons.ToListAsync();

            // TODO: Refactor this with AutoMapper

            List<PersonDto> personDtoList = new List<PersonDto>();
            
            foreach(Person person in personsList)
            {
                personDtoList.Add(new PersonDto
                {
                    Id = person.Id,
                    FirstName = person.FirstName,
                    LastName = person.LastName
                });
            }

            return personDtoList;
        }
    }
}
