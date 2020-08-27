using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication3.Models;
using WebApplication3.Code;
using WebApplication3.Data;
using Microsoft.AspNetCore.Authorization;

namespace WebApplication3.Controllers
{
    public class EquipmentBagController : Controller
    {
        private readonly ApplicationDbContext _context;

        public EquipmentBagController(ApplicationDbContext context)
        {
            _context = context;
        }

        public EquipmentBag getBag()
        {
            if (HttpContext.Session.Get<EquipmentBag>("EquipmentBag ") == null)
                HttpContext.Session.Set<EquipmentBag>("EquipmentBag ", new EquipmentBag());
            return HttpContext.Session.Get<EquipmentBag>("EquipmentBag ");
        }

        public void UpdateBag(EquipmentBag bag)
        {
            HttpContext.Session.Set<EquipmentBag>("EquipmentBag ", bag);
        }

        public ActionResult AddAparatToEquipmentBag(int id)
        {
            EquipmentBag bag = getBag();
            bool ret = bag.AddAparat(_context.Aparaty.Find(id));
            UpdateBag(bag);
            return RedirectToAction("Index");
        }

        // GET: EquipmentBag   
        [Authorize]
        public ActionResult Index()
        {
            return View(getBag());
        }

        public ActionResult AddObiektywToEquipmentBag(int id)
        {
            EquipmentBag bag = getBag();
            bool ret = bag.AddObiektyw(_context.Obiektywy.Find(id));
            UpdateBag(bag);
            return RedirectToAction("Index");
        }

        // GET: EquipmentBag /Delete/5  
        public ActionResult DeleteAparat(int index)
        {
            var bag = getBag();
            bag.RemoveAparat(index);
            UpdateBag(bag);
            return RedirectToAction("Index");
        }
        public ActionResult DeleteObiektyw(int index)
        {
            var bag = getBag();
            bag.RemoveObiektyw(index);
            UpdateBag(bag);
            return RedirectToAction("Index");
        }
        // GET: EquipmentBag /AddUnit/5 
        public ActionResult AddAparatUnit(int index)
        {
            var bag = getBag();
            bag.AparatyEquippped[index].AparatAmount++;
            UpdateBag(bag);
            return RedirectToAction("Index");
        }
        // GET: EquipmentBag /SubstractUnit/5  
        public ActionResult SubstractAparatUnit(int index)
        {
            var bag = getBag();
            bag.AparatyEquippped[index].AparatAmount--;
            UpdateBag(bag);
            return RedirectToAction("Index");
        }
        // GET: EquipmentBag /AddUnit/5 
        public ActionResult AddObiektywUnit(int index)
        {
            var bag = getBag();
            bag.ObiektywyEquipped[index].ObiektywAmount++;
            UpdateBag(bag);
            return RedirectToAction("Index");
        }
        // GET: EquipmentBag /SubstractUnit/5  
        public ActionResult SubstractObiektywUnit(int index)
        {
            var bag = getBag();
            bag.ObiektywyEquipped[index].ObiektywAmount--;
            UpdateBag(bag);
            return RedirectToAction("Index");
        }

        // delegacja do innego kontrolera wewnątrz akcji  
        public ActionResult AparatDetails(int index)
        {
            var bag = getBag();
            return RedirectToAction("Details", "AparatViewModel", new { id = bag.AparatyEquippped[index].Aparat.Id });
        }
        public ActionResult ObiektywDetails(int index)
        {
            var bag = getBag();
            return RedirectToAction("Details", "ObiektywViewModel", new { id = bag.ObiektywyEquipped[index].Obiektyw.Id });
        }
        public IActionResult Create()
        {
            HashSet<int> ObiektywBagnetList = new HashSet<int>();
            HashSet<int> AparatBagnetList = new HashSet<int>();
            IEnumerable<int> MissingAparatBagnet;
            IEnumerable<int> MissingObiektywBagnet;
            List<String> MissingBagnetNames = new List<string>();

            var bag = getBag();
            foreach (AparatInBag aparat in bag.AparatyEquippped)
            {
                AparatBagnetList.Add(aparat.Aparat.BagnetId);
            }
            foreach (ObiektywtInBag obiektyw in bag.ObiektywyEquipped)
            {
                ObiektywBagnetList.Add(obiektyw.Obiektyw.BagnetId);
            }

            MissingAparatBagnet = ObiektywBagnetList.Except(AparatBagnetList);
            MissingObiektywBagnet = AparatBagnetList.Except(ObiektywBagnetList); 

            if (MissingAparatBagnet.Count() > 0)
            {
                foreach (int index in MissingAparatBagnet)
                {
                    var MissingBagnetTypeList = (from bagnet in _context.Bagnety where bagnet.Id == index select bagnet).ToList();
                    foreach (Bagnet bagnet in MissingBagnetTypeList)
                    {
                        MissingBagnetNames.Add(bagnet.Typ);
                    }
                    ViewBag.MissingCameraMount = $"Your equipment is mismatched on {String.Join(",", MissingBagnetNames)} camera mount";
                }
            }
            else
            {
                ViewBag.MissingCameraMount = null;
            }
            if (MissingObiektywBagnet.Count() > 0)
            {
                foreach (int index in MissingObiektywBagnet)
                {
                    var MissingBagnetTypeList = (from bagnet in _context.Bagnety where bagnet.Id == index select bagnet).ToList();
                    foreach (Bagnet bagnet in MissingBagnetTypeList)
                    {
                        MissingBagnetNames.Add(bagnet.Typ);
                    }
                    ViewBag.MissingLensMount = $"Your equipment is mismatched on {String.Join(",", MissingBagnetNames)} lens mount";
                }
            }
            else
            {
                ViewBag.MissingLensMount = null;
            }


            return View(getBag());
        }
    }
}
