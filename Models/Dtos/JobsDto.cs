namespace JobSearchTracker.Models.Dtos
{
	public class JobsDto
	{
        public int Id { get; set; }
		public string JobTitle { get; set; }
		public string JobDescription { get; set; }
		public string CompanyName { get; set; }
		public string City { get; set; }
		public string State { get; set; }
		public string SkillLevel { get; set; }
		public string SalaryRange { get; set; }
		public string RemoteHybridOnsite { get; set; }
		public string URLListing { get; set; }
		public string Status { get; set; }

		public int AppUserId { get; set; }
	}
}