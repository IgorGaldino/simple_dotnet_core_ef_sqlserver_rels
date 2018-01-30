using System;
using System.Linq;
using ConsoleAppEFSqliteEx01.Model;

namespace ConsoleAppEFSqliteEx01
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var context = new StoreContext())
            {
                context.Set<Category>().RemoveRange(context.Categories);
                context.Set<ProductTag>().RemoveRange(context.ProductsTags);
                context.Set<Tag>().RemoveRange(context.Tags);
                context.Set<Product>().RemoveRange(context.Products);

                Tag tag1 = new Tag() { Name = "tech" };
                Tag tag2 = new Tag() { Name = "home" };

                context.Add(tag1);
                context.Add(tag2);
                context.SaveChanges();

                var cat1 = new Category() { Name = "PCs" };
                var cat2 = new Category() { Name = "Games" };
                context.Add(cat1);
                context.Add(cat2);
                context.SaveChanges();

                // Adiciona produto
                var newp1 = new Product() { Name = "Notebook", Category = cat1 };
                var newp2 = new Product() { Name = "Car", Category = cat2 };
                newp1.ProductTags.Add(new ProductTag(){ProductId = newp1.Id, TagId = tag1.Id});
                context.Add(newp1);
                context.Add(newp2);
                context.SaveChanges();

                // Exibe os items da tabela produto
                var products = context.Set<Product>();
                foreach (var p in products)
                {
                    Console.WriteLine($"Product:\t{p.Name}");
                }
                // Busca e Atualiza um produto
                var founded = context.Set<Product>().First(p => p.Id == newp1.Id);
                founded.Name = "Notebook X";
                context.SaveChanges();

                products = context.Products;
                foreach (var p in products)
                {
                    Console.WriteLine($"Product:\t{p.Name}");
                }

                context.Add(new Product() { Name = "Keyboard" });
                context.SaveChanges();

                // Remove o produto
                founded = context.Set<Product>().First(p => p.Name == "Keyboard");
                context.Remove(founded);
                context.SaveChanges();

                foreach (var c in context.Categories)
                {
                    Console.WriteLine($"Category:\t{c.Name}");
                    foreach (var p in c.Products)
                    {
                        Console.WriteLine($"\tProduct:\t{p.Name}");
                    }

                }

                Console.ReadKey();

            }
        }
    }
}
