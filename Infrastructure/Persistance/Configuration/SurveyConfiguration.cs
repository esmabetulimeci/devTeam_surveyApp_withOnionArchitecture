using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Persistance.Configuration
{
    public class SurveyConfiguration : IEntityTypeConfiguration<Survey>
    {
        public void Configure(EntityTypeBuilder<Survey> builder)
        {
            builder.ToTable("survey");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).HasColumnName("id").HasColumnType("int");
            builder.Property(x => x.Question).HasColumnName("question").HasColumnType("text");
            builder.Property(x => x.CreatedDate).HasColumnName("created_date").HasColumnType("date");
            builder.Property(x => x.CreatedBy).HasColumnName("created_by").HasColumnType("varchar(50)");
            builder.Property(x => x.DueDate).HasColumnName("due_date").HasColumnType("date");
            builder.Property(x => x.Settings).HasColumnName("settings").HasColumnType("jsonb");


            builder.HasMany(x => x.Options).WithOne(x => x.Survey);
        }
    }
}
