using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QZI.Quizzei.Domain.Abstractions;

namespace QZI.Quizzei.Domain.Domains.Quiz.Entities
{
    public class QuizRate : Entity
    {
        public Guid QuizProcessUuid { get; set; }
        public Guid QuizInformationUuid { get; set; }
        public int Rate { get; set; }

        public static QuizRate CreateQuizRate(Guid quizProcessUuid, Guid quizInfoUuid, int rate)
        {
            return new QuizRate
            {
                CreatedAt = DateTime.Now,
                QuizProcessUuid = quizProcessUuid,
                QuizInformationUuid = quizInfoUuid,
                Rate = rate,
                CreatedBy = "Admin"
            };
        }
    }
}
