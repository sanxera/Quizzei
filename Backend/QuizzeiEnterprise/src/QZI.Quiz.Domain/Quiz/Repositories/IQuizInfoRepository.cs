using System.Threading.Tasks;
using QZI.Quiz.Domain.Quiz.Entities;

namespace QZI.Quiz.Domain.Quiz.Repositories
{
    public interface IQuizInfoRepository
    {
        Task AddNewQuizInfo(QuizInfo quizInfo);
    }
}
