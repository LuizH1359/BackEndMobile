namespace BackEndMobile.Models
{
    public class Nota : BaseEntity
    {
        public decimal Resultado { get; set; }

        public Materia Materia { get; set; }

        
    }
}
