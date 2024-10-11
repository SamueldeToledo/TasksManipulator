using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TasksManipulator.Application.DTO;
using TasksManipulator.Application.Interfaces;
using TasksManipulator.Application.Services;
using TasksManipulator.Domain.Entities;

namespace TasksManipulator.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TarefasController : ControllerBase
    {

        private readonly ITasksService _Service;
        private readonly IMapper _mapper;

        public TarefasController(ITasksService service, IMapper mapper)
        {
            _Service = service;
            _mapper = mapper;
        }

        [HttpGet("Get by Id")]
        public ActionResult<TasksDTO> GetbyId(int id)
        {
            var DTO = _Service.Get(id);

            if (DTO.IdTask == 0)
            {
                return BadRequest("Tarefa não encontrada");
            }

            return Ok(_mapper.Map<TasksDTO>(DTO));
        }
        [HttpGet]
        public ActionResult<IEnumerable<TasksDTO>> Get()
        {
            var DTO = _Service.GetAll();

            if (DTO.Count() == 0)
            {
                return BadRequest("Não há tarefas para serem consultadas");
            }
            return Ok(_mapper.Map<IEnumerable<TasksDTO>>(DTO));
        }

        [HttpPost]
        public ActionResult<TasksDTO> Post(TasksDTO entity)
        {
            if (entity == null)
            {
                return BadRequest("A entidade não pode ser nula.");
            }

            var tarefas = _mapper.Map<Tasks>(entity);
            _Service.post(tarefas);

            return Ok(entity);
        }

    }
}
