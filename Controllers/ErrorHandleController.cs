using JobSearchTracker.Data;
using JobSearchTracker.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace JobSearchTracker.Controllers
{
	public class ErrorHandleController : BaseApiController
	{
		private readonly DataContext _context;
		public ErrorHandleController(DataContext context)
		{
			_context = context;
		}

		[Authorize]
		[HttpGet("auth")]
		public ActionResult<string> GetSecret()
		{
			return "secret text";
		}


		[HttpGet("not-found")]
		public ActionResult<AppUser> GetNotFound()
		{
			var userExist = _context.Users.Find(-1);

			if (userExist == null) return NotFound();

			return Ok(userExist);
		}


		[HttpGet("server-error")]
		public ActionResult<string> GetServerError()
		{

			var serverExists = _context.Users.Find(-1);

			var serverErrorToReturn = serverExists.ToString();

			return Ok(serverErrorToReturn);
		}
	}
}
