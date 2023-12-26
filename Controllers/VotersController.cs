using Assiment4.CrudApi.DTO;
using Assiment4.CrudApi.Entity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.Cosmos;
using System.ComponentModel;
using System.Security.Policy;
using Container = Microsoft.Azure.Cosmos.Container;
using Azure;

namespace Assiment4.CrudApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class VotersController : ControllerBase
    {
        public string URI = "https://localhost:8081";
        public string PrimaryKey = "C2y6yDjf5/R+ob0N8A7Cgv30VRDJIWEHLM+4QDU5DE2nQ9nDuVTqobD4b8mGGyPMbIZnqyMsEcaGQy67XIw/Jw==";
        public string DataBaseName = "Voters";
        public string ContainerName = "VotersInformation";

        public Container _container;

        public VotersController()
        {
            _container = GetContainer();
        }
        [HttpPost]

        public async Task<IActionResult> AddVoters(VotersDTOModel voterDtoModel)
        {
            try
            {
                Voter voters = new Voter();
                voters.VoterId = voterDtoModel.VoterId;
                voters.VoterName = voterDtoModel.VoterName;
                voters.VoteParty = voterDtoModel.VoteParty;

                voters.Id = Guid.NewGuid().ToString();
                voters.UId = voters.Id;
                voters.DocumentType = "Voters";

                voters.CreatedBy = "Mayur's UId";
                voters.CreatedByName = "Mayur";
                voters.CreatedOn = DateTime.Now;

                voters.UpdateBy = "Mayur'UId";
                voters.UpdatedByName = "Mayur";
                voters.UpdatedOn = DateTime.Now;

                voters.Version = 1;
                voters.Active = true;
                voters.Archieved = false;

                Voter response = await _container.CreateItemAsync(voters);

                voterDtoModel.VoterId = response.VoterId;
                voterDtoModel.VoterName = response.VoterName;
                voterDtoModel.VoteParty = response.VoteParty;

                return Ok(voterDtoModel);

            }
            catch (Exception ex)
            {
                return BadRequest("Data adding faild" + ex);
            }


        }

        [HttpGet]
        
        public IActionResult GetVoterUId(string uId)
        {
            try
            {
                Voter voters = _container.GetItemLinqQueryable<Voter>(true).Where(v => v.DocumentType == "Voters" && v.UId==uId).AsEnumerable().FirstOrDefault();

                var voterDtoModel = new VotersDTOModel();
                voterDtoModel.VoterId = voters.VoterId;
                voterDtoModel.VoterName = voters.VoterName;
                voterDtoModel.VoteParty = voters.VoteParty;
                return Ok(voterDtoModel); 
            }
            catch (Exception ex)
            {
                return BadRequest("Data Get faild"+ex);
            }
        }

        [HttpGet]

        public IActionResult GetAllVoters()
        {
            try
            {
                var votersData = _container.GetItemLinqQueryable<Voter>(true).Where(v => v.DocumentType == "Voters").AsEnumerable().ToList();
                return Ok(votersData);
            }
            catch (Exception ex)
            {
                return BadRequest("Data Get faild"+ex);
            }
        }

        [HttpPut]

        public async Task<IActionResult> UpdateVoterData(string uId, VotersDTOModel updateVoter)
        {
            try
            {
                Voter voters = _container.GetItemLinqQueryable<Voter>(true).Where(v => v.DocumentType == "Voters" && v.UId == uId).AsEnumerable().FirstOrDefault();

                if (voters == null)
                {
                    return NotFound($"Voter with UID {uId} not found");
                }

                voters.Version++;

                voters.VoterId = updateVoter.VoterId;
                voters.VoterName = updateVoter.VoterName;
                voters.VoteParty =updateVoter.VoteParty;

                var response = await _container.ReplaceItemAsync(voters,uId);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest("Data is not update"+ex);
            }
        }

        [HttpDelete]

        public async Task<IActionResult> DeleteVoter(string uId, string primaryKey)
        {
            try
            {
               Voter voters = _container.GetItemLinqQueryable<Voter>(true).Where(v => v.DocumentType == "Voters" && v.UId == uId).AsEnumerable().FirstOrDefault();

               if(voters==null)
                {
                   return NotFound("Data is not found");
                }
                
                var response = await _container.DeleteItemAsync<Voter>(uId, new PartitionKey(primaryKey)); ;

                return Ok(response);
            }
            catch(Exception ex)
            {
                return BadRequest(ex);
            }
        }

        private Container GetContainer() 
        {
            CosmosClient cosmosclient = new CosmosClient(URI, PrimaryKey);
            Container container = cosmosclient.GetContainer(DataBaseName, ContainerName);
            return container;
        }
    }
}
