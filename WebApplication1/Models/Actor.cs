using System;
using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models
{
    public class Actor
    {
        [Key]
        public int Id { get; set; }


        [Required(ErrorMessage = "Profile Picture Is Required")]
        [Display(Name = "Profile Picture Url")]
        public string ProfilePicUrl { get; set; }

        [Required(ErrorMessage = "Full Name Is Required")]
		[Display(Name = "Full Name")]
        [StringLength(50, MinimumLength = 4, ErrorMessage = "Full Name Must Be Betweeen 4-50 Characters")]
		public string FullName { get; set; }

		[Required(ErrorMessage = "Biography Is Required")]
		[Display(Name = "Biography")]
		public string Bio { get; set; }

        //relationships
		public List<Actor_Movie>? Actor_Movies { get; set; }
	}
}
