using System;
using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models
{
    public class Producer
    {
        [Key]
        public int Id { get; set; }


		[Display(Name = "Profile Picture Url")]
		public string ProfilePicUrl { get; set; }
		[Display(Name = "FullName")]
		public string FullName { get; set; }
		[Display(Name = "Biography")]
		public string Bio { get; set; }

        //relationship
        public List<Movie> movies { get; set; }

    }
}
