using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace App1.Infraestructure
{
    public class TasksDB : IRule
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
    }
}
