﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ConsoleAppEFSqliteEx01.Model
{
    //[Table("Person_Manager")]
    public class Manager
    {
        public int Id { get; set; }           
        public int PersonId { get; set; }
        public virtual Person Person { get; set; }
    }
}
