using System;
using System.Threading.Tasks;
using QZI.Quiz.Domain.Quiz.Entities;
using QZI.Quiz.Domain.Quiz.Repositories;

namespace QZI.Quiz.Infra.Data.Repository
{
    public class QuizInfoRepository : IQuizInfoRepository
    {
        private readonly QuizContext _context;

        public QuizInfoRepository(QuizContext context)
        {
            _context = context;
        }

        public async Task AddNewQuizInfo(QuizInfo quizInfo)
        {
            await _context.AddAsync(quizInfo);
            await _context.SaveChangesAsync();
        }
    }
}
