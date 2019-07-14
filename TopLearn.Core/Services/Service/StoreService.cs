using System;
using System.Collections.Generic;
using System.Text;
using TopLearn.Core.Services.Interfaces;
using TopLearn.DataLayer.Context;
using TopLearn.DataLayer.Entities.Stores;
using TopLearn.ViewModel.StoreVIewModel;

namespace TopLearn.Core.Services.Service
{
    public class StoreRepository : IStoreRepository
    {
        private TopLearnContext _context;

        public StoreRepository(TopLearnContext context)
        {
            _context = context;
        }
        public void InsertProvinceList(List<string> provinceList)
        {
            
            Province province = new Province();
            int id = 1;
            foreach (var item in provinceList)
            {
                province.ProvinceID = id;
                province.ProvinceName = item;
                _context.Provinces.Add(province);
                _context.SaveChanges();
                id++;
            }
        }
    }
}
