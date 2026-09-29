using Authen.API.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Authen.API.Controllers
{
    public class AccountController : ApiController
    {

        private readonly IAccountServices _accountServices;

        public AccountController(IAccountServices accountServices)
        {
            _accountServices = accountServices;
        }


        [HttpPost]
        public IHttpActionResult Register(UserModel userModel) 
        {

            try
            {

                if (userModel != null)
                {

                   bool result =
                        _accountServices.Register(userModel);
                    return Ok(result);


                }
                else 
                {

                    return BadRequest("usermodel cannot be zero!");
                }
            }
            catch (Exception ex) 
            {

                return InternalServerError(ex);
            }
        }


        [HttpPut]
        public IHttpActionResult Authenticate(LoginRequestModel loginRequestModel) 
        {

            try
            {
                if (ModelState.IsValid)
                {

                    UserModel user =
                         _accountServices.Login(loginRequestModel.Email, loginRequestModel.Password);
                    if (user != null)
                    {

                        //return Ok(user);
                        string token = JwtTokenHelper.GenerateToken(user.Email,user.RoleName);
                        return Ok(token);
                    }
                    else
                    {
                        return Unauthorized();
                    }

                }
                else 
                {

                    return BadRequest();
                }
            }
            catch (Exception ex) 
            {

                return InternalServerError();
            }
           
        }



    }
}
