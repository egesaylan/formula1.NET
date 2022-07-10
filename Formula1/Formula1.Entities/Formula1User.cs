using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Formula1.Entities
{
    [Table("Formula1Users")]
    public class Formula1User : MyEntityBase
    {
        [StringLength(25)]
        public string Name { get; set; }//Name
        [StringLength(25)]
        public string Surname { get; set; }//Surname
        [Required,StringLength(25)]
        public string Username { get; set; }//Username
        [Required, StringLength(70)]
        public string Email { get; set; }//Email
        [Required, StringLength(25)]
        public string Password { get; set; }//Password
        [StringLength(30)]
        public string PP { get; set; } //Profile Picture
        public bool IsActive { get; set; }//If the profile' active status
        [Required]
        public Guid ActivateGuid { get; set; }
        public bool IsAdmin { get; set; }

        public virtual List<Note> Notes { get; set; }
        public virtual List<Comment> Comments { get; set; }
        public virtual List<Liked> Likes { get; set; }
    }
}
