﻿using Beginners_CRUD_EvtApi.Interfaces;
using Beginners_CRUD_EvtApi.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using web_api_crud_tutorial.Models;

namespace Beginners_CRUD_EvtApi.Controllers
{
    [Route("api/GetToken")]
    [ApiController]
    public class TokenController : ControllerBase
    {
        private readonly IJwtTokenManager _tokenManager;
        public TokenController(IJwtTokenManager jwtTokenManager)
        {
            _tokenManager = jwtTokenManager;
        }
        [AllowAnonymous]
        [HttpPost]
        public IActionResult Authenticate(string userName, string password)
        {
            var stringToken = _tokenManager.Authenticate(userName, password);
            if (string.IsNullOrEmpty(stringToken))
                return Unauthorized();
            var token = new TokenModel(stringToken);
            return Ok(token);
        }

        [AllowAnonymous]
        [HttpPost("WhithoutExpiration")]
        public IActionResult AuthenticateWhithoutExpiration(string userName, string password)
        {
            var stringToken = _tokenManager.AuthenticateWhithoutExpiration(userName, password);
            if (string.IsNullOrEmpty(stringToken))
                return Unauthorized();
            var token = new TokenWEModel(stringToken);
            return Ok(token);
        }

    }
}
