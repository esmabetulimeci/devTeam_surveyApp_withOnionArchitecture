using Application.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Survey.Queries
{
    public class GetSurveyQuery : IRequest<IEnumerable<Domain.Models.Survey>>
    {
        public class Handler : IRequestHandler<GetSurveyQuery, IEnumerable<Domain.Models.Survey>>
        {
            private readonly ISurveyAppDbContext _surveyAppDbContext;

            public Handler(ISurveyAppDbContext surveyAppDbContext)
            {
                _surveyAppDbContext = surveyAppDbContext;
            }

            public async Task<IEnumerable<Domain.Models.Survey>> Handle(GetSurveyQuery request, CancellationToken cancellationToken)
            {
                var surveys = await _surveyAppDbContext.Surveys.ToListAsync();
                if (surveys == null)
                {
                    return null;
                }
                return surveys.AsReadOnly();
            }
        }
    }
}
