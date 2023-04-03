using System.ComponentModel.DataAnnotations;

namespace JobSearchTracker.Models.Dtos
{
	public class RegisterDTO
	{
		[Required]
		public string Username { get; set; }
		[Required]
		[StringLength(8, MinimumLength = 4)]
		public string Password { get; set; }
	}
}
