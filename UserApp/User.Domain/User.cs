namespace User.Domain
{
    using System.ComponentModel.DataAnnotations;

    public class User
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(250, ErrorMessage = "only 250 word is allowed")]
        public string FirstName { get; set; }

        [Required]
        [MaxLength(250, ErrorMessage = "only 250 word is allowed")]
        public string LastName { get; set; }

        [Required]
        [EmailAddress(ErrorMessage = "Please enter valid email address")]
        [MaxLength(250, ErrorMessage = "only 250 word is allowed")]
        public string Email { get; set; }

        public int? Age { get; set; }
    }
}