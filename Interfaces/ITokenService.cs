using JobSearchTracker.Models;

namespace JobSearchTracker.Interfaces
{
	public interface ITokenService
	{
		string CreateToken(AppUser user);
	}
}
