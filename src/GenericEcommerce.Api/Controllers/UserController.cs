using FluentResults;
using GenericEcommerce.Api.Authorization;
using GenericEcommerce.Application.Dto.Login;
using GenericEcommerce.Application.Dto.User;
using GenericEcommerce.Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GenericEcommerce.Api.Controllers
{
    [ApiController]
    [Route("api/user")]
    public class UserController : ControllerBase
    {
        private readonly IUserApplicationService _userApplicationService;
        private readonly ILoginService _loginService;

        public UserController(IUserApplicationService userApplicationService,
                              ILoginService loginService)
        {
            _userApplicationService = userApplicationService;
            _loginService = loginService;
        }

        [HttpGet("{userId}")]
        [AuthorizeRoles(UserRoles.Admin)]
        public async Task<IActionResult> GetByIdAsync([FromRoute] int userId)
        {
            var userFound = await _userApplicationService.GetByIdAsync(userId);

            if (userFound == null) return NotFound();

            return Ok(userFound);
        }

        [HttpGet]
        [Authorize(Roles = "admin")]
        [AuthorizeRoles(UserRoles.Admin)]
        public async Task<IActionResult> GetAllAsync([FromQuery] int pageNumber, [FromQuery] int pageSize)
        {
            var usersFoundList = await _userApplicationService.GetAllAsync(pageNumber, pageSize);

            if (!usersFoundList.Any()) return NoContent();

            return Ok(usersFoundList);
        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync(CreateUserDto createDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var userCreated = await _userApplicationService.CreateUserAsync(createDto);

            if (!userCreated.Succeeded) return NotFound(userCreated.Errors);

            return Ok(userCreated);
        }

        [HttpPost("login")]
        public IActionResult UserLoginAsync(LoginRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = _loginService.UserLoginAsync(request);

            if (result.IsFailed) return Unauthorized(result.Errors);

            return Ok(result.Successes[0]);
        }

        [HttpPatch]
        [AuthorizeRoles(UserRoles.Admin, UserRoles.Regular)]
        public async Task<IActionResult> UpdateAsync([FromBody] UpdateUserDto request)
        {
            var userIdClaim = User.FindFirst("id");
            Result resultado = await _userApplicationService.UpdateAsync(userIdClaim.Value, request);

            if (resultado.IsFailed) return Unauthorized(resultado.Errors);

            return Ok(resultado.Successes);
        }

        [HttpDelete("{id}")]
        [AuthorizeRoles(UserRoles.Admin)]
        public async Task<IActionResult> DelegateAsync([FromRoute] string id)
        {
            var userIdClaim = User.FindFirst("id");

            if (userIdClaim.Value == id.ToString())
            {
                return NoContent();
            }

            var resultado = await _userApplicationService.DeleteAsync(id);

            if (resultado.IsFailed) return Unauthorized(resultado.Errors);

            return Ok(resultado.Successes);
        }
    }
}