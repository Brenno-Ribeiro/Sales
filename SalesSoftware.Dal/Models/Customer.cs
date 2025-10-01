namespace SalesSoftware.Dal.Models;

public class Customer
{

        public int id { get; set; }                
        public string? name { get; set; }          
        public string? cpf { get; set; }           
        public DateTime registration_date { get; set; } 
}
