using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UpSchool.Domain.Dtos
{
    public class Password
    {
        public string Value { get; set; }


        public PasswordMemento SavePassword()
        {
            return new PasswordMemento
            {


                Value = this.Value,
            };


        }
        
    }
}
