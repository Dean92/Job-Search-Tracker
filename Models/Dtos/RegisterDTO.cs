using System.ComponentModel.DataAnnotations;

namespace JobSearchTracker.Models.Dtos
{
	public class RegisterDTO
	{
		[Required]
		public string Username { get; set; }
		[Required]
		public string Password { get; set; }
	}
}
