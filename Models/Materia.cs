using System.ComponentModel.DataAnnotations.Schema;

namespace BackEndMobile.Models
{
    [Table("Materias")]
    public class Materia : BaseEntity
    {
        public string Nome { get; set; }

        public decimal NotaPeriodoLetivo { get; set; }


        public ICollection<Nota> Notas { get; set; }

    }
}
