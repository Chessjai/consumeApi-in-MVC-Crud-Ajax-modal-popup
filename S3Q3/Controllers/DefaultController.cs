using S3Q3.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace S3Q3.Controllers
{
    public class DefaultController : ApiController
    {
        dbcontext db = new dbcontext();
        studentrepos model = new studentrepos();
        [HttpGet]
        [Route("~/api/Default/GetAllStudents")]
        public IHttpActionResult GetAllStudents()
        {

            var data = model.GetAllStd();
            return Ok(data);
        }
        [HttpGet]
        [Route("~/api/Default/getid")]
        public IHttpActionResult getid(long id)
        {

            var data = model.FinedById(id);
            return Ok(data);
        }
        [HttpPost]
        [Route("~/api/Default/Create")]
        public IHttpActionResult Create(studentmodel std)
        {


            model.Create(std);
            return Ok();

        }
        //[HttpGet]
        ////[Route("~/api/default/Update")]
        //public IHttpActionResult Edit(long id)
        //{
        //    var std1 = model.update(id);
        //    return Ok(std1);
        //}
        //[HttpPost]
        //[Route("~/api/Default/Edit")]
        //public IHttpActionResult Edit(studentmodel student)
        //{
        //    student = model.update(student);
        //    return Ok();
        //}


        [HttpGet]
        public IHttpActionResult Update(long Id)
        {
            var std1 = model.up(Id);
            return Ok();
        }

        [HttpPut]
        [Route("~/api/default/Update")]
        public IHttpActionResult Update(studentmodel std)
        {
            model.Edit(std.id, std);
            return Ok();
        }
        [HttpDelete]
        [Route("~/api/Default/Delete")]
        public IHttpActionResult Delete(long id)
        {
            studentrepos model = new studentrepos();
            //var std = db.StudentModels.Where(x => x.Id == id).FirstOrDefault();
            model.Delete(id);
            return Ok();
        }

    }
}
