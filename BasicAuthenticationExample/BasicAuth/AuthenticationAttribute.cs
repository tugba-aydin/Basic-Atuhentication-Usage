using BasicAuthenticationExample.Data;
using BasicAuthenticationExample.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Linq;
using System.Text;

namespace BasicAuthenticationExample.BasicAuth
{
    public class AuthenticationAttribute : ActionFilterAttribute, IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            var userRepository = context.HttpContext.RequestServices.GetService(typeof(IRepository<User>)) as Repository<User>;
            var userList = userRepository.GetAll();

            var getAuthParams = context.HttpContext.Request.Headers.FirstOrDefault(x => x.Key.Equals("Authorization")).Value;
            if (!String.IsNullOrEmpty(getAuthParams))
            {
                var outBasic = getAuthParams.ToString().Split()[1];
                var base64ByteArr = Convert.FromBase64String(outBasic);
                var userNamePass = Encoding.UTF8.GetString(base64ByteArr); // kullanıcının gönderdiği bilgiler userNamePass değişkenine atanıyor
                var splitted = userNamePass.Split(':');
                for (int i = 0; i < userList.Count; i++)
                {
                    if (splitted[0] != userList[i].UserName || splitted[1] != userList[i].Password)
                        context.Result = new StatusCodeResult(401);
                }
            }
            else
            {
                context.Result = new StatusCodeResult(500);
            }

        }
    }
}
