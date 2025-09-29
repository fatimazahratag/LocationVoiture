using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LocationVoiture.Models
{
    public class Voiture
    {
        public int Id { get; set; }

        [Required]
        public string Matricule { get; set; }

        public int Nbr_portes { get; set; }
        public int Nbr_places { get; set; }
        public string Couleur { get; set; }
        public string Photo_1 { get; set; }

        public int MarqueId { get; set; }

        [ForeignKey("MarqueId")]
        public Marque Marque { get; set; }
    }
}
