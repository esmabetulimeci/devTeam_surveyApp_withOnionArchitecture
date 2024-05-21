using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic.FileIO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface ISurveyAppDbContext
    {
        DbSet<Domain.Models.Survey> Surveys { get; set; }
        DbSet<Domain.Models.Option> Options { get; set; }
        DbSet<Domain.Models.Vote> Votes { get; set; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken());
    }
}
