using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UpSchool.Domain.Dtos
{
    public class PasswordCareTaker
    {
        public List< PasswordMemento>? PasswordMemento { get; set; }
        public PasswordCareTaker() { 
        
        PasswordMemento= new List< PasswordMemento>();
        }
    }
}
