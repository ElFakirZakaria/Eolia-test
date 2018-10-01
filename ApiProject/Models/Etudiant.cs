using System;
using System.Collections.Generic;

namespace ApiProject.Models
{
    public partial class Etudiant
    {
        public Etudiant()
        {
            Notes = new HashSet<Notes>();
        }

        public int EtudiantId { get; set; }
        public string Nom { get; set; }
        public string Prenom { get; set; }
        public string Email { get; set; }
        public DateTime DateNaiss { get; set; }

        public ICollection<Notes> Notes { get; set; }
    }
}
