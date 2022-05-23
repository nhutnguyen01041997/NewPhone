using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

using NewPhone.Models;
using System;
using System.Linq;
namespace NewPhone.Models
{
    public static class SeedData
    {
        public static void EnsurePopulated(IApplicationBuilder app)
        {

            NewPhoneDbContext context = app.ApplicationServices.CreateScope().ServiceProvider.GetRequiredService <NewPhoneDbContext> ();
                if (context.Database.GetPendingMigrations().Any())
                {
                context.Database.Migrate();
                }
                if (!context.SMartPhones.Any())
                {
                context.SMartPhones.AddRange(
                new SMartPhone
                {
                    Title = "Galaxy ZFold 2-5G",
                    ReleaseDate = DateTime.Parse("2021-07-03"),
                    Genre = "Sam Sung",                    
                    Price = 10.62M
                },
                new SMartPhone 
                {
                    Title = "Galaxy S21-5G",
                    ReleaseDate = DateTime.Parse("2021-09-04"),
                    Genre = "Sam Sung",
                    Price = 7.2M
                },
                new SMartPhone
                {
                    Title = "Galaxy Note 20 Ultra-5G",
                    ReleaseDate = DateTime.Parse("2021-06-07"),
                    Genre = "Sam Sung",
                    Price = 6.2M
                },
                new SMartPhone
                {
                    Title = "Galaxy A52-5G",
                    ReleaseDate = DateTime.Parse("2021-08-15"),
                    Genre = "Sam Sung",
                    Price = 5.25M
                },
                new SMartPhone
                {
                    Title = "Galaxy M52-5G",
                    ReleaseDate = DateTime.Parse("2021-03-27"),
                    Genre = "Sam Sung",
                    Price = 3.24M
                }
                );
                context.SaveChanges();//lưu dữ liệu
            }
        }

        internal static void Initialize(IServiceProvider services)
        {
            throw new NotImplementedException();
        }
    }
}