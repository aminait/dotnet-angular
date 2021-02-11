using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using Newtonsoft.Json;
using ForHire.API.Models;

namespace ForHire.API.Data
{
    public class Seed
    {
        public static void SeedUsers(DataContext context)
        {
            if (!context.Users.Any())
            {
                var userData = System.IO.File.ReadAllText("Data/users.json");
                var users = JsonConvert.DeserializeObject<List<User>>(userData);
                foreach (var user in users)
                {
                    byte[] passwordHash, passwordSalt;
                    CreatePasswordHash("password", out passwordHash, out passwordSalt);

                    user.PasswordHash = passwordHash;
                    user.PasswordSalt = passwordSalt;
                    user.Email = user.Email.ToLower();
                    context.Users.Add(user);
                }

                context.SaveChanges();
            }
        }

        // public static void SeedJobListings(DataContext context)
        // {
        //     if (!context.JobListings.Any())
        //     {
        //         var jobListingsData = System.IO.File.ReadAllText("Data/job-listings.json");
        //         var jobListings = JsonConvert.DeserializeObject<List<JobListing>>(jobListingsData);
        //         foreach (var jobListing in jobListings)
        //         {
        //             context.JobListings.Add(jobListing);
        //         }

        //         context.SaveChanges();
        //     }
        // }

        private static void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using (var hmac = new HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }
        }
    }
}