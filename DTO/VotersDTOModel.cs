using Newtonsoft.Json;

namespace Assiment4.CrudApi.DTO
{
    public class VotersDTOModel
    {
        [JsonProperty(PropertyName = "voteId", NullValueHandling = NullValueHandling.Ignore)]
        public string VoterId { get; set; }

        [JsonProperty(PropertyName = "voterName", NullValueHandling = NullValueHandling.Ignore)]
        public string VoterName { get; set; }

        [JsonProperty(PropertyName = "voteParty", NullValueHandling = NullValueHandling.Ignore)]
        public string VoteParty { get; set; }
    }
}
