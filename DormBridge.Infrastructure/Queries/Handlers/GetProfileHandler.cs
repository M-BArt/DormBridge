using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Azure.Core;
using DormBridge.Application.Abstractions;
using DormBridge.Application.DTOs.User;
using DormBridge.Application.Queries;
using DormBridge.Infrastructure.DAL;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json.Linq;

namespace DormBridge.Infrastructure.Queries.Handlers
{
    internal class GetProfileHandler : IQueryHandler<NullQuery<UserDto>, UserDto>
    {
        private readonly DormBridgeDbContext _dbContext;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public GetProfileHandler(DormBridgeDbContext dbContext, IHttpContextAccessor httpContextAccessor)
        {
            _dbContext = dbContext;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<UserDto?> HandleAsyncAction(NullQuery<UserDto> query)
        {

            //var authHeader = _httpContextAccessor.HttpContext.Request.Headers["Authorization"].ToString();
            //if (authHeader != null && authHeader.StartsWith("Bearer"))
            //{
            //    var token = authHeader.Substring("Bearer ".Length).Trim();
            //    return Ok(new { Token = token });
            //}

            var token = _httpContextAccessor.HttpContext.Session.GetString("JWToken");

            JwtSecurityTokenHandler tokenHandler = new();
            JwtSecurityToken decryptedToken = tokenHandler.ReadJwtToken(token);

            string userId = decryptedToken.Claims.First(c => c.Type == ClaimTypes.NameIdentifier).Value;
            //string userRole = decryptedToken.Claims.First(c => c.Type == ClaimTypes.Role).Value;

            var user = await _dbContext.Users
                .Where(u => u.UserGuid.ToString() == userId)
                .Select(u => new UserDto
                {
                    UserGuid = u.UserGuid,
                    Username = u.Username,
                    Email = u.Email,
                }).FirstOrDefaultAsync();
            return user;
        }
    }
}
