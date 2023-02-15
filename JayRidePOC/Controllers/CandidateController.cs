using Contracts.BusinessLogic;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Model.Candidate;

namespace JayRidePOC.Controllers
{
    [Route("api")]
    [ApiController]
    public class CandidateController : ControllerBase
    {
        private readonly ICandidateLogic _candidateLogic;

        public CandidateController(ICandidateLogic candidateLogic)
        {
            _candidateLogic = candidateLogic;
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [AllowAnonymous]
        [HttpGet]
        [Route("Candidate")]
        public async Task<ActionResult<Candidate>> CandidateInfo()
        {
            Candidate candidate;
            try
            {
                candidate = _candidateLogic.GetCandidateInfo();                
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
            return Ok(candidate);
        }
    }
}
