using Microsoft.AspNetCore.Mvc;
using TodoApp_ServerAPI.Data.Interfaces;
using TodoApp_ServerAPI.Model;

namespace TodoApp_ServerAPI.Controllers
{
        [Route("api")]
        [ApiController]
        public class ItemController : Controller
        {
            private readonly IItemRepository _iItemrepository;

            public ItemController(IItemRepository iItemRepository)
            {
                _iItemrepository = iItemRepository;

            }
            [HttpGet("get-all-todos")]
            public IActionResult GetAllToDos()
            {
                return Ok(_iItemrepository.GetListTodoItem().Result);
            }

            [HttpGet("get-todo-by-id/{itemId}")]
            public IActionResult GetTodoById(int itemId)
            {
                var itemToReturn = _iItemrepository.GetTodoItemById(itemId);
                if (itemToReturn == null)
                {
                    return BadRequest();
                }
                else
                {
                    return Ok(itemToReturn);
                }
            }

            [HttpPost("create-todo")]
            public IActionResult CreateTodo(TodoItem todo)
            {
                bool createSuccessful = _iItemrepository.CreateTodoItem(todo).Result;

                if (createSuccessful == false)
                {
                    return BadRequest();
                }
                else
                {
                    return Ok("Todo Created");
                }
            }

            [HttpPut("update-todo")]
            public IActionResult UpdateTodo(TodoItem todo)
            {
                bool updateSuccessful = _iItemrepository.UpdateTodoItem(todo).Result;
                if (updateSuccessful == false)
                {
                    return BadRequest();
                }
                else
                {
                    return Ok("Item Updated");
                }
            }

            [HttpDelete("delete-todo-by-id/{itemIdToDelete}")]
            public IActionResult DeleteTodoById(int itemIdToDelete)
            {
                bool deleteSuccessful = _iItemrepository.DeleteTodoItemById(itemIdToDelete).Result;
                if (deleteSuccessful == false)
                {
                    return BadRequest();
                }
                else
                {
                    return Ok("Item Deleted");
                }
            }




        }
    }

