using Application.Interfaces;
using Domain.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Survey.Commands
{
    public class SurveyUpdateCommand : IRequest<Domain.Models.Survey>
    {
        public SurveyUpdateCommand(int id, string question, string createdBy, List<Option> options, Settings settings)
        {
            Id = id;
            Question = question;
            CreatedBy = createdBy;
            Options = options;
            Settings = settings;
        }
        public int Id { get; private set; } // Güncellenecek anketin kimliği
        public string Question { get; private set; }
        public string CreatedBy { get; private set; }
        public List<Option> Options { get; private set; }
        public Settings Settings { get; private set; }

        public class Handler : IRequestHandler<SurveyUpdateCommand, Domain.Models.Survey>
        {
            private readonly ISurveyAppDbContext _surveyAppDbContext;

            public Handler(ISurveyAppDbContext surveyAppDbContext)
            {
                _surveyAppDbContext = surveyAppDbContext;
            }

            public async Task<Domain.Models.Survey> Handle(SurveyUpdateCommand request, CancellationToken cancellationToken)
            {
                var surveyToUpdate = await _surveyAppDbContext.Surveys.Include(x => x.Options).FirstOrDefaultAsync(x => x.Id == request.Id);
                if (surveyToUpdate == null)
                {
                    throw new Exception("Survey is not found");
                }

                surveyToUpdate.Update(request.Question, request.CreatedBy, request.Settings, request.Options);
                await _surveyAppDbContext.SaveChangesAsync(cancellationToken);
                return surveyToUpdate;





            }
        }
    }
}

