using JwtProject.Business.Abstract.UserService;
using JwtProject.Dto.Concrete.UserDtos;
using Microsoft.AspNetCore.Mvc;

namespace JwtProject.WebUI.Controllers;

public class RegisterController(IUserService _userService) : Controller
{
    public IActionResult Index()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Index(RegisterUserDto model)
    {
        await _userService.CreateAsync(model);
        return RedirectToAction("/Login/Index");
    }
}
