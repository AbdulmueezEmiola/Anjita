using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Assignment_2.Models
{
    public class EFAnjitaRepository : IAnjitaRepository
    {
        private QuestionDbContext context;
        public EFAnjitaRepository(QuestionDbContext ctx)
        {
            context = ctx;
        }
        public bool CanAdd
        {
            get
            {
                return context.Questions.Count() < 10;
            }
        }
        public IQueryable<SampleQuestion> Questions => context.Questions;

        public void DeleteQuestion(SampleQuestion question)
        {
            context.Remove(question);
            context.SaveChanges();
        }       
        public void DeleteQuestion(int id)
        {
            SampleQuestion question = FindQuestion(id);
            DeleteQuestion(question);
        }
        public SampleQuestion FindQuestion(int id)
        {
            return (SampleQuestion)context.Questions.Where(b => b.QuestionId == id).First();
        }
        public void SaveQuestion(SampleQuestion question)
        {
            if(question.QuestionId == 0)
            {
                context.Questions.Add(question);
            }
            else
            {
                context.Update(question);
            }
            context.SaveChanges();
        }
    }
}
