using System.Collections.Generic;

namespace EfData.Entities
{
    public class Owner
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        
        public List<Apartment> Apartments { get; set; }

        public Owner()
        {
            Apartments = new List<Apartment>();
        }
    }
}