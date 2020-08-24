using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Assignment_2.Models
{
    public interface IAnjitaRepository
    {
        IQueryable<SampleQuestion> Questions { get; }
        void SaveQuestion(SampleQuestion question);
        void DeleteQuestion(SampleQuestion question);
        void DeleteQuestion(int id);
        SampleQuestion FindQuestion(int id);
        bool CanAdd { get; }
    }
}
