using System.Collections.Generic;

namespace QZI.Quizzei.Domain.Domains.Files.Responses
{
    public class GetOcrQuestionsWithOptionsByQuizResponse
    {
        public IList<OcrQuestionResponse> Questions { get; set; } = new List<OcrQuestionResponse>();
    }

    public class OcrQuestionResponse
    {
        public string QuestionDescription { get; set; }
        public IList<OcrQuestionOptionResponse> Options { get; set; } = new List<OcrQuestionOptionResponse>();

        public OcrQuestionResponse(string questionDescription)
        {
            QuestionDescription = questionDescription;
        }
    }

    public class OcrQuestionOptionResponse
    {
        public string OptionDescription { get; set; }

        public OcrQuestionOptionResponse(string optionDescription)
        {
            OptionDescription = optionDescription;
        }
    }
}
