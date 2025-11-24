using JwtProject.Business.Abstract.UserService;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace JwtProject.WebUI.Areas.Admin.Controllers;

[Area("Admin")]
public class UserController(IUserService _userService) : Controller
{
    public async Task<IActionResult> Index()
    {
        var result = await _userService.GetAllAsync();
        return View(result);
    }

    public async Task<IActionResult> GetUserRole(int id)
    {
        var result= await _userService.GetByIdAsync(id);
        return View(result);
    }
}
