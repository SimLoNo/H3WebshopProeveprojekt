using H3WebshopProeveprojekt.Api.DTO;
using H3WebshopProeveprojekt.Api.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace H3WebshopProeveprojekt.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController :ControllerBase
    {
        private readonly IAccountService _accountService;

        public AccountController(IAccountService accountService)
        {
            _accountService = accountService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAccounts()
        {
            try
            {
                List<AccountResponse> accounts = await _accountService.GetAllAccounts();
                if (accounts == null)
                {
                    return Problem("accounts was null, this was unexpected");
                }
                if (accounts.Count == 0)
                {
                    return NoContent();
                }
                return Ok(accounts);
            }
            catch (Exception ex)
            {

                return Problem(ex.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAccountById([FromRoute] int id)
        {
            try
            {
                AccountResponse account = await _accountService.GetAccountById(id);
                if (account == null)
                {
                    return NotFound();
                }
                return Ok(account);
            }
            catch (Exception ex)
            {

                return Problem(ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> InsertNewAccount([FromBody] AccountRequest accountRequest)
        {
            try
            {
                AccountResponse account = await _accountService.InsertNewAccount(accountRequest);
                if (account == null)
                {
                    return NotFound();
                }
                return Ok(account);
            }
            catch (Exception ex)
            {

                return Problem(ex.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAccount([FromRoute] int id,[FromBody] AccountRequest accountRequest)
        {
            try
            {
                AccountResponse account = await _accountService.UpdateAccount(id, accountRequest);
                if (account == null)
                {
                    return NotFound();
                }
                return Ok(account);
            }
            catch (Exception ex)
            {

                return Problem(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAccount([FromRoute] int id)
        {
            try
            {
                AccountResponse account = await _accountService.DeleteAccount(id);
                if (account == null)
                {
                    return NotFound();
                }
                return Ok(account);
            }
            catch (Exception ex)
            {

                return Problem(ex.Message);
            }
        }
    }
}
