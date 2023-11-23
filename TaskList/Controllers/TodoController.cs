using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TaskList.DTOs;
using TaskList.Infraestructure;
using TaskList.Services;

namespace TaskList.Controllers
{
    [Route("/api/[controller]")]
    [ApiController]
    public class TodoController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public TodoController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        [Route("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            var response = await _unitOfWork.TodoRepository.GetAllTasks();
            if(response == null)
            {
                return ResponseFactory.CreateErrorResponse(500, "Error obteniendo tareas, intente de nuevo mas tarde.");
            }
            return ResponseFactory.CreateSuccessResponse(200, response);
        }

        [HttpGet]
        [Route("GetById")]
        public async Task<IActionResult> GetById(int id)
        {
            var response = await _unitOfWork.TodoRepository.GetById(id);
            if (response == null)
            {
                return ResponseFactory.CreateErrorResponse(500, "Error obteniendo tarea, intente de nuevo mas tarde.");
            }
            return ResponseFactory.CreateSuccessResponse(200, response);
        }

        [HttpPost]
        [Route("Add")]
        public async Task<IActionResult> Insert(TaskDTO taskDTO)
        {
            var result = await _unitOfWork.TodoRepository.InserTask(taskDTO);
            if (result)
            {
                await _unitOfWork.Complete();
                return ResponseFactory.CreateSuccessResponse(201, "Tarea agregada.");
            }
            return ResponseFactory.CreateErrorResponse(400, "Error al agregar nueva tarea, intente mas tarde.");
        }

        [HttpPut]
        [Route("Update/{id}")]
        public async Task<IActionResult> Update(int id, TaskDTO taskDTO)
        {
            var result = await _unitOfWork.TodoRepository.UpdateTask(id, taskDTO);
            if (result)
            {
                await _unitOfWork.Complete();
                return ResponseFactory.CreateSuccessResponse(200, "Tarea actualizada.");
            }
            return ResponseFactory.CreateErrorResponse(400, "Error modificando tarea. Contacte a servicio tecnico.");
        }

        [HttpDelete]
        [Route("Delete/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _unitOfWork.TodoRepository.DeleteTask(id);
            if(result)
            {
                await _unitOfWork.Complete();
                return ResponseFactory.CreateSuccessResponse(200, "Tarea completada.");
            }
            return ResponseFactory.CreateErrorResponse(400, "Error completando la tarea. Contacte a servicio tecnico.");
        }
    }
}
