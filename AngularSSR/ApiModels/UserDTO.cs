using Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AngularSSR.ApiModels
{
    public class UserDTO
    {
        public int Id { get; set; }
        [Required]
        public string UserName { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public bool Gender { get; set; }

        public static UserDTO FromUser(User item)
        {
            return new UserDTO()
            {
                UserName = item.UserName,
                FullName = item.FullName,
                Email = item.Email,
                Gender = item.Gender
            };
        }
    }
}
