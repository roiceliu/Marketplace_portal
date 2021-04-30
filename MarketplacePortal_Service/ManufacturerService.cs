﻿using MarketplacePortal_DAL;
using MarketplacePortal_Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace MarketplacePortal_Service
{
    public interface IManufacturerService
    {
        IEnumerable<tblManufacturer> GetAllTblManufacturer();
        tblManufacturer GetAll();

    }
    class ManufacturerService : IManufacturerService
    {
        UnitOfWork uow = new UnitOfWork();


        public IEnumerable<tblManufacturer> GetAllTblManufacturer()
        {
            IRepository<tblManufacturer> manuRepo = uow.ManufacturerRepository;
            return manuRepo.GetAll();
        }

        public tblManufacturer GetAll()
        {
            throw new NotImplementedException();
        }

        public void Save()
        {

            uow.Save();
        }
    }
}
