using Microsoft.AspNetCore.Authorization;

namespace BookSocial.Presentation.Admin.Filter
{
    public class CustomizeAuthorizeAttribute : AuthorizeAttribute
    {
        protected override bool AuthorizeCore()
        {
            SymphonyLimitedDBContext db = new SymphonyLimitedDBContext();
            if (httpContext.Session["User"] == null)
            {
                return false;
            }
            // Nếu đăng nhập rồi lấy user ra đăng nhập
            User user = (User)httpContext.Session["User"];
            // Kiểm tra nhóm quyền của user
            GroupUser grUser = db.GroupUser.Find(user.GroupId);
            if (grUser.IsAdmin)
            {
                return true;
            }
            // Nếu không phải nhóm Admin thì đi check quyền , lấy các quyền đã gán
            var grPers = db.GroupPermission.Where(x => x.GroupId == user.GroupId).AsEnumerable();
            // Lấy ra danh sách quyền 
            List<Permission> _permissions = new List<Permission>();
            foreach (var item in grPers)
            {
                _permissions.Add(db.Permission.Find(item.PermissionId));
            }
            // Lấy tên action controller hiện tại 
            // DemoController Action
            string currentPermission = httpContext.Request.RequestContext.RouteData.GetRequiredString("controller") +
                "Controller-" + httpContext.Request.RequestContext.RouteData.GetRequiredString("action");
            if (!_permissions.Any(x => x.Name.Equals(currentPermission)))
            {
                return false;
            }
            return true;
        }

        protected override void HandleUnauthorizedRequest(AuthorizationContext filterContext)
        {
            filterContext.Result = new RedirectResult("/Admin/Auth/UnAuthorize");
        }
    }
}
