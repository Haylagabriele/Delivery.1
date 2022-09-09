namespace Delivery.Models
{
    public class EntregasModel
    {

        public int Id { get; set; }

        public int NumeroEntrega { get; set; }

        public DateTime DataEntrega { get; set; } = DateTime.Now;

    }

}



