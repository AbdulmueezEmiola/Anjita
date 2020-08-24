using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Assignment_3.Models
{
    public class AnjitaDbContext:DbContext
    {
        public AnjitaDbContext(DbContextOptions<AnjitaDbContext> options) : base(options)
        {

        }
        public DbSet<EmailModel> Emails { get; set; }
        public DbSet<SampleQuestion> Questions { get; set; }
        public DbSet<UserAnswer> UserAnswers { get; set; }
        
    }
}
