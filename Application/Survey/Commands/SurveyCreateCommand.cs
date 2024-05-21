using Application.Interfaces;
using Domain.Models;
using MediatR;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace Application.Survey.Commands
{
    public class SurveyCreateCommand : IRequest<Domain.Models.Survey>
    {
        public SurveyCreateCommand(string question, string createdBy, List<Option> options, Settings settings)
        {
            Question = question;
            CreatedBy = createdBy;
            Options = options;
            Settings = settings;
        }
        public string Question { get; private set; }
        public string CreatedBy { get; private set; }
        public List<Option> Options { get; set; }
        public Settings Settings { get; set; }

        public class Handler : IRequestHandler<SurveyCreateCommand, Domain.Models.Survey>
        {
            private readonly ISurveyAppDbContext _surveyAppDbContext;

            public Handler(ISurveyAppDbContext surveyAppDbContext)
            {
                _surveyAppDbContext = surveyAppDbContext;
            }

            public async Task<Domain.Models.Survey> Handle(SurveyCreateCommand request, CancellationToken cancellationToken)
            {

                var survey = Domain.Models.Survey.Create(request.Question, request.CreatedBy, request.Settings, request.Options);
                _surveyAppDbContext.Surveys.Add(survey);
                await _surveyAppDbContext.SaveChangesAsync(cancellationToken);

                return survey;
            }
        }
    }
}
