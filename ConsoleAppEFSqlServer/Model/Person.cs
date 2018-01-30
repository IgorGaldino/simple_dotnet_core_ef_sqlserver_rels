using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleAppEFSqliteEx01.Model
{
    public class Person
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public virtual Client Client { get; set; }
        public virtual Employee Employee { get; set; }
        public virtual Manager Manager { get; set; }
    }
}
