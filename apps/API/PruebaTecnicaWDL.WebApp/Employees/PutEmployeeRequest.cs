namespace PruebaTecnicaWDL.WebApi.Employees
{
    public class PutEmployeeRequest
    {
        public int Id { get;  set; }

        public string Name { get; set; }

        public string LastName { get;  set; }

        public string Date { get;  set; }

        public string CellPhone { get;  set; }
    }
}
