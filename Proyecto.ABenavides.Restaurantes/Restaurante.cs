namespace Proyecto.Modelos
{
    public class Restaurante
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public int Estrellas { get; set; }
        public string Especialidad { get; set; }
        public string Ciudad { get; set; }
        public string Direccion { get; set; }

        // Relación 1-Restaurante => *-Platos 
        public List<Plato>? Platos { get; set; }
    }
}