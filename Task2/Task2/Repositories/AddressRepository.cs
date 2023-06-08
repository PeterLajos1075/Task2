using System.Net;
using Task2.Context;
using Task2.Models;

namespace Task2.Repositories
{
    public class AddressRepository
    {
        private readonly TestDbContext _context;

        public AddressRepository(TestDbContext context)
        {
            _context = context;

            AddressModel modelOne = new AddressModel();
            modelOne.OwnersName = "Lakastos Józsi";
            modelOne.ZipCode = 5431;
            modelOne.City = "Harkány";
            modelOne.Street = "Árnyas utca";
            modelOne.HouseNumber = 13;
            modelOne.DoorNumber = 6;

            AddressModel modelTwo = new AddressModel();
            modelTwo.OwnersName = "Horvát Gábor";
            modelTwo.ZipCode = 7528;
            modelTwo.City = "Pécs";
            modelTwo.Street = "Ajdinger János utca";
            modelTwo.HouseNumber = 5;
            modelTwo.DoorNumber = 20;


            _context.Add(modelOne);
            _context.Add(modelTwo);
            _context.SaveChanges();
        }

        public IEnumerable<AddressModel> GetAll()
        {
            var data = _context.Addresses.ToList();
            return data;
        }
        public AddressModel GetById(int inputId)
        {
            // SELECT TOP(1) FROM Addresses WHERE address.Id == id
            var data = _context.Addresses.FirstOrDefault(a => a.Id == inputId);
            return data;
        }
        public AddressModel Add(AddressModel addressModel)
        { 
            _context.Addresses.Add(addressModel);
            _context.SaveChanges();
            return addressModel;
        }
    }   
}
