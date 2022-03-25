using H3WebshopProeveprojekt.Api.DTO;
using H3WebshopProeveprojekt.Api.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;

namespace H3WebshopProeveprojekt.Api.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class JwtAuthenticationController : ControllerBase
    {

        private readonly IJwtAuthenticationService _jwtAuthenticationService;
        public JwtAuthenticationController(IJwtAuthenticationService jwtAuthenticationService)
        {
            _jwtAuthenticationService = jwtAuthenticationService;
        }

        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> Authenticate([FromBody] AccountRequest account)
        {
            try
            {
                DTO.JwtToken jwtToken = await _jwtAuthenticationService.Authenticate(account);
                if (jwtToken != null)
                {
                    return Ok(jwtToken);
                }
                return Unauthorized();
            }
            catch (Exception ex)
            {

                return Problem(ex.Message);
            }
        }
    }
}
