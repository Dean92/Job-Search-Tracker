﻿using JobSearchTracker.Models;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography;
using System.Text;
using System.Text.Json;

namespace JobSearchTracker.Data
{
	public class Seed
	{
		public static async Task SeedUsers(DataContext context)
		{
			if (await context.Users.AnyAsync()) return;

			var userData = await File.ReadAllTextAsync("Data/UserSeed.json");
			var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
			var users = JsonSerializer.Deserialize<List<AppUser>>(userData);

			foreach (var user in users)
			{
				using var hmac = new HMACSHA512();

				user.UserName = user.UserName.ToLower();
				user.PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes("Pa$$w0rd"));
				user.PasswordSalt = hmac.Key;

				context.Users.Add(user);
			}

			await context.SaveChangesAsync();
		}
	}
}
