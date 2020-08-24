using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Assignment_2.Models
{
    public class QuestionDbContext:DbContext
    {
        public QuestionDbContext(DbContextOptions<QuestionDbContext> options):base(options)
        {

        }
        public DbSet<SampleQuestion> Questions { get; set; }
    }
}
