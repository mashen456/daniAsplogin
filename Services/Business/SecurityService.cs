using MyFirstApp.Models;
using MyFirstApp.Services.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyFirstApp.Services.Business
{
    public class SecurityService
    {
        SecurityDAO daoService = new SecurityDAO();

        public bool Authenticate(UserModel user)
        {
            return daoService.FindByUser(user);
        }

        public bool Register(UserModel user)
        {
            return daoService.RegisterUser(user);
        }


    }
}