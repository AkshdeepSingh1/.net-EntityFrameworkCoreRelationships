using System;
using EfCoreRelationships.DbModel;
using EfCoreRelationships.Model;
using Microsoft.AspNetCore.Mvc;
using BuisnessLogic_Layer;
using System.Threading.Tasks;

namespace EfCoreRelationships.Controllers
{
	[Route("api/[Controller]")]
	[ApiController]
	public class UserController : ControllerBase
	{
		//private DataContext context;
        private UserService userService;
        public UserController(UserService userService)
		{
			this.userService = userService;
		}
        //[HttpGet]
        //public async Task<ActionResult> getUser()
        //{
        //	var data = await context.Users.ToListAsync();
        //	return Ok(data);
        //}

        [HttpGet]
        public async Task<ActionResult> getUser()
        {
            var data = await userService.getUsermethod();
            return Ok(data);
        }


        [HttpPost]
        public async Task<ActionResult> addUser(UserDTO user)
        {
            var data = await userService.addUser(user);
            if (data)
                return Ok();
            else
                return BadRequest();
        }
    }
}

