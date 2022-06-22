namespace PruebaTecnicaWDL.WebApi.Orders
{
    public class PutOrderRequest
    {
        public int Id { get; set; }

        public int EmployeeId { get; set; }

        public int Detail { get; set; }
    }
}