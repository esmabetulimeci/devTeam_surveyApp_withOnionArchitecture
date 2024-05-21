using Application.Interfaces;
using Application.Survey.Queries;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Option.Queries
{
    public class GetOptionByIdQuery : IRequest<IEnumerable<Domain.Models.Option>>
    {

        public GetOptionByIdQuery(int surveyId)
        {
            SurveyId = surveyId;
        }

        public int SurveyId { get; set; }
        public class Handler : IRequestHandler<GetOptionByIdQuery, IEnumerable<Domain.Models.Option>>
        {
            private readonly ISurveyAppDbContext _surveyAppDbContext;

            public Handler(ISurveyAppDbContext surveyAppDbContext)
            {
                _surveyAppDbContext = surveyAppDbContext;
            }

        
            public Task<IEnumerable<Domain.Models.Option>> Handle(GetOptionByIdQuery request, CancellationToken cancellationToken)
            {
                var dbQuery = _surveyAppDbContext.Options.AsQueryable();

                if (request.SurveyId > 0)
                {
                    dbQuery = dbQuery.Where(x => x.Id == request.SurveyId);
                }

               
                var options = dbQuery.ToList();
                return Task.FromResult(options.AsEnumerable());


            }
        }
}
}

