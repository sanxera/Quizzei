using System.Collections.Generic;

namespace QZI.Core.Communication
{
    public class ResponseResult
    {
        public int StatusCode { get; set; }

        public List<ResponseErrorMessages> Errors { get; set; } = new List<ResponseErrorMessages>();
    }
}
