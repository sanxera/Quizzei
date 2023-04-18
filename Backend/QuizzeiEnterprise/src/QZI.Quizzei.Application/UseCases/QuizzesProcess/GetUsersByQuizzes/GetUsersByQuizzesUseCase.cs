using QZI.Quizzei.Application.UseCases.QuizzesProcess.GetUsersByQuizzes.Interfaces;
using QZI.Quizzei.Application.Shared.Enums;
using QZI.Quizzei.Application.Shared.Repositories;
using QZI.Quizzei.Application.Shared.Services.Users.Interfaces;
using QZI.Quizzei.Application.UseCases.QuizzesProcess.GetUsersByQuizzes.Models.Request;
using QZI.Quizzei.Application.UseCases.QuizzesProcess.GetUsersByQuizzes.Models.Response;

namespace QZI.Quizzei.Application.UseCases.QuizzesProcess.GetUsersByQuizzes
{
    public class GetUsersByQuizzesUseCase : IGetUsersByQuizzesUseCase
    {
        private readonly IQuizProcessRepository _quizProcessRepository;
        private readonly IUserService _userService;

        public GetUsersByQuizzesUseCase(IQuizProcessRepository quizProcessRepository, IUserService userService)
        {
            _quizProcessRepository = quizProcessRepository;
            _userService = userService;
        }

        public async Task<GetUsersByQuizzesResponse> ExecuteAsync(GetUsersByQuizzesRequest request)
        {
            var completedQuizzes = await _quizProcessRepository.GetQuizProcessByQuiz(request.QuizInfoUuid);

            var usersListResponse = new List<UserResponse>();
            foreach (var quizProcess in completedQuizzes)
            {
                var user = await _userService.GetUserAsync(quizProcess.UserUuid);

                var existsInList = usersListResponse.Any(x => x.UserUuid == user.UserUuid);
                if (!existsInList)
                    usersListResponse.Add(UserResponse.Create(user.UserUuid, user.NickName));

                var quizProcessResponse = QuizProcessResponse.Create(quizProcess.QuizProcessUuid, quizProcess.CreatedAt, quizProcess.Status);
                usersListResponse.FirstOrDefault(x => x.UserUuid == user.UserUuid)?.QuizzesProcess.Add(quizProcessResponse);
            }

            return GetUsersByQuizzesResponse.Create(usersListResponse);
        }
    }
}
