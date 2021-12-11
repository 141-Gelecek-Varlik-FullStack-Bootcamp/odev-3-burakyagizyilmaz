using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Odev3_Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Odev3_Data
{
    public static class Seeds
    {
        public static void AddTestData(IServiceProvider serviceProvider)
        {
            using (var context = new AppDbContext(serviceProvider.GetRequiredService<DbContextOptions<AppDbContext>>()))
            {
                if (context.Users.Any())
                {
                    return;
                }

                //Add virtual UserGroup(s)
                UserGroup userGroup1 = new UserGroup { Id=1,Name="Admin"};
                UserGroup userGroup2 = new UserGroup { Id=2,Name= "Sales Representive" };
                UserGroup userGroup3 = new UserGroup { Id=3,Name="Guest"};
                context.UserGroups.AddRange(userGroup1,userGroup2,userGroup3);

                //Add virtual user(s)
                User user1 = new User { Id = 1, Name = "Burak", Email = "yagizyilmazburak@gmail.com", Password = "123456789",UserGroupId=1 };
                User user2 = new User { Id = 2, Name = "Ayaz", Email = "yagizyilmazayaz@gmail.com", Password = "987654321",UserGroupId=2 };
                context.Users.AddRange(user1,user2);

                //Add virtual product(s)
                Product product1 = new Product { Id = 1, Name = "Elma", Price = 5, Stock = 10, CreatedBy = user1, CreatedOn = DateTime.Now.AddDays(-1), LastModifiedBy = user1, LastModifiedOn = DateTime.Now };
                Product product2 = new Product { Id = 2, Name = "Armut", Price = 7, Stock = 10, CreatedBy = user1, CreatedOn = DateTime.Now.AddDays(-2), LastModifiedBy = user1, LastModifiedOn = DateTime.Now };
                context.Products.AddRange(product1,product2);
                context.SaveChanges();
            }
        }
    }
}
