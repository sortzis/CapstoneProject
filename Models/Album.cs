using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace CapstoneProject.Models
{
    public class Album
    {
        public int ID { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "Artist Names can be up to 100 characters long.")]
        public string Artist { get; set; }

        [Required]
        [StringLength(40, ErrorMessage = "Album Name can be up to 40 characters long.")]
        public string AlbumName { get; set; }

        [Required]
        [StringLength(30, ErrorMessage = "Genre can be up to 30 characters long.")]
        public string Genre { get; set; }

        [Required]
        [Range(0, 2022, ErrorMessage = "Releases Date must be in year format up to 2022.")]
        public int ReleaseDate { get; set; }

        [Required]
        [StringLength(20, ErrorMessage = "Album Status can be up to 20 characters long.")]
        public string AlbumStatus { get; set; }

    }
}
