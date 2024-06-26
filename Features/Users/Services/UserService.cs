﻿using System;
using System.Collections.Generic;
using System.Linq;
using DOrderPurches.Features.Auth.Dto;
using OrderPurches.WebApi.Features.Users.Entities;
using OrderPurches.WebApi.Features.Common.Entities;
using OrderPurches.WebApi.Infraestructure;
using Microsoft.Extensions.Configuration;
using OrderPurches.WebApi.Helpers;
//using Sap.Data.Hana;

namespace OrderPurches.WebApi.Features.Users
{
    public class UserService
    {
        private readonly OrderPurchesDbContext _OrderPurchesDbContext;
        private readonly IConfiguration _configuration;
        private readonly HanaDbContext _hanaDbContext;

        public UserService(OrderPurchesDbContext OrderPurchesDbContext, IConfiguration configuration, HanaDbContext hanaDbContext)
        {
            _OrderPurchesDbContext = OrderPurchesDbContext;
            _configuration = configuration;
            _hanaDbContext = hanaDbContext;         
        }

        public List<UserDto> Get()
        {
            var users = _OrderPurchesDbContext.User.ToList();
            var themes = _OrderPurchesDbContext.Theme.ToList();
            var roles = _OrderPurchesDbContext.Role.ToList();

            var result = (from u in users
                          join r in roles on u.RoleId equals r.RoleId into userRole
                          from r in userRole.DefaultIfEmpty()
                          join t in themes on u.ThemeId equals t.ThemeId into themeUser
                          from t in themeUser.DefaultIfEmpty()
                          select new UserDto
                          {
                              Active = u.Active,
                              Email = u.Email,
                              Name = u.Name,
                              Password = null,
                              RoleId = u.RoleId,
                              ThemeId = u.ThemeId,
                              UserId = u.UserId,
                              UserName = u.UserName,
                              Role = r?.Description ??"ROL NO ASIGNADO",
                              Theme = t?.Description ?? "TEMA NO ASIGNADO"
                          }
                          ).ToList();
            return result;
        }

        public List<UserDto> Add(User user)
        {
            user.IsValid();// Valida los campos
            if (string.IsNullOrEmpty(user.Password)) throw new Exception("Debe ingresar una contraseña");
            if (user.Password.Length <8) throw new Exception("Debe ingresar una contraseña que contenga al menos 8 caracteres");
            
            user.Active = true;
            user.Password = Helper.EncryptPassword(user.Password.Trim(), _configuration);
            user.UserName = user.UserName.Trim().ToLower();

            //Agrega campos a la base
            _OrderPurchesDbContext.User.Add(user);
            _OrderPurchesDbContext.SaveChanges(); //asegura que los campos se guarden
            return Get();
        }


        public List<UserDto> Edit(User user)
        {
            user.IsValid();
            if (!string.IsNullOrEmpty(user.Password))
            {
                if (user.Password.Length < 8) throw new Exception("Debe ingresar una contraseña que contenga al menos 8 caracteres");
                user.Password = Helper.EncryptPassword(user.Password.Trim(), _configuration);
            }

            var currentUser = _OrderPurchesDbContext.User.Where(x => x.UserId == user.UserId).FirstOrDefault();
            currentUser.Name = user.Name;
            currentUser.Email = user.Email;
            currentUser.RoleId = user.RoleId;
            currentUser.ThemeId = user.ThemeId;
            currentUser.Active = user.Active;
            currentUser.Password = user.Password;

            _OrderPurchesDbContext.SaveChanges();
            return Get();
        }

        public List<Theme> GetThemes()
        {
            var themes = _OrderPurchesDbContext.Theme.ToList();
            return themes;
        }

        //public List<string> GetSellersSAP()
        //{
        //    List<string> result = new List<string>();
        //    _hanaDbContext.Conn.Open();
        //    string query = $@"SELECT ""SlpName"" FROM ""FERTICA_PRD"".""OSLP"" WHERE ""U_OS_CODIGO"" IS NOT NULL";
        //    HanaCommand selectCmd = new HanaCommand(query, _hanaDbContext.Conn);
        //    HanaDataReader dr = selectCmd.ExecuteReader();
        //    while (dr.Read())
        //    {
        //        string slpName = dr.GetString(0);
        //        result.Add(slpName);
        //    }
        //    dr.Close();
        //    _hanaDbContext.Conn.Close();
        //    return result;
        //}

    }
}
