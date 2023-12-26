using Newtonsoft.Json;
using System.Text.Json.Serialization;

namespace Assiment4.CrudApi.Entity
{
    public class Voter
    {
        [JsonProperty(PropertyName = "id")]
         public string Id { get; set; }

        [JsonProperty(PropertyName = "uId", NullValueHandling = NullValueHandling.Ignore)]
        public string UId { get; set; }

        [JsonProperty(PropertyName = "dVoter", NullValueHandling = NullValueHandling.Ignore)]
        public string DocumentType { get; set; }

        [JsonProperty(PropertyName = "createdBy", NullValueHandling = NullValueHandling.Ignore)]
        public string CreatedBy { get; set; }

        [JsonProperty(PropertyName = "createdByName", NullValueHandling = NullValueHandling.Ignore)]
        public string CreatedByName { get; set; }

        [JsonProperty(PropertyName = "createdOn", NullValueHandling = NullValueHandling.Ignore)]
        public DateTime CreatedOn { get; set; }

        [JsonProperty(PropertyName = "updatedBy", NullValueHandling = NullValueHandling.Ignore)]
        public string UpdateBy { get; set; }

        [JsonProperty(PropertyName = "updatedByName", NullValueHandling = NullValueHandling.Ignore)]
        public string UpdatedByName { get; set; }

        [JsonProperty(PropertyName = "updatedOn", NullValueHandling = NullValueHandling.Ignore)]
        public DateTime UpdatedOn { get; set; }

        [JsonProperty(PropertyName = "version", NullValueHandling = NullValueHandling.Ignore)]
        public int Version { get;  set; }

        [JsonProperty(PropertyName = "active", NullValueHandling = NullValueHandling.Ignore)]
        public bool Active { get; set; }

        [JsonProperty(PropertyName ="archieved" , NullValueHandling=NullValueHandling.Ignore)]
        public bool Archieved { get; set; }

        [JsonProperty(PropertyName ="voteId",NullValueHandling =NullValueHandling.Ignore)]
        public string VoterId { get; set; }

        [JsonProperty(PropertyName ="voterName" ,NullValueHandling =NullValueHandling.Ignore)]
        public string VoterName { get; set; }

        [JsonProperty(PropertyName = "voteParty", NullValueHandling = NullValueHandling.Ignore)]
        public string VoteParty { get; set; }

        


    }
}
