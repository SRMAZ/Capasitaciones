using System;
using OrderPurches.WebApi.Features.Users.Entities;

namespace OrderPurches.WebApi.Features.Users.Dto
{
    public class PermissionDto: Permission
    {
        public int RoleId { get; set; }
    }
}
