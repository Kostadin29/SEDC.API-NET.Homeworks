using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace SEDC.HomeworkFromClass02.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        [HttpGet] // http://localhost:[port]/api/Users
        public ActionResult<List<string>> Get()
        {
            return Ok(StaticDb.StaticDbNames);
        }

        [HttpGet("{id}")]
        public ActionResult<string> GetById(int id)
        {
            try
            {
                if(id < 0)
                {
                    return StatusCode(StatusCodes.Status400BadRequest, "The id is a negative number!");
                }

                if(id >= StaticDb.StaticDbNames.Count)
                {
                    return StatusCode(StatusCodes.Status404NotFound, $"The note with id {id} was not found. ");
                }

                return Ok(StaticDb.StaticDbNames[id]);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, " An error occured. Contact the support team. ");
            }
        }
        
    }
}
