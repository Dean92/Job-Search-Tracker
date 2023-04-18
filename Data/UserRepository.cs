using JobSearchTracker.Interfaces;
using JobSearchTracker.Models;
using Microsoft.EntityFrameworkCore;

namespace JobSearchTracker.Data
{
	public class UserRepository : IUserRepository
	{
		private readonly DataContext _context;
		public UserRepository(DataContext context)
		{
			_context = context;
		}
		public async Task<AppUser> GetUserByIdAsync(int id)
		{
			return await _context.Users.FindAsync(id);
		}

		public async Task<AppUser> GetUserByUserNameAsync(string username)
		{
			return await _context.Users.Include(p => p.Jobs).SingleOrDefaultAsync(x => x.UserName == username);
		}

		public async Task<IEnumerable<Jobs>> GetJobsForUserAsync(string username)
		{
			var user = await _context.Users
				.Include(u => u.Jobs)
				.SingleOrDefaultAsync(u => u.UserName == username);

			return user.Jobs;
		}



		public async Task<IEnumerable<AppUser>> GetUsersAsync()
		{
			return await _context.Users.Include(p => p.Jobs).ToListAsync();
		}

		public async Task<bool> SaveAllAsync()
		{
			return await _context.SaveChangesAsync() > 0;
		}

		public void Update(AppUser user)
		{
			_context.Entry(user).State = EntityState.Modified;
		}
	}
}
