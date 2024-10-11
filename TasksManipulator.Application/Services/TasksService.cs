using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TasksManipulator.Application.DTO;
using TasksManipulator.Application.Interfaces;
using TasksManipulator.Domain.Entities;
using TasksManipulator.Domain.Interfaces;
using TasksManipulator.Infraestructure.Context;
using TasksManipulator.Infraestructure.Repositories;

namespace TasksManipulator.Application.Services
{
    public class TasksService : ITasksService
    {
        private readonly ITasks _Repository;
        private readonly FileManipulator _Manipulator;

        public TasksService(ITasks repository, FileManipulator manipulator)
        {
            _Repository = repository;
            _Manipulator = manipulator;
        }

        public Tasks Get(int id)
        {
            if (!Directory.Exists(_Manipulator.Path))
            {
                Directory.CreateDirectory(_Manipulator.Path);
                File.WriteAllText(_Manipulator.File, "IdTask;TaskName;ToDo;CreationDate;DeliveryDate;completed\n");
            }

            else if (!File.Exists(_Manipulator.File))
                File.WriteAllText(_Manipulator.File, "IdTask;TaskName;ToDo;CreationDate;DeliveryDate;completed\n");

            return _Repository.Get(id);
        }

        public IEnumerable<Tasks> GetAll()
        {
            if (!Directory.Exists(_Manipulator.Path))
            {
                Directory.CreateDirectory(_Manipulator.Path);
                File.WriteAllText(_Manipulator.File, "IdTask;TaskName;ToDo;CreationDate;DeliveryDate;completed\n");
            }

            else if (!File.Exists(_Manipulator.File))
                File.WriteAllText(_Manipulator.File, "IdTask;TaskName;ToDo;CreationDate;DeliveryDate;completed\n");

            return _Repository.GetAll();
        }

        public Tasks post(Tasks entity)
        {
            if (!Directory.Exists(_Manipulator.Path))
            {
                Directory.CreateDirectory(_Manipulator.Path);
                File.WriteAllText(_Manipulator.File, "IdTask;TaskName;ToDo;CreationDate;DeliveryDate;completed\n");
            }

            else if (!File.Exists(_Manipulator.File))
                File.WriteAllText(_Manipulator.File, "IdTask;TaskName;ToDo;CreationDate;DeliveryDate;completed\n");

                _Repository.post(entity);

            return entity;
        }

        public Tasks Put(Tasks entity, int id)
        {
            if (!Directory.Exists(_Manipulator.Path))
            {
                Directory.CreateDirectory(_Manipulator.Path);
                File.WriteAllText(_Manipulator.File, "IdTask;TaskName;ToDo;CreationDate;DeliveryDate;completed\n");
            }

            else if (!File.Exists(_Manipulator.File))
                File.WriteAllText(_Manipulator.File, "IdTask;TaskName;ToDo;CreationDate;DeliveryDate;completed\n");

            //gerar método de Put

            return entity;
        }
        public Tasks Delete(int id)
        {
            throw new NotImplementedException();
        }

    }
}
