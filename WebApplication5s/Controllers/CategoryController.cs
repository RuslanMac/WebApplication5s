using MediatR;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Schema;
using System.Threading.Tasks;
using WebApplication5s.Application.Commands;
using WebApplication5s.Application.Dtos.Commands;

namespace WebApplication5s.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
   
    public class CategoryController : ControllerBase
    {
        private readonly IMediator _mediator;
        
        public CategoryController(IMediator mediator)
        {
            _mediator = mediator;
        }
        /// <summary>
        /// Создание фотографии
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult>  Create([FromBody] AddCategoryCommand command)
        {
           var result = await _mediator.Send(command); 
           return Ok(result);
        }

        /// <summary>
        /// Удаление категории по id значению категории 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(long id)
        {
            var result = await _mediator.Send(new DeleteCategoryCommand { Id = id });

            return Ok(result);
        }
    }
}
