using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using FaceLessBook.Domain.Contracts;

namespace FaceLessBook.Domain.Models
{
    public class User : IEntity
    {
        [Key]
        public int Id { get; set; }
        
        [Required(ErrorMessage = "User Name is required!")]
        [StringLength(50, ErrorMessage = "User Name should have at least 5 characters and 50 maximum", MinimumLength = 5)]
        public string UserName { get; set; }

        //public string FirstName { get; set; }
        //public string LastName { get; set; }

        public string EmailAddress { get; set; }

        /// <summary>
        /// virtual - support for EF lazy loading
        /// </summary>
        public virtual IList<Friend> Friends { get; set; }

        public User()
        {
            Friends = new List<Friend>();
        }
    }
}
