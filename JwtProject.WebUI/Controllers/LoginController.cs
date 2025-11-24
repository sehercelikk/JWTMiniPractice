using JwtProject.Business.Abstract.UserService;
using JwtProject.Dto.Concrete.UserDtos;
using Microsoft.AspNetCore.Mvc;

namespace JwtProject.WebUI.Controllers;

public class LoginController(IUserService _userService) : Controller
{
    public IActionResult Index()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Index(LoginDto model)
    {
        await _userService.LoginAsync(model);
        return RedirectToAction("Index", "Token", new { area = "Admin" ,email=model.Email}
    );
    }
}
