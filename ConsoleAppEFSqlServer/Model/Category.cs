using System;
using System.Collections.Generic;
using System.Configuration;
using System.Text;

namespace ConsoleAppEFSqliteEx01.Model
{
    /// <summary>
    /// Category possui vários Products (1 Product possui uma category)
    /// </summary>
    public class Category
    {
        public Category()
        {
            Products = new List<Product>();
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual ICollection<Product> Products { get; set; }
    }
}
