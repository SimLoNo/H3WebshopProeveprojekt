using H3WebshopProeveprojekt.Api.Database.Entities;
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
    public class AccountRoleController :ControllerBase
    {
        private readonly IAccountRoleService _accountRoleService;

        public AccountRoleController(IAccountRoleService accountRoleService)
        {
            _accountRoleService = accountRoleService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAccountRoles()
        {
            try
            {
                List<AccountRoleResponse> accountRoles = await _accountRoleService.GetAllAccountRoles();
                if (accountRoles == null)
                {
                    return Problem("The AccountRoles were null, this is unexpected.");
                }
                if (accountRoles.Count == 0)
                {
                    return NoContent();
                }
                return Ok(accountRoles);
            }
            catch (Exception ex)
            {

                return Problem(ex.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAccountRoleById([FromRoute] int id)
        {
            try
            {
                AccountRoleResponse accountRoleResponse = await _accountRoleService.GetAccountRoleByID(id);
                if (accountRoleResponse == null)
                {
                    return NotFound();
                }
                return Ok(accountRoleResponse);
            }
            catch (Exception ex)
            {

                return Problem(ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> InsertNewAccountRole([FromBody] AccountRoleRequest accountRoleRequest)
        {
            try
            {
                AccountRoleResponse accountRoleResponse = await _accountRoleService.InsertNewAccountRole(accountRoleRequest);
                if (accountRoleResponse == null)
                {
                    return NotFound();
                }
                return Ok(accountRoleResponse);
            }
            catch (Exception ex)
            {

                return Problem(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAccountRole([FromRoute] int id)
        {
            try
            {
                AccountRoleResponse accountRoleResponse = await _accountRoleService.DeleteAccountRole(id);
                if (accountRoleResponse == null)
                {
                    return NotFound();
                }
                return Ok(accountRoleResponse);
            }
            catch (Exception ex)
            {

                return Problem(ex.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAccountRole([FromRoute] int id, [FromBody] AccountRoleRequest accountRoleRequest)
        {
            try
            {
                AccountRoleResponse accountRoleResponse = await _accountRoleService.UpdateAccountRole(id, accountRoleRequest);
                if (accountRoleResponse == null)
                {
                    return NotFound();
                }
                return Ok(accountRoleResponse);
            }
            catch (Exception ex)
            {

                return Problem(ex.Message);
            }
        }
    }
}
