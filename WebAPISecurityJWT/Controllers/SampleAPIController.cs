using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using WebAPISecurityJWT.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebAPISecurityJWT.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class SampleAPIController : ControllerBase
    {

        private readonly IConfiguration _config;
        private readonly IEmpDataAccess _dal;
        public SampleAPIController(IConfiguration configuration, IEmpDataAccess dal)
        {
            this._config = configuration;
            _dal = dal;
        }

        // GET: api/<SampleAPIController>
        [HttpGet]
        public IEnumerable<Employee> Get()
        {
            return _dal.GetEmps ();
        }

        // GET api/<SampleAPIController>/5
        [HttpGet("{id}")]
        public Employee Get(int id)
        {
            return _dal.GetEmpById (id);
        }

        // POST api/<SampleAPIController>
        [HttpPost]
        public void Post([FromForm] Employee emp)
        {
            _dal.AddEmployee(emp);
        }

        // PUT api/<SampleAPIController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromForm] Employee emp)
        {
            _dal.UpdateEmployee(emp);
        }

        // DELETE api/<SampleAPIController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _dal.DeleteEmployee(id);
        }

        [HttpPost]
        [AllowAnonymous]
        [Route("authenticate")]
        public string Authenticate([FromForm]Users user)
        {
            //validate user from Database DAL
            if(user.username=="ramnath" && user.password == "abc")
            {
                //generate JSON Web token with the valid details and return
                var key = Encoding.UTF8.GetBytes(_config["JWT:Key"]);
                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    //issuer
                    Issuer = _config["JWT:Issuer"],
                    //audience
                    Audience= _config["JWT:Audience"],
                    //expiry
                    Expires=DateTime.UtcNow.AddMinutes(10),
                    //signing key
                    SigningCredentials=new SigningCredentials(new SymmetricSecurityKey(key),SecurityAlgorithms.HmacSha256Signature)
                };
                //create the token with above descriptions
                var tokenHandler = new JwtSecurityTokenHandler();
                var token=tokenHandler.CreateToken(tokenDescriptor);
                //write the token
                return tokenHandler.WriteToken(token);
            }
            else
            {
                return "invalid username/password!!!";
            }            
        }
    }
}
