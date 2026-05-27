using Microsoft.AspNetCore.Mvc;

namespace VetClinicAPI.Controllers
{
    public class ApiBaseController : ControllerBase
    {
        protected async Task<ActionResult> ExecuteSafelyAsync(Func<Task<ActionResult>> action)
        {
            try
            {
                return await action();
            }
            catch (Exception)
            {
                return StatusCode(500, "A server error occurred. Please try again.");
            }
        }
    }
}
