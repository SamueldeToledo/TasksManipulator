using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TasksManipulator.Domain.Entities
{
    public class Tasks
    {
        public int IdTask { get; set; }
        public string? TaskName { get; set; }
        public string? ToDo { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime DeliveryDate { get; set; }
        public bool completed { get; set; }
    }
}
