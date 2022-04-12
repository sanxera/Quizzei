using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QZI.Quiz.Domain.Quiz.Handlers.Requests
{
    public class CreateQuizInfoRequest
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public int Points { get; set; }
        public int CategoryId { get; set; }
        public int Active { get; set; }
        public DateTime CreatedAt { get; set; }
        public string CreatedBy { get; set; }
    }
}
