using AutoMapper;
using JobSearchTracker.Interfaces;
using JobSearchTracker.Models;
using JobSearchTracker.Models.Dtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace JobSearchTracker.Controllers
{
	[Authorize]
	public class UsersController : BaseApiController
	{
		private readonly IUserRepository _userRepository;
		private readonly IMapper _mapper;
		public UsersController(IUserRepository userRepository, IMapper mapper)
		{
			_mapper = mapper;
			_userRepository = userRepository;
			
		}

		[HttpGet]
		public async Task<ActionResult<IEnumerable<AppUser>>> GetUsers()
		{
			var users = await _userRepository.GetUsersAsync();

			var usersToReturn = _mapper.Map<IEnumerable<UserInfoDTO>>(users);

			return Ok(usersToReturn);
		}

		[HttpGet("{username}")]
		public async Task<ActionResult<UserInfoDTO>> GetUser(string username)
		{
			var user = await _userRepository.GetUserByUserNameAsync(username);

			return _mapper.Map<UserInfoDTO>(user);

		}
	}
}
