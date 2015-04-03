using System;
using System.ComponentModel.DataAnnotations;
using System.Web;
using FaceLessBook.Domain.Contracts;

namespace FaceLessBook.Domain.Models
{
    public class Friend : IEntity, IEntityKey
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "First Name is required!")]
        [StringLength(50, ErrorMessage = "First Name cannot be more than 50 characters")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Last Name is required!")]
        [StringLength(50, ErrorMessage = "Last Name cannot be more than 50 characters")]
        public string LastName { get; set; }

        //this required for the EF Code first since this will be the FK on the table
        public int UserId { get; set; } 

        public User User { get; set; }

        public string FullName {
            get { return FirstName + " " + LastName; }
        }

        /// <summary>
        /// Using Interface Segregation Principle (ISP) - SOLID design pattern
        /// Our Friend class will have it's own unique Key that is web friendly
        /// </summary>
        public string Key
        {
            get
            {
                if (_key != null) return _key;

                _key = Guid.NewGuid().ToString("D").Substring(24);
                _key = HttpUtility.UrlEncode(_key.Replace(" ", "_").Replace("-", "_").Replace("&", "and"));

                return _key;
            }
            protected set { _key = value; }
        }
        private string _key;
    }
}
