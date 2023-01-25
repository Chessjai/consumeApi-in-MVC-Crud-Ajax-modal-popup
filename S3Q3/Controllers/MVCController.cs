using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;
using S3Q3.Models;
using Newtonsoft.Json;

namespace S3Q3.Controllers
{
    public class MVCController : Controller
    {
        dbcontext db = new dbcontext();
        HttpClient client = new HttpClient();
        public ActionResult Index()
        {
            List<studentmodel> EmpInfo = new List<studentmodel>();

            client.BaseAddress = new Uri("https://localhost:44312/api/Default/GetAllStudents");
            client.DefaultRequestHeaders.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            var response = client.GetAsync("GetAllStudents");
            response.Wait();
            var test = response.Result;
            if (test.IsSuccessStatusCode)
            {
                var disply = test.Content.ReadAsStringAsync().Result;
                
                EmpInfo = JsonConvert.DeserializeObject<List<studentmodel>>(disply);
            }
            ViewBag.std = EmpInfo;
            return View();

        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(studentmodel std)
        {
            client.BaseAddress = new Uri("https://localhost:44312/api/default/Create");
            var response = client.PostAsJsonAsync("Create", std);
            response.Wait();
            var test = response.Result;
            if (test.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View("Index");

        }

        //public JsonResult Details(int id)
        //{

        //    Student s = null;
        //    client.BaseAddress = new Uri("https://localhost:44302/api/default/Details?Id=");
        //    var response = client.GetAsync("Details?Id=" + id.ToString());
        //    response.Wait();
        //    var test = response.Result;
        //    if (test.IsSuccessStatusCode)
        //    {
        //        var dis = test.Content.ReadAsAsync<Student>();
        //        dis.Wait();
        //        s = dis.Result;
        //    }
        // 

        //    return Json(s, JsonRequestBehavior.AllowGet);
        //}
        [HttpGet]
        public JsonResult Details(long Id)
        {
            studentmodel s = null;

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:44312/api/default/getid");
                //HTTP GET
                var responseTask = client.GetAsync("getid?id=" + Id.ToString());
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<studentmodel>();
                    readTask.Wait();
                    s = readTask.Result;
                }
                s.created_on2 = s.createdon.ToString();
                   s.update_on2 = s.updateon.ToString();
                   s.DOB1 = s.dob.ToString();
            }

            return Json(s,JsonRequestBehavior.AllowGet);
        }

        public ActionResult Delete(long Id)
        {

            var std = db.models.Where(x => x.id == Id).FirstOrDefault();
            return View(std);

        }
        [HttpPost]
        public ActionResult Delete(long id, studentmodel std)
        {

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:44312/api/default/Delete");
                //HTTP GET
                var responseTask = client.DeleteAsync("Delete?id=" + id.ToString());
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }
            }

            return View("Index");
        }
        [HttpGet]
        public JsonResult EditEmployee(long Id)
        {

            studentmodel s = null;
            client.BaseAddress = new Uri("https://localhost:44312/api/default/getid");
            var response = client.GetAsync("getid?id=" + Id.ToString());
            response.Wait();
            var test = response.Result;
            if (test.IsSuccessStatusCode)
            {
                var dis = test.Content.ReadAsAsync<studentmodel>();
                dis.Wait();
                s = dis.Result;
            }
            return Json(s, JsonRequestBehavior.AllowGet);
        }



        [HttpPost]
        public ActionResult Edit(studentmodel std, long Id=0)
        {

            studentmodel s = null;
            client.BaseAddress = new Uri("https://localhost:44312/api/default/Update");
            client.DefaultRequestHeaders.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            var response = client.PutAsJsonAsync<studentmodel>("Update", std);
            response.Wait();
            var test = response.Result;
            if (test.IsSuccessStatusCode)
            {
                var dis = test.Content.ReadAsAsync<studentmodel>();
                dis.Wait();
                s = dis.Result;
            }
            return RedirectToAction("Index");

        }

        //    [HttpGet]
        //public JsonResult Edit(long id)
        //{
        //    var std = db.models.Where(x => x.id == id).FirstOrDefault();
        //    return Json(std, JsonRequestBehavior.AllowGet);

        //}
        //[HttpPost]
        //public JsonResult Edit(int id, studentmodel std)
        //{
        //    using (var client = new HttpClient())
        //    {
        //        client.BaseAddress = new Uri("https://localhost:44312/api/default/Edit");
        //        //HTTP GET
        //        var responseTask = client.PutAsJsonAsync<studentmodel>("Update", std);
        //        responseTask.Wait();

        //        var result = responseTask.Result;
        //        if (result.IsSuccessStatusCode)
        //        {
        //            return Json("Index");
        //        }
        //    }

        //    return Json(std, JsonRequestBehavior.AllowGet);
        //}


    }
}