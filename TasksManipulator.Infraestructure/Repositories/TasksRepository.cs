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
            foreach (var item in arquivo)
            {
                var listaDeTarefas = item.Split(';');

                string[] ListadeStrings = new string[6];

                ListadeStrings[0] = entity.IdTask.ToString();
                ListadeStrings[1] = entity.TaskName.ToString();
                ListadeStrings[2] = entity.ToDo.ToString();
                ListadeStrings[3] = DateTime.Now.ToString();
                ListadeStrings[4] = entity.DeliveryDate.ToString();
                ListadeStrings[5] = entity.completed.ToString();

                int indice = listaDeTarefas.Select((linha, index) => new { linha, index })
                   .FirstOrDefault(x => x.linha == entity.IdTask.ToString())?.index ?? -1;

                listaDeTarefas[indice] = ListadeStrings.FirstOrDefault().ToString();
            }

            File.WriteAllLines(_fileManipulator.File, arquivo);

            //roda a lista de novo e mostra a nova linha que foi inserida
            var arquivoUpdate = File.ReadAllLines(_fileManipulator.File).ToList();

            foreach (var item in arquivoUpdate)
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

            //popula a entidade para mostrar no grid
            foreach (var item in arquivo)
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

            //remove ela do arquivo
            foreach (var item in arquivo)
            {
                var listaDeTarefas = item.Split(';');


                int indice = listaDeTarefas.Select((linha, index) => new { linha, index })
                   .FirstOrDefault(x => x.linha == id.ToString())?.index ?? -1;

                arquivo.RemoveAt(indice);
            }

            File.WriteAllLines(_fileManipulator.File, arquivo);
            return task;
        }

    }
}
