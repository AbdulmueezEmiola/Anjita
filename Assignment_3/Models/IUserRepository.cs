using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Assignment_3.Models
{
    public interface IUserRepository
    {
        IQueryable<EmailModel> Emails { get; }
        void SaveEmail(EmailModel email);
        IQueryable<SampleQuestion> Questions { get; }
        SampleQuestion FindQuestion(int Id);
        int QuestionCount { get; }
        IQueryable<UserAnswer> Answers { get; }
        void SaveAnswer(UserAnswer answer);
        UserAnswer FindAnswer(int QuestionId, string email);        
    }
}
