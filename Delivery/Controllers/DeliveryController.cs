using Delivery.Data;
using Delivery.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Delivery.Controllers
{
    public class DeliveryController : Controller
    {
        readonly private ApplicationDbContext _db;
        public DeliveryController(ApplicationDbContext db)
        {
            _db = db;

        }
        public IActionResult Index()

        {
            IEnumerable<EntregasModel> entregas = _db.Entregas;

            return View(entregas);
        }
    }
}
