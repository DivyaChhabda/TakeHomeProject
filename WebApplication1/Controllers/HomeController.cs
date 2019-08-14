using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.ViewModel;
using WebApplication1.Models;
using System.Data.Entity;
using System.Data.Entity.Validation;

namespace WebApplication1.Controllers
{
    public class HomeController : Controller
    {


        vmcEntities2 db = new vmcEntities2();
        public ActionResult Index()
        {
            var vehicledetail = db.tbl_vehicle.Include(c=>c.tbl_vehicletype).ToList();
                var vehicletype = db.tbl_vehicletype.ToList();
                SelectList list = new SelectList(vehicletype, "ID", "Vehicle_type_name");
                ViewBag.Vehicletype = list;
                return View(vehicledetail);
            
                
        }
     
        //tbl_vehicletype tv
        public ActionResult CreateVehicle(tbl_vehicletype tv)
      {
            VehicleViewModel vm = new VehicleViewModel
            {
                tblvehicle = new tbl_vehicle(),
                tblehicletype = tv,
                tblcar = new tbl_Car(),
                tblbike = new tbl_bike()

            };
            ViewBag.Vehiclename = tv.Vehicle_type_name;
            if (tv.ID == 1)
            {
                List<VehicleBodyType> items = new List<VehicleBodyType>()
                {
                    new VehicleBodyType() {text="Hatchback",Body_type="Hatchback" },
                     new VehicleBodyType() {text="Sedan",Body_type="Sedan" }
                };
            ViewBag.Body_type = new SelectList(items, "text", "Body_type");
        }
            
            if(tv.ID == 2)
            {
                List<string> items = new List<string>();
                items.Add("Kick");
                items.Add("Self");
                ViewBag.Type_of_start = items;
            }
            
            return View(vm);
        }
       public ActionResult SaveVehicle(VehicleViewModel vm)
        {
            int vehicleid = vm.tblehicletype.ID;
            vm.tblvehicle.Vehicle_type_id = vehicleid;
            try
            {
                db.tbl_vehicle.Add(vm.tblvehicle);
                db.SaveChanges();
            }
           
                catch (DbEntityValidationException e)
            {
                foreach (var eve in e.EntityValidationErrors)
                {
                    Console.WriteLine("Entity of type \"{0}\" in state \"{1}\" has the following validation errors:",
                        eve.Entry.Entity.GetType().Name, eve.Entry.State);
                    foreach (var ve in eve.ValidationErrors)
                    {
                        Console.WriteLine("- Property: \"{0}\", Error: \"{1}\"",
                            ve.PropertyName, ve.ErrorMessage);
                    }
                }
                throw;
            }
        
            int vid = vm.tblvehicle.ID;
            if (vm.tblehicletype.ID == 1)
            {
                vm.tblcar.Vehicle_id = vid;
                db.tbl_Car.Add(vm.tblcar);
                db.SaveChanges();
            }
            else if(vm.tblehicletype.ID==2)
            {
                vm.tblbike.Vehicle_id = vid;
                db.tbl_bike.Add(vm.tblbike);
                db.SaveChanges();
            }
            TempData["successmsg"] = "Saved Successfully";
            return RedirectToAction("Index", "Home");
        }
      
    }
}