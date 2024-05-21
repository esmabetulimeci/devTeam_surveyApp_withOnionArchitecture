using Application.Vote.Commands;

namespace WebApi.Models.Request.Create
{
    public class VoteCreateRequest
    {
        public int SurveyId { get; set; }

        public string UsedBy { get; set; }

        public List<int> OptionIdList { get; set; }

        public UseVoteCommand ToCommand(int surveyId)
        {
            return new UseVoteCommand(surveyId, UsedBy, OptionIdList);
        }
    }
}
