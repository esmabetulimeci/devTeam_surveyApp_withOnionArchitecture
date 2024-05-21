using Domain.Models;
using WebApi.Models.Request.Create;

namespace WebApi.Models.Request.Update
{
    public class SurveyUpdateRequest 
    {
        public int surveyId { get; set; }
        public string Question { get; set; }
        public string CreatedBy { get; set; }
        public List<OptionCreateRequest> Options { get; set; }
        public Settings Settings { get; set; }
    }
}

