using System.ComponentModel.DataAnnotations;

namespace LocationVoiture.ViewModels
{
    public class VoitureAddVM
    {
        [Required]
        public string Matricule { get; set; }

        public int Nbr_portes { get; set; }
        public int Nbr_places { get; set; }
        public string Couleur { get; set; }
        public string Photo_1 { get; set; }

        [Required]
        public int MarqueId { get; set; }
    }
}
