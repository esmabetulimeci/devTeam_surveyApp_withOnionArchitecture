using Application.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Option.Commands
{
    public class OptionUpdateCommand: IRequest<Domain.Models.Option>
    {
        
        public OptionUpdateCommand(int surveyId, int optionId, string type, string description, int order)
        {
            SurveyId = surveyId;
            OptionId = optionId;
            Type = type;
            Description = description;
            Order = order;
        }

        public int SurveyId { get; set; }
        public int OptionId { get; set; }
        public string Type { get; set; }
        public string Description { get; set; }
        public int Order { get; set; }

        public class Handler : IRequestHandler<OptionUpdateCommand, Domain.Models.Option>
        {
            private readonly ISurveyAppDbContext _surveyAppDbContext;

            public Handler(ISurveyAppDbContext surveyAppDbContext)
            {
                _surveyAppDbContext = surveyAppDbContext;
            }

            public async Task<Domain.Models.Option> Handle(OptionUpdateCommand request, CancellationToken cancellationToken)
            {
                var option = await _surveyAppDbContext.Options
                    .Where(x => x.Id == request.OptionId && x.Survey.Id == request.SurveyId)
                    .FirstOrDefaultAsync(cancellationToken);

                if (option == null)
                {
                    return default;
                }

                option.Update(request.Type, request.Description, request.Order);
                await _surveyAppDbContext.SaveChangesAsync(cancellationToken);
                return option;

            }
        }


    }
}
