using Core.Events;
using SharedKernel;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Entities
{
    public class User : BaseEntity
    {
        public string UserName { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public bool Gender { get; set; }

        public User() { }
        public User(string userName, string fullName, string email, bool gender)
        {
            this.UserName = userName;
            this.FullName = fullName;
            this.Email = email;
            this.Gender = gender;
        }
        public void MarkComplete()
        {
            Events.Add(new UserCompletedEvent(this));
        }
    }
}
