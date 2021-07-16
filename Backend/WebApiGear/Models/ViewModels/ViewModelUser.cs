using System;

using WebApiGear.Models.Identity;

namespace WebApiUser.Model.ViewModels
{
    public class ViewModelUser
    {
        public Guid Id { get; set; }
        public string DocumentNumber { get; set; }
        public string FirstName { get; set; }        
        public string LastName { get; set; }
        public string Email { get; set; }
        public string ConfirmedEmail { get; set; }
        public string Phone { get; set; }
        public int LocationId { get; set; }
        public string Password { get; set; }
        public string ConfirmedPassword { get; set; }
        public string Address { get; set; }

        public LocationModel Location { get; set; }

        public string Role { get; set; }
    }
}
