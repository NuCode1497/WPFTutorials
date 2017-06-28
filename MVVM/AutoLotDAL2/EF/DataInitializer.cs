using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoLotDAL2.Models;
using System.Data.Entity;

namespace AutoLotDAL2.EF
{
    public class DataInitializer : DropCreateDatabaseAlways<AutoLotEntities>
    {
        protected override void Seed(AutoLotEntities context)
        {
            var customers = new List<Customer>
            {
                new Customer {FirstName = "Dave", LastName = "Brenner"},
                new Customer {FirstName = "Matt", LastName = "Walton"},
                new Customer {FirstName = "Steve", LastName = "Hagen"},
                new Customer {FirstName = "Pat", LastName = "Walton"},
                new Customer {FirstName = "Bad", LastName = "Customer"},
                new Customer {FirstName = "Frank", LastName = "Zappa"},
                new Customer {FirstName = "Gillian", LastName = "Nazeebo"},
            };
            customers.ForEach(x => context.Customers.Add(x));
            var cars = new List<Car>
            {
                new Car {Make = "VW", Color = "Black", CarNickName = "Zippy" },
                new Car {Make = "Ford", Color = "Rust", CarNickName = "Rusty" },
                new Car {Make = "Saab", Color = "Black", CarNickName = "Mel" },
                new Car {Make = "Yugo", Color = "Yellow", CarNickName = "Clunker" },
                new Car {Make = "BMW", Color = "Black", CarNickName = "Bimmer" },
                new Car {Make = "BMW", Color = "Green", CarNickName = "Hank" },
                new Car {Make = "BMW", Color = "Pink", CarNickName = "Pinky" },
                new Car {Make = "Pinto", Color = "Black", CarNickName = "Pete" },
                new Car {Make = "Yugo", Color = "Brown", CarNickName = "Brownie" },
                new Car {Make = "Tesla", Color = "White", CarNickName = "Thor" },
                new Car {Make = "Dodge", Color = "Red", CarNickName = "Tiger" },
                new Car {Make = "VW", Color = "Cyan", CarNickName = "Ocean" },
            };
            cars.ForEach(x => context.Inventory.Add(x));
            var orders = new List<Order>
            {
                new Order {Car = cars[0], Customer = customers[0]},
                new Order {Car = cars[1], Customer = customers[1]},
                new Order {Car = cars[2], Customer = customers[2]},
                new Order {Car = cars[3], Customer = customers[3]},
            };
            orders.ForEach(x => context.Orders.Add(x));

            context.CreditRisks.Add(
                new CreditRisk
                {
                    CustId = customers[4].CustId,
                    FirstName = customers[4].FirstName,
                    LastName = customers[4].LastName,
                });
            context.SaveChanges();
        }
    }
}
