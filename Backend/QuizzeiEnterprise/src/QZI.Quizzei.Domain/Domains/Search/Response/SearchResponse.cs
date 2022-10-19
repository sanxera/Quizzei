using System;

namespace QZI.Quizzei.Domain.Domains.Search.Response
{
    public class SearchResponse
    {
        public Guid Uuid { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }

        public SearchResponse(Guid uuid, string name, string type)
        {
            Uuid = uuid;
            Name = name;
            Type = type;
        }
    }
}
