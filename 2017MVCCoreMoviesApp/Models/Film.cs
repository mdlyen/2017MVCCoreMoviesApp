using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Movies.Web.Models
{
    [Table("Film")]
    public sealed class Film
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Film()
        {
            Casts = new HashSet<Cast>();
        }

        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }

        [StringLength(255)]
        [Required]
        public string Title { get; set; }

        public DateTime? ReleaseDate { get; set; }

        public int? DirectorId { get; set; }

        public int? LanguageId { get; set; }

        public int? CountryId { get; set; }

        public int? StudioId { get; set; }

        public string Synopsis { get; set; }

        public int? RunTimeMinutes { get; set; }

        public int? CertificateId { get; set; }

        public int? BudgetDollars { get; set; }

        public int? BoxOfficeDollars { get; set; }

        public int? OscarNominations { get; set; }

        public int? OscarWins { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public ICollection<Cast> Casts { get; set; }

        public Director Director { get; set; }

        public Certificate Certificate { get; set; }

        public Country Country { get; set; }

        public Language Language { get; set; }

        public Studio Studio { get; set; }
    }
}
