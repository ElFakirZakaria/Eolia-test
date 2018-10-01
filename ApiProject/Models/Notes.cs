using System;
using System.Collections.Generic;

namespace ApiProject.Models
{
    public partial class Notes
    {
        public int NoteId { get; set; }
        public string Matiere { get; set; }
        public double Note { get; set; }
        public int EtudiantId { get; set; }

        public Etudiant Etudiant { get; set; }
    }
}
