using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TopLearn.Core.Services.Interfaces;

namespace TopLearn.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class StoreController : Controller
    {
        private IStoreRepository _storeRepository;
        public StoreController(IStoreRepository storeRepository)
        {
            _storeRepository = storeRepository;
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}