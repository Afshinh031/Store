using System;
using System.Collections.Generic;
using System.Text;
using TopLearn.ViewModel.StoreVIewModel;

namespace TopLearn.Core.Services.Interfaces
{
    public interface IStoreRepository
    {
        void InsertProvinceList(List<string> provinceList);
    }
}
