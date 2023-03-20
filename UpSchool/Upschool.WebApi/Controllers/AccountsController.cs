using AutoMapper;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using UpSchool.Domain.Dtos;
using UpSchool.Domain.Entities;
using UpSchool.Domain.Utilities;
using UpSchool.Persistence.EntityFramework.Contexts;

namespace Upschool.WebApi.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class AccountsController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly UpStorageDbContext _dbContext;
        public AccountsController(IMapper mapper, UpStorageDbContext dbContext)
        {
            _mapper = mapper;
            _dbContext = dbContext;
        }

        private static List<Account> _accounts = new()
       {


         new Account()
            {

                Id = Guid.NewGuid(),
                UserName = "mrpickle",
                Password = StringHelper.Base64Encode("123pickle123"),
                IsFavourite = false,
                CreatedOn = DateTimeOffset.Now,
                Title = "UpSchool",
                Url = "www.upschool",
                ShowPassword=false


            },


        new Account()
        {

            Id = Guid.NewGuid(),
                UserName = "fullspeed",
                Password = StringHelper.Base64Encode("123fullspeed123"),
                IsFavourite = true,
                CreatedOn = DateTimeOffset.Now,
                Title = "Gmail",
                Url = "https://www.google.com/intl/tr/gmail/about/",
                ShowPassword = false



        },

       new Account()
        {

            Id = Guid.NewGuid(),
                UserName = "moviegirl",
                Password = StringHelper.Base64Encode("123moviegirl123"),
                IsFavourite = true,
                CreatedOn = DateTimeOffset.Now,
                Title = "Sinemalar",
                Url = "https://www.sinemalar.com",
                ShowPassword = false


       }

       };
        [HttpGet("{id:guid}")]
        public IActionResult GetById(Guid id)
        {
            //var account = _accounts.FirstOrDefault(x => x.Id == id);
            var account = _dbContext.Accounts.FirstOrDefault(a => a.Id == id);
            if (account is null) return NotFound("The selected account was not found.");

            return Ok(AccountDto.MapFromAccount(account));
        }


        [HttpPut]
        public IActionResult Edit(AccountEditDto accountEditDto)
        {
           // var accountIndex = _dbContext.Accounts.FirstOrDefault(x => x.Id == accountEditDto.Id);

            var account=_dbContext.Accounts.FirstOrDefault(x=>x.Id == accountEditDto.Id);
            if (account is null) return NotFound("The selected account was not found.");

            var updatedAccount = _mapper.Map<AccountEditDto, Account>(accountEditDto, account);

            _dbContext.Accounts.Update(account);
            _dbContext.SaveChanges();
           // _accounts[accountIndex] = updatedAccount;

            return Ok(_mapper.Map<AccountDto>(updatedAccount));
        }
        [HttpGet]
       public IActionResult GetAll()
        {


           var accountDtos = _accounts.Select(account => AccountDto.MapFromAccount(account)); //auto mapper kullanılabilirdi
            //ama performansı daha düşük
           
            return Ok(accountDtos);


        }

        [HttpPost]
        public IActionResult Add(AccountAddDto accountAddDto)
        {

            var account = new Account()


                {
                Id = Guid.NewGuid(),
                Title = accountAddDto.Title,
                Url = accountAddDto.Url,
                CreatedOn = DateTimeOffset.Now,
                UserName = accountAddDto.UserName,
                Password = accountAddDto.Password,
            };
                
           _dbContext.Accounts.Add(account);
            _dbContext.SaveChanges();
            return Ok(AccountDto.MapFromAccount(account));


        }

        [HttpDelete("{id:guid}")]
        public IActionResult Delete(Guid id)
        {

           var account=_accounts.FirstOrDefault(x => x.Id == id);
            if (account is null) return NotFound("The selected account was not found.");

            _accounts.Remove(account);
            return NoContent();


        }



    }
       
    
}
