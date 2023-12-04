namespace WebApplication2.Models
{
    public abstract class ClasseAbstrata
    {
        public int Id { get; set; }
        public string Nome { get; set; }

        public abstract string MetodoAbstrato();
    }

}
