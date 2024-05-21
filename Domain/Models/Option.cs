using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class Option : BaseModel
    {
        public string Type { get; set; }
        public string Description { get; set; }
        public int Order { get; set; }

        public virtual Survey Survey { get; set; }
        public virtual List<Vote> Votes { get; set; }

        public static Option Create(string type, string description, int order)
        {
            return new Option
            {
                Type = type,
                Description = description,
                Order = order
            };
        }

        public void Update(string type, string description, int order)
        {
            Type = type;
            Description = description;
            Order = order;
        }

     

    }


}
