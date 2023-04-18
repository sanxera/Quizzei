using QZI.Quizzei.Application.Shared.Enums;

namespace QZI.Quizzei.Application.UseCases.QuizzesProcess.GetUsersByQuizzes.Models.Response;

public class GetUsersByQuizzesResponse
{
    private GetUsersByQuizzesResponse(List<UserResponse> users)
    {
        Users = users;
    }

    public List<UserResponse> Users { get; set; }

    public static GetUsersByQuizzesResponse Create(List<UserResponse> users) => new(users);
}

public class UserResponse
{
    private UserResponse(Guid userUuid, string? name)
    {
        UserUuid = userUuid;
        Name = name;
    }

    public Guid UserUuid { get; set; }
    public string? Name { get; set; }
    public List<QuizProcessResponse> QuizzesProcess { get; set; } = new();

    public static UserResponse Create(Guid userUuid, string? name) => new(userUuid, name);
}

public class QuizProcessResponse
{
    private QuizProcessResponse(Guid quizProcessUuid, DateTime startedDate, QuizProcessStatus status)
    {
        QuizProcessUuid = quizProcessUuid;
        StartedDate = startedDate;
        Status = status;
    }

    public Guid QuizProcessUuid { get; set; }
    public DateTime StartedDate { get; set; }
    public QuizProcessStatus Status { get; set; }

    public static QuizProcessResponse Create(Guid quizProcessUuid, DateTime startedDate, QuizProcessStatus status) 
        => new(quizProcessUuid, startedDate, status);
}