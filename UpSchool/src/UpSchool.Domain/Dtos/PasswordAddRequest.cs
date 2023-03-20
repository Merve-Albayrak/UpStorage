using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UpSchool.Domain.Dtos
{
    public class PasswordAddRequest
    {
        public string Password { get; set; }
        public PasswordAddRequest(string password)
        {
            Password = password;
        }
        public PasswordAddRequest()
        {

        }
    }
}
