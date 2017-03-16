using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Movies.Web.Models
{
    [Table("Cast")]
    public class Cast
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }

        public int? FilmId { get; set; }

        public int? ActorId { get; set; }

        [StringLength(255)]
        public string CharacterName { get; set; }

        public virtual Actor Actor { get; set; }

        public virtual Film Film { get; set; }
    }
}
