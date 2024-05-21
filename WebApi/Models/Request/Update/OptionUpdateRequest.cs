namespace WebApi.Models.Request.Update
{
    public class OptionUpdateRequest
    {
        public string Type { get; set; }
        public string Description { get; set; }
        public int Order { get; set; }
        public OptionUpdateRequest() { }
        public OptionUpdateRequest(string type, string description, int order)
        {
            Type = type;
            Description = description;
            Order = order;
        }

    }
}
