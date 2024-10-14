using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TasksManipulator.Domain.Entities;
using TasksManipulator.Domain.Interfaces;
using TasksManipulator.Infraestructure.Context;

namespace TasksManipulator.Infraestructure.Repositories
{
    public class TasksRepository : ITasks
    {

        private readonly FileManipulator _fileManipulator;

        public TasksRepository(FileManipulator fileManipulator)
        {
            _fileManipulator = fileManipulator;
        }

        public Tasks Get(int id)
        {
            var task = new Tasks();

            var arquivo = File.ReadAllLines(_fileManipulator.File);
            var PulaTitulo = arquivo.Skip(1);
            foreach (var item in PulaTitulo)
            {
                var listaDeTarefas = item.Split(';');
                listaDeTarefas.Where(l => l[0].ToString() == id.ToString());

                task = new Tasks
                {
                    IdTask = Convert.ToInt32(listaDeTarefas[0])
                    ,
                    TaskName = listaDeTarefas[1]
                    ,
                    ToDo = listaDeTarefas[2]
                    ,
                    CreationDate = Convert.ToDateTime(listaDeTarefas[3])
                    ,
                    DeliveryDate = Convert.ToDateTime(listaDeTarefas[4])
                    ,
                    completed = Convert.ToBoolean(listaDeTarefas[5])

                };
            }

            return task;
        }

        public IEnumerable<Tasks> GetAll()
        {
            var task = new List<Tasks>();
            var arquivo = File.ReadAllLines(_fileManipulator.File);

            var PulaTitulo = arquivo.Skip(1);
            foreach (var item in PulaTitulo)
            {
                var listaDeTarefas = item.Split(';');

                task.Add((new Tasks
                {
                    IdTask = Convert.ToInt32(listaDeTarefas[0])
                    ,
                    TaskName = listaDeTarefas[1]
                    ,
                    ToDo = listaDeTarefas[2]
                    ,
                    CreationDate = Convert.ToDateTime(listaDeTarefas[3])
                    ,
                    DeliveryDate = Convert.ToDateTime(listaDeTarefas[4])
                    ,
                    completed = Convert.ToBoolean(listaDeTarefas[5])

                }));
            }

            return task;

        }

        public Tasks post(Tasks entity)
        {
            using (StreamWriter writer = new StreamWriter(_fileManipulator.File, true))
            {
                writer.WriteLine(entity.IdTask.ToString() + ";" + entity.TaskName + ";" + entity.ToDo + ";" + entity.CreationDate.ToString() + ";" + entity.DeliveryDate.ToString() + ";" + entity.completed.ToString());
            }

            return entity;
        }

        public Tasks Put(Tasks entity)
        {
            var arquivo = File.ReadAllLines(_fileManipulator.File).ToList();
            var task = new Tasks();

            for (int i = 0; i < arquivo.Count(); i++)
            {
                var listaDeTarefas = arquivo[i].Split(";");
                if (listaDeTarefas[0] == entity.IdTask.ToString())
                {
                    listaDeTarefas[0] = entity.IdTask.ToString();
                    listaDeTarefas[1] = entity.TaskName.ToString();
                    listaDeTarefas[2] = entity.ToDo.ToString();
                    listaDeTarefas[3] = DateTime.Now.ToString();
                    listaDeTarefas[4] = entity.DeliveryDate.ToString();
                    listaDeTarefas[5] = entity.completed.ToString();

                    arquivo[i] = string.Join(";", listaDeTarefas);
                }
            }

            File.WriteAllLines(_fileManipulator.File, arquivo);

            //roda a lista de novo e mostra a nova linha que foi inserida
            var arquivoUpdate = File.ReadAllLines(_fileManipulator.File).ToList();
            var Lista = arquivoUpdate.Skip(1);
            foreach (var item in Lista)
            {
                var listaDeTarefas = item.Split(';');
                listaDeTarefas.Where(l => l[0].ToString() == entity.IdTask.ToString());

                task = new Tasks
                {
                    IdTask = Convert.ToInt32(listaDeTarefas[0])
                    ,
                    TaskName = listaDeTarefas[1]
                    ,
                    ToDo = listaDeTarefas[2]
                    ,
                    CreationDate = Convert.ToDateTime(listaDeTarefas[3])
                    ,
                    DeliveryDate = Convert.ToDateTime(listaDeTarefas[4])
                    ,
                    completed = Convert.ToBoolean(listaDeTarefas[5])

                };
            }
            return task;
        }
        public Tasks Delete(int id)
        {
            var arquivo = File.ReadAllLines(_fileManipulator.File).ToList();
            var task = new Tasks();

            for (int i = 0; i < arquivo.Count(); i++)
            {
                var listaDeTarefas = arquivo[i].Split(";");

                if (listaDeTarefas[0] == id.ToString())
                {
                    task = new Tasks
                    {
                        IdTask = Convert.ToInt32(listaDeTarefas[0])
                    ,
                        TaskName = listaDeTarefas[1]
                    ,
                        ToDo = listaDeTarefas[2]
                    ,
                        CreationDate = Convert.ToDateTime(listaDeTarefas[3])
                    ,
                        DeliveryDate = Convert.ToDateTime(listaDeTarefas[4])
                    ,
                        completed = Convert.ToBoolean(listaDeTarefas[5])

                    };

                    arquivo.RemoveAt(i);
                }
            }

            File.WriteAllLines(_fileManipulator.File, arquivo);


            return task;

        }
    }
}
