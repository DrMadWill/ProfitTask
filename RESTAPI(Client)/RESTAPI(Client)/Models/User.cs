using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RESTAPI_Client_.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }

        [StringLength(255,MinimumLength =3,ErrorMessage ="Max Length 255 Min Length 3")]
        [Required]
        public string  Name { get; set; }

        [StringLength(255, MinimumLength = 3, ErrorMessage = "Max Length 255 Min Length 3")]
        [Required]
        public string UserName { get; set; }
            
        [DataType(DataType.EmailAddress)]
        [Required(ErrorMessage = "Email is required.")]
        [MaxLength(100, ErrorMessage = "Max Length is 100")]
        [RegularExpression(@"^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$", ErrorMessage = "Email format not valid.")]
        public string Email { get; set; }

        [MaxLength(23)]
        [Required]
        public string Phone { get; set; }
        public IList<Post> Posts { get; set; }
    }
}
