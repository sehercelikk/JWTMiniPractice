using JwtProject.Business.Abstract.TokenService;
using JwtProject.Business.Abstract.UserService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages;

namespace JwtProject.WebUI.Areas.Admin.Controllers;

[Area("Admin")]
//[Authorize]
public class TokenController : Controller
{
    private readonly IUserService _userService;
    private readonly ITokenService _tokenService;

    public TokenController(IUserService userService, ITokenService tokenService)
    {
        _userService = userService;
        _tokenService = tokenService;
    }

    public IActionResult Index(string email)
    {
        if (string.IsNullOrEmpty(email))
        {
            TempData["Message"] = "Önce giriş yapın!";
            return RedirectToAction("/Login/Index");
        }
        ViewBag.Email = email;  // kime token oluşturulacak
        return View();
    }


    [HttpPost]
    public async Task<IActionResult> TokenGenerate(string email)
    {
        var user = await _userService.GetByEmailAsync(email);
        var token = _tokenService.CreateToken(user);
        ViewBag.Email = email;
        return View("Index", token);
    }
}
