using AutoMapper;
using BulkyBook.DataAccess.IRepository;
using BulkyBook.Models;
using BulkyBook.Models.Dtos;
using Microsoft.AspNetCore.Mvc;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace BulkyBookAPI.Controllers
{
	[Route("api/Authentication")]   
	[ApiController]
	public class AuthenticationController : ControllerBase
	{
		private readonly IUnitOfWork _unitOfWork;
		private readonly IMapper _mapper;
		private readonly IConfiguration _configuration;

		public AuthenticationController(IConfiguration configuration, IUnitOfWork unitOfWork, IMapper mapper)
		{
			_unitOfWork = unitOfWork;
			_mapper = mapper;
			_configuration = configuration;
		}

		[HttpPost("register")]
		[ProducesResponseType(StatusCodes.Status400BadRequest)]
		[ProducesResponseType(StatusCodes.Status500InternalServerError)]
		[ProducesResponseType(StatusCodes.Status200OK)]
		public async Task<ActionResult<Category>> Register([FromBody] UserDto userDto)
		{
			if (userDto == null)
				return BadRequest();
			if (userDto.Id != 0)
				return StatusCode(StatusCodes.Status500InternalServerError);
			var userData = _unitOfWork.User.GetFirstOrDefault(x => x.UserName == userDto.UserName);
			if (userData != null)
				return BadRequest(new { errors = "UserName Already Exists"});
			userDto.Password = BCrypt.Net.BCrypt.HashPassword(userDto.Password);
			User user = _mapper.Map<User>(userDto);
			_unitOfWork.User.Add(user);
			_unitOfWork.Save();
			return Ok(user);
		}

		[HttpPost("login")]
		[ProducesResponseType(StatusCodes.Status400BadRequest)]
		[ProducesResponseType(StatusCodes.Status500InternalServerError)]
		[ProducesResponseType(StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status401Unauthorized)]
		public ActionResult Login([FromBody] UserDto userDto)
		{	
			if (userDto == null)
				return BadRequest();
			if (userDto.Id != 0)
				return StatusCode(StatusCodes.Status500InternalServerError);
			User user = _unitOfWork.User.GetFirstOrDefault(user => user.UserName == userDto.UserName);
			if (user == null)
				return Unauthorized("Invalid Credentials");
			if (!BCrypt.Net.BCrypt.Verify(userDto.Password, user.Password))
				return Unauthorized("Invalid Credentials");

			var jwt = _configuration.GetSection("Jwt").Get<Jwt>();
			var claims = new[]	
			{
						new Claim(JwtRegisteredClaimNames.Sub, jwt.Subject ?? ""),
						new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
						new Claim(JwtRegisteredClaimNames.Iat, DateTime.UtcNow.ToString()),
						new Claim("Id", user.Id.ToString()),
						new Claim("UserName", user.UserName??""),
						new Claim("Password", user.Password??"")

			};
			var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwt.key));
			var signIn = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
			var token = new JwtSecurityToken(
			   jwt.Issuer,
			   jwt.Audience,
				claims,
				expires: DateTime.Now.AddHours(1),
				signingCredentials: signIn
			);
			return Ok(new { token = new JwtSecurityTokenHandler().WriteToken(token) });

			//return Ok(user);
		}
	}
}
