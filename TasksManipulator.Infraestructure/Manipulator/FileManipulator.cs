using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TasksManipulator.Infraestructure.Context
{
    public class FileManipulator
    {
        public string File { get; set; } = @"C:\temp\Tasks\TasksFile";
        public string Welcome { get; set; } = @"C:\temp\Welcome";
        public string Path { get; set; } = @"C:\temp\Tasks";

    }
}
