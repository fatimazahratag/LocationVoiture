using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LocationVoiture.Models
{
    public class Marque
    {
        public int Id { get; set; }
        public string Libelle { get; set; }
        public ICollection<Voiture> Voitures { get; set; }

    }
}
