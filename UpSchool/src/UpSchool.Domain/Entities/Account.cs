
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UpSchool.Domain.Entities
{
    public class Account
   
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string? Url { get; set; }
        public DateTimeOffset CreatedOn { get; set; } //üretildiği tarih
        public bool IsFavourite { get; set; }
        public bool ShowPassword { get; set; }
        public DateTimeOffset? LastModifiedOn { get; set; }
    }
}
