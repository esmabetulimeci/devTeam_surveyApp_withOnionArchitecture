using Application.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Survey.Commands
{
    public class SurveyDeleteCommand : IRequest<int>
    {
        public SurveyDeleteCommand(int id)
        {
            Id = id;
        }

        public int Id { get; set; }

        public class Handler : IRequestHandler<SurveyDeleteCommand, int> 
        {
            private readonly ISurveyAppDbContext _surveyAppDbContext;

            public Handler(ISurveyAppDbContext surveyAppDbContext)
            {
                _surveyAppDbContext = surveyAppDbContext;
            }

            public async Task<int> Handle(SurveyDeleteCommand command, CancellationToken cancellationToken)
            {
                var survey = await _surveyAppDbContext.Surveys.Where(x => x.Id == command.Id).FirstOrDefaultAsync();
                if (survey == null)
                {
                    return default;
                }

                _surveyAppDbContext.Surveys.Remove(survey);
                await _surveyAppDbContext.SaveChangesAsync(cancellationToken);
                return survey.Id;
            }
        }
    }
}
