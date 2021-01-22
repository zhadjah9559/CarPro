using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using CarPro.Models;
using System;
using System.Linq;

namespace CarPro.Data
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new ApplicationDbContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<ApplicationDbContext>>()))
            {

                if (!context.Lots.Any())
                {
                    context.Lots.Add(
                        new Lot
                        {
                            Name = "Clemson's Car Lot",
                            ZipCode = "01702",
                            PhoneNumber = "508-879-0275",
                            ManagerName = "Nick Marascio"
                        }
                    ); 
                    context.SaveChanges();
                }


                if (!context.Cars.Any())
                {
                    var lotId = context.Lots.FirstOrDefault(l => l.Name == "Clemson's Car Lot").Id;

                    context.Cars.AddRange(
                        new Car
                        {
                            LotId = lotId,
                            Make = "Toyota",
                            Model = "Camry",
                            ModelYear = 2000,
                            Mileage = 20000,
                            Price = 3300,
                            Color = "Black",
                            is4WD = true
                        },

                        new Car
                        {
                            LotId = lotId,
                            Make = "Nissan",
                            Model = "Altima",
                            ModelYear = 2013,
                            Mileage = 29000,
                            Price = 8300,
                            Color = "Red",
                            is4WD = false
                        },

                        new Car
                        {
                            LotId = lotId,
                            Make = "Nissan",
                            Model = "Titan",
                            ModelYear = 2009,
                            Mileage = 67000,
                            Price = 6300,
                            Color = "Ruby",
                            is4WD = true
                        },

                        new Car
                        {
                            LotId = lotId,
                            Make = "Toyota",
                            Model = "Corolla",
                            ModelYear = 2018,
                            Mileage = 30000,
                            Price = 9500,
                            Color = "Red",
                            is4WD = true
                        },

                        new Car
                        {
                            LotId = lotId,
                            Make = "Toyota",
                            Model = "Rav4",
                            ModelYear = 2019,
                            Mileage = 58000,
                            Price = 13000,
                            Color = "Grey",
                            is4WD = false,
                        }
                    ); 
                    context.SaveChanges();
                }

            }
        }
    }
}