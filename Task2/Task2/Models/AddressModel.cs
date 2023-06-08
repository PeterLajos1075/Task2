using System.ComponentModel.DataAnnotations;

namespace Task2.Models
{
    public class AddressModel
    {
        [Key]
        public int Id { get; set;}
        public string? OwnersName { get; set;}
        public int ZipCode { get; set;}
        public string? City { get; set;}
        public string? Street { get; set;}
        public int HouseNumber { get; set;}
        public int DoorNumber { get; set;}
        
    }
}
