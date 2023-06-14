using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking.Internal;
using System.Net;
using System.Runtime.CompilerServices;
using Task2.Context;
using Task2.Models;

namespace Task2.Repositories
{
    //Implementing the CRUD operations
    //https://learn.microsoft.com/en-us/iis-administration/api/crud

    public class AddressRepository : ICrud<AddressModel>
    {
        private readonly TestDbContext _context;

        public AddressRepository(TestDbContext context)
        {
            _context = context;
        }

        #region Old CodeBase

        //public IEnumerable<AddressModel> Read()
        //{
        //    var data = _context.Addresses.ToList();
        //    return data;
        //}

        //public void Put(int id, AddressModel model)
        //{
        //    try
        //    {  
        //        var data = _context.Addresses.Find(id);
        //        _context.SaveChanges();
        //    }
        //    catch (DbUpdateConcurrencyException) when (!Exists(id))
        //    {
        //        throw;
        //    }
        //}

        //private AddressModel NotFound()
        //{
        //    throw new NotImplementedException();
        //}

        //public AddressModel GetById(int inputId)
        //{
        //    // SELECT TOP(1) FROM Addresses WHERE address.Id == id
        //    var data = _context.Addresses.FirstOrDefault(a => a.Id == inputId);
        //    return data;
        //}
        //public AddressModel Add(AddressModel addressModel)
        //{
        //    _context.Addresses.Add(addressModel);
        //    _context.SaveChanges();
        //    return addressModel;
        //}

        //public void AddTestData()
        //{
        //    AddressModel modelOne = new AddressModel();
        //    modelOne.OwnersName = "Lakastos Józsi";
        //    modelOne.ZipCode = 5431;
        //    modelOne.City = "Harkány";
        //    modelOne.Street = "Árnyas utca";
        //    modelOne.HouseNumber = 13;
        //    modelOne.DoorNumber = 6;

        //    AddressModel modelTwo = new AddressModel();
        //    modelTwo.OwnersName = "Horvát Gábor";
        //    modelTwo.ZipCode = 7528;
        //    modelTwo.City = "Pécs";
        //    modelTwo.Street = "Ajdinger János utca";
        //    modelTwo.HouseNumber = 5;
        //    modelTwo.DoorNumber = 20;

        //    _context.Add(modelOne);
        //    _context.Add(modelTwo);
        //    _context.SaveChanges();
        //}
        //public AddressModel Delete(int id)
        //{
        //    var data = _context.Addresses.FirstOrDefault(a => a.Id == id);
        //    if (data == null)
        //    {
        //        return null;
        //    }
        //    _context.Addresses.Remove(data);
        //    _context.SaveChanges();
        //    return data;
        //}
        //public bool Exists(int id)
        //{
        //    return _context.Addresses.Any(a => a.Id == id);
        //}

        #endregion

        public void Create(AddressModel entity)
        {
            _context.Addresses.Add(entity);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var data = _context.Addresses.Where(s => s.Id == id).FirstOrDefault();

            _context.Addresses.Remove(data); //commit or not
            _context.SaveChanges();
        }
        public List<AddressModel> Read() => _context.Addresses.ToList();
        public List<AddressModel> ReadById(int id) => _context.Addresses.Where(c => c.Id == id).ToList();

        public void Update(int id, AddressModel entity)
        {
            var data = _context.Addresses.Where(a => a.Id == id).FirstOrDefault();
            if (data != null)
            {
                _context.Attach(entity);
                _context.SaveChanges();
            }
        }
    }
}

