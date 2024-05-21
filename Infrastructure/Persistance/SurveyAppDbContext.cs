using Application.Interfaces;
using Domain.Models;
using Infrastructure.Persistance.Configuration;
using Microsoft.EntityFrameworkCore;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Persistance
{
    public class SurveyAppDbContext : DbContext, ISurveyAppDbContext
    {
        public DbSet<Survey> Surveys { get; set; }
        public DbSet<Option> Options { get; set; }
        public DbSet<Vote> Votes { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var connectionString =
                "Server=localhost;Port=5432;Database=surveyDb;Userid=postgres;Password=123123;Include Error Detail=True;";
            base.OnConfiguring(optionsBuilder);
            var builder = new NpgsqlDataSourceBuilder(connectionString);
            builder.EnableDynamicJson();
            var dataSource = builder.Build();
            optionsBuilder.UseNpgsql(dataSource);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(SurveyConfiguration).Assembly);
            base.OnModelCreating(modelBuilder);
        }
    }
}
