using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiProject.Models
{
    public partial class Notes
    {
        public int NoteId { get; set; }
        public string Matiere { get; set; }
        public double Note { get; set; }
        public int EtudiantId { get; set; }
        [ForeignKey("EtudiantId")]
        public Etudiant Etudiant { get; set; }
    }
}
