using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;

public class LoginStatusViewComponent : ViewComponent
{
    public IViewComponentResult Invoke()
    {
        // Lấy thông tin username từ Session
        var username = HttpContext.Session.GetString("UserName");

        return View("Default", username);
    }
}
