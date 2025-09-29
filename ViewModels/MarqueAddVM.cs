using System.ComponentModel.DataAnnotations;

namespace LocationVoiture.ViewModels
{
    public class MarqueAddVM
    {
        [Required]
        public string Libelle { get; set; }
    }
}
