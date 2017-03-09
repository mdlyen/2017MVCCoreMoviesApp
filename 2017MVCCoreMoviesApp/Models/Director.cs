using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Movies.Web.Models
{
    [Table("Director")]
    public partial class Director
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }

        [StringLength(255)]
        public string FullName { get; set; }

        public DateTime? Dob { get; set; }

        [StringLength(1)]
        public string Gender { get; set; }
    }
}
