using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UpSchool.Domain.Dtos;
using UpSchool.Domain.Utilities;

namespace Upschool.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PasswordsController : ControllerBase
    {
        private readonly PasswordGenerator _passwordGenerator;
        private readonly GeneratePasswordDto _generatePasswordDto;
     private static   List<string> _passwords=new List<string>();
        public PasswordsController()
        {
            _passwordGenerator= new PasswordGenerator();
            _generatePasswordDto
                = new GeneratePasswordDto
                {

                    Length = 15,
                    IncludeSpecialCharacters = true,
                    IncludeUppercaseCharacters = true
                };
        }
        [HttpGet]
        public IActionResult GetPasswords()
        {
            List<string> passwords = new List<string>();

            
            return Ok(_passwords);
        }

        [HttpPost]
        public IActionResult Add(PasswordAddRequest addRequest)
        {
           
            if(_passwords.Any(p=>p==addRequest.Password))
                return BadRequest("The given password has already been saved before");

            _passwords.Add(addRequest.Password);


            return NoContent();//işelm başarılı ama ben bir şey dönmüyorum(200 status code)
            //görüldü atmak gibi ama pozitif
        }

        [HttpDelete("{password}")] //bu işlemde bize password değişkeni gelcek
        public IActionResult Delete(string password)
        {

            if (!_passwords.Any(p => p == password))
                return BadRequest("The given password wass not found");

            _passwords.Remove(password);


            return NoContent();//işelm başarılı ama ben bir şey dönmüyorum(200 status code)
            //görüldü atmak gibi ama pozitif
        }
    }
}
