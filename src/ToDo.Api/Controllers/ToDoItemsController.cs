using System.Linq;
using Microsoft.AspNetCore.Mvc;
using ToDo.Api.Models;
using ToDo.Core.Domain.Exceptions;
using ToDo.Core.Domain.UseCases;

namespace ToDo.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ToDoItemsController : ControllerBase
    {
        private readonly ICreateUseCase _createUseCase;
        private readonly IListUseCase _listUseCase;
        private readonly IDoUseCase _doUseCase;
        private readonly IUndoUseCase _undoUseCase;
        private readonly IRemoveUseCase _removeUseCase;


        public ToDoItemsController(ICreateUseCase createUseCase, IListUseCase listUseCase, IDoUseCase doUseCase, IUndoUseCase undoUseCase, IRemoveUseCase removeUseCase)
        {
            _createUseCase = createUseCase;
            _listUseCase = listUseCase;
            _doUseCase = doUseCase;
            _undoUseCase = undoUseCase;
            _removeUseCase = removeUseCase;
        }

        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                var items = _listUseCase.Execute();

                var itemsVM = items.Select(x => new ToDoItemViewModel
                {
                    Id = x.Id.ToString(),
                    Name = x.Name,
                    IsCompleted = x.Done
                });

                return Ok(itemsVM);
            }
            catch (BusinessException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public IActionResult Create([FromBody] CreateToDoItemViewModel request)
        {
            try
            {
                var id = _createUseCase.Execute(request.Name);
                return Ok(id);
            }
            catch (BusinessException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}/do")]
        public IActionResult Do(string id)
        {
            try
            {
                _doUseCase.Execute(id);
                return Ok();
            }
            catch (BusinessException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}/undo")]
        public IActionResult Undo(string id)
        {
            try
            {
                _undoUseCase.Execute(id);
                return Ok();
            }
            catch (BusinessException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(string id)
        {
            try
            {
                _removeUseCase.Execute(id);
                return Ok();
            }
            catch (BusinessException ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
