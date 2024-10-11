using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TasksManipulator.Application.DTO;
using TasksManipulator.Domain.Entities;

namespace TasksManipulator.Application.Interfaces
{
    public interface ITasksService
    {
        public IEnumerable<Tasks> GetAll();
        public Tasks Get(int id);
        public Tasks Put(Tasks entity);
        public Tasks post(Tasks entity);
        public Tasks Delete(int id);

    }
}
