using System.Threading;
using System.Threading.Tasks;
using MediatR;
using QZI.Quiz.Domain.Quiz.Entities;
using QZI.Quiz.Domain.Quiz.Handlers.Commands;
using QZI.Quiz.Domain.Quiz.Handlers.Response;
using QZI.Quiz.Domain.Quiz.Repositories;

namespace QZI.Quiz.Domain.Quiz.Handlers
{
    public class QuizInfoCommandHandler : IRequestHandler<CreateQuizInfoCommand, CreateQuizInfoResponse>
    {
        private readonly IQuizInfoRepository _quizInfoRepository;
        private readonly ICategoryRepository _quizCategoryRepository;

        public QuizInfoCommandHandler(IQuizInfoRepository quizInfoRepository, ICategoryRepository quizCategoryRepository)
        {
            _quizInfoRepository = quizInfoRepository;
            _quizCategoryRepository = quizCategoryRepository;
        }

        public async Task<CreateQuizInfoResponse> Handle(CreateQuizInfoCommand command, CancellationToken cancellationToken)
        {
            var category = await _quizCategoryRepository.GetCategoryById(command.Request.CategoryId);

            if (category == null)
                return new CreateQuizInfoResponse { Created = false };

            var quizInfo = QuizInfo.CreateQuizInfo(command.Request.Title, command.Request.Description, command.Request.Points, category);
            await _quizInfoRepository.AddNewQuizInfo(quizInfo);

            return new CreateQuizInfoResponse { Created = true };
        }
    }
}
