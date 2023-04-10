namespace JobSearchTracker.Models.Dtos
{
	public class UserMemDTO
	{
		public int Id { get; set; }
		public string UserName { get; set; }
		public string Name { get; set; }
		
		public string Role { get; set; }

		public DateTime CreatedDate { get; set; }
		public DateTime LastLoginDate { get; set; }

		public List<JobsDto> Jobs { get; set; }
	}
}
