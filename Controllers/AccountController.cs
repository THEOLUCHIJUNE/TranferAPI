using System;
using TranferAPI.Interface;
using TranferAPI.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace TranferAPI.Controllers
{
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly ITransferService _repo;

        public AccountController(
            ITransferService repo
        )
        {
            _repo = repo;
        }

        [HttpGet("/account")]
        public ActionResult<IEnumerable<Account>> Get()
        {
            var accounts = _repo.GetAllAccounts();
            return Ok(accounts);
        }

        [HttpPost("/account")]
        public ActionResult<Account> Post(Account model)
        {
            try
            {
                var account = _repo.AddAccount(model);
                return new CreatedResult("/person/", new {Id = account.Id, message="Account Created Successfully"});
            }
            catch (Exception e)
            {
                return BadRequest(new { message = e.Message});
            }
        }

        [HttpPatch("/account/{id}")]
        public ActionResult<Account> Patch(string id, string AccountNumber, Account model)
        {
            try
            {
                var account = _repo.UpdatePatchAccount(id, AccountNumber, model);
                return new OkObjectResult(new { message = "Account Updated successfully", id});
            }
            catch (Exception e)
            {
                return BadRequest(new {message = e.Message});
            }
        }

        [HttpPut("/account/{id}")]
        public ActionResult<Account> Put(string id, string AccountNumber, Account model)
        {
            try
            {
                var account = _repo.UpdatePutAccount(id, AccountNumber, model);
                return new OkObjectResult(new {message = "Acccount updated successfully", id });
            }
            catch (Exception e)
            {
                return BadRequest(new {message = e.Message});
            }
        }

        [HttpDelete("/account/{id}")]
        public ActionResult<Account> Delete(string id)
        {
            try
            {
                var account = _repo.DeleteAccount(id);
                return new OkObjectResult(new {message = "Account Deleted successfully", id });
            }
            catch (Exception e)
            {
                return BadRequest(new {message = e.Message});
            }
        }  
    }
}