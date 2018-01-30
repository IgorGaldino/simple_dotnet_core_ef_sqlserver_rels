using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleAppEFSqliteEx01.Model
{
    public class Tag
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual ICollection<ProductTag> ProductTags { get; set; }

        public Tag()
        {
            ProductTags = new List<ProductTag>();
        }
    }
}
