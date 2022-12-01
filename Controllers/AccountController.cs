using CookieReader.Entities;
using CookieReader.Providers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Primitives;
using Microsoft.Net.Http.Headers;

namespace CookieReader.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class AccountController : Controller
    {
        private List<CookieUser> _cookieUsers = new List<CookieUser>();
        private readonly IUserManager _userManager;

        public AccountController(IUserManager userManager)
        {
            _userManager = userManager;
            for (int i = 0; i < 10; i++)
            {
                _cookieUsers.Add(new CookieUser()
                {
                    Id = new Guid(),
                    Name = $"Nga: {i + 1}"
                });
            }
        }


        [HttpGet]
        [Authorize]
        public IActionResult Profile()
        {
            return Ok(
                this.User.Claims.ToDictionary(
                    x => x.Type, x => x.Value));
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> LoginAsync()
        {
            var user = _cookieUsers[0];
            await _userManager.SignIn(this.HttpContext, user, false);
            return Ok();
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> LogoutAsync()
        {
            await _userManager.SignOut(HttpContext);
            return Ok();
        }

        [HttpGet]
        [AllowAnonymous]
        [Produces("application/json")]
        public IActionResult GetCookie()
        {
            var resp = new HttpResponseMessage();
            this.HttpContext.Response.Cookies.Append("language", "nl-NL");
            this.HttpContext.Response.Headers.Add("xin-chao", "222222");
            //this.HttpContext.Response.Headers.SetCookie = ".AspNetCore.testCookie=CfDJ8H62aWfO13lFuUkg6aEf4dPtJegTciYMuYxote6J6uhG8mbiAcEuQVds_sA15kBvy5yrEyH3ebxoqP6PODiNUs8cqs5v0UtMzqA3k4O0SiCEe1nAZeh6mKp24Qb3XMsBLJGTJggTRIiqf6redy5wK-3amJa5yj46WDPzZ7VszKFqrLY3FHd03Ao2e3UAbwOqEe0fDFkEF_VHMvzlvqPjzhsmQuGuYLr26b9XN9GGjMr8uShNUAVWI1BuqheWgbSs-6DbfrGAdJGe0jfjSj_lzY01oLaiN-V8y57Uel6rmdxWoLn_4EzGECKzF-QShas0i0js1OAGvZdXG5L8NBbL8V39FQ1pK6RR6j4BAZZ4P2g4Hc5P0Rg3wLqfclPG5g-1PVBfzC-JnILsScX-4ukVEfZJ_6GQC2ST5YOmSEOeWoPn2_knRgr0g425ev-MccG6AtPwoMCir1fz2LV7a0In_d8; path=/; secure; samesite=lax; httponly";
            //= new Dictionary<"MEME","SetCookie">();

            return Ok("wwwwwwwwwwww");
        }
    }
}
