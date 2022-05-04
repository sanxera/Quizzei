namespace QZI.Quiz.Domain.Quiz.Handlers.Requests.Quiz
{
    public class CreateQuizInfoRequest
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public int Points { get; set; }
        public int CategoryId { get; set; }
    }
}
