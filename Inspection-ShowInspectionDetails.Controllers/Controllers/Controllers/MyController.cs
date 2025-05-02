using Microsoft.AspNetCore.Mvc;
using InspectionShowInspectionDetails.Messages.Dtos;
using InspectionShowInspectionDetails.Controllers.DtoFactory;

namespace InspectionShowInspectionDetails.Controllers
{
    [ApiController]
    [Route("Api/ShowInspectionDetails")]
    public class MyController : BaseController
    {
        public MyController(IMessageSession messageSession, IDtoFactory dtoFactory)
            : base(messageSession, dtoFactory) { }

        [HttpGet("GetInspectionDetails")]
        public async Task<IActionResult> GetInspection(string username)
        {

            try
            {
                ShowInspectionDetailsRequest dto = new ShowInspectionDetailsRequest
                {
                   Email = username
                };
                var response = await _messageSession.Request<ShowInspectionDetailsResponse>(dto);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error while processing the request: {ex.Message}");
            }
        }


    }

}
