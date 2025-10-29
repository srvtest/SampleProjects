
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using System.Net;
using System.Net.Http;
using EntityLayer;
using System.Data;
using DataLayer;

namespace RestaurantManagement.Controllers
{
    public class sysdiagramsController : Controller
    {
        // GET: sysdiagrams	 
        public ActionResult Index()
        {
            return View();
        }


        public ActionResult sysdiagrams()
        {
            try
            {
                IEnumerable<sysdiagrams> sysdiagramslist = null;
                DataTable dtsysdiagrams = new DataTable();
                sysdiagramsDL objsysdiagramsDL = new sysdiagramsDL();
                DataSet ds = objsysdiagramsDL.Getsysdiagrams();


                sysdiagramslist = ds.Tables[0].AsEnumerable().Select(x => new sysdiagrams
                {
                    name = x.Field<String>("name"),
                    principal_id = x.Field<Int32>("principal_id"),
                    diagram_id = x.Field<Int32>("diagram_id"),
                    version = x.Field<Int32>("version"),
                    definition = x.Field<Byte[]>("definition")
                });

                return View(sysdiagramslist);
            }
            catch (Exception ex)
            {
                TempData["error"] = ex.Message;
            }
            return View();
        }

        [HttpDelete]
        public ActionResult sysdiagrams(int? id)
        {
            try
            {
                sysdiagramsDL objsysdiagramsDL = new sysdiagramsDL();
                objsysdiagramsDL.Deletesysdiagrams(Convert.ToInt32(id));
                return RedirectToAction("sysdiagrams");
            }
            catch (Exception ex)
            {
                TempData["error"] = ex.Message;
            }
            return View();
        }


        public ActionResult Addsysdiagrams(int? id)
        {
            ViewBag.Title = "Add sysdiagrams";
            sysdiagrams objsysdiagramsModels = new sysdiagrams();
            if (id != null)
            {
                ViewBag.Title = "Edit sysdiagrams";
                try
                {
                    DataTable dtsysdiagrams = new DataTable();
                    sysdiagramsDL objsysdiagramsDL = new sysdiagramsDL();
                    DataSet ds = objsysdiagramsDL.GetsysdiagramsById(Convert.ToInt32(id));
                    dtsysdiagrams = ds.Tables[0];

                    if (dtsysdiagrams.Rows.Count > 0)
                    {
                        // sysdiagrams objsysdiagramsModels = new sysdiagrams();
                        objsysdiagramsModels.name = Convert.ToString(dtsysdiagrams.Rows[0]["name"]);
                        objsysdiagramsModels.principal_id = Convert.ToInt32(dtsysdiagrams.Rows[0]["principal_id"]);
                        objsysdiagramsModels.diagram_id = Convert.ToInt32(dtsysdiagrams.Rows[0]["diagram_id"]);
                        objsysdiagramsModels.version = Convert.ToInt32(dtsysdiagrams.Rows[0]["version"]);
                        objsysdiagramsModels.definition = Convert.ToByte(dtsysdiagrams.Rows[0]["definition"]);	 
                        return View(objsysdiagramsModels);
                    }
                }
                catch (Exception ex)
                {
                    TempData["error"] = ex.Message;
                }
            }
            return View(objsysdiagramsModels);
        }

        [HttpPost]
        [ValidateInput(true)]
        [ValidateAntiForgeryToken]
        public ActionResult Addsysdiagrams(sysdiagrams objsysdiagramsModel, int? id)
        {
            ViewBag.Title = "Add sysdiagrams";

            if (ModelState.IsValid)
            {
                try
                {
                    //objsysdiagramsModel.sysdiagramsID = 1;	 
                    objsysdiagramsModel.CityID = Convert.ToInt32(id);
                    sysdiagramsDL objsysdiagramsDL = new sysdiagramsDL();
                    if (id != null)
                    {
                        ViewBag.Title = "Edit sysdiagrams";
                        objsysdiagramsDL.Updatesysdiagrams(objsysdiagramsModel);
                        TempData["success"] = "Congratulations! sysdiagrams Updated Successfully";
                    }
                    else
                    {
                        objsysdiagramsDL.Addsysdiagrams(objsysdiagramsModel);
                        TempData["success"] = "Congratulations! sysdiagrams Created Successfully";
                        ModelState.Clear();
                        return View(new sysdiagrams());
                    }
                }
                catch (Exception ex)
                {
                    TempData["error"] = ex.Message;
                }
                return View(objsysdiagramsModel);
            }
            else
            {
                return View(objsysdiagramsModel);
            }
        }
    }
}