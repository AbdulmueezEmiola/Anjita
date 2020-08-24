using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Assignment_3.Models
{
    public class UserRepository:IUserRepository
    {
        private AnjitaDbContext context;
        public UserRepository(AnjitaDbContext ctx)
        {
            context = ctx;
        }
        public IQueryable<EmailModel> Emails => context.Emails;
        public void SaveEmail(EmailModel email)
        {
            if (email.EmailId==0)
            {
                context.Emails.Add(email);
            }
            context.SaveChanges();  
        }
        public SampleQuestion FindQuestion(int pos)
        {
            return context.Questions.ToList().ElementAt(pos);
        }

        public void SaveAnswer(UserAnswer answer)
        {
            UserAnswer possibleAnswer = FindAnswer(answer.QuestionId, answer.EmailAddress);
            if (possibleAnswer==default)
            {
                context.UserAnswers.Add(answer);                
            }
            else
            {
                possibleAnswer.Answer = answer.Answer;
                context.Update(possibleAnswer);
            }
            context.SaveChanges();
        }

        public UserAnswer FindAnswer(int QuestionId, string email)
        {
            return context.UserAnswers.FirstOrDefault(e => e.EmailAddress == email && e.QuestionId == QuestionId);
        }

        public IQueryable<SampleQuestion> Questions => context.Questions;

        public int QuestionCount => context.Questions.Count();

        public IQueryable<UserAnswer> Answers => context.UserAnswers;

    }
}
