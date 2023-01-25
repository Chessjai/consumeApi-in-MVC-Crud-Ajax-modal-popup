using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace S3Q3.Models
{
    public class studentrepos
    {
        dbcontext db = new dbcontext();
        studentmodel std1 = new studentmodel();

        public List<studentmodel> GetAllStd()
        {
            List<studentmodel> Std = new List<studentmodel>();
            Std = db.models.ToList();
            return Std;
        }
        public void Create(studentmodel std)
        {
            DateTime Age = std.dob;
            int j = Age.Year;
            DateTime now = DateTime.Now;
            int k = now.Year;
            int age = k - j;
            std.age = age;
            std.createdon = now;
            std.updateon = now;
            db.models.Add(std);
            db.SaveChanges();
        }
        public studentmodel up(long Id)
        {
            var std = db.models.Where(x => x.id == Id).FirstOrDefault();
            return std;
        }

        public studentmodel Edit(long Id, studentmodel std)
        {
            var model = db.models.FirstOrDefault(x => x.id == Id);
            try
            {

                if (model != null)
                {    
                    model.id= Id;
                    model.name = std.name;
                    model.dob = std.dob;
                    DateTime Age = std.dob;
                    int j = Age.Year;
                    DateTime now = DateTime.Now;
                    int k = now.Year;
                    int age = k - j;
                    model.updateon = now;
                    model.age = age;
                    db.SaveChanges();
                    //db.SaveChanges();

                }
            }
            catch (Exception e)
            {
                //model.errorMessage = e.Message;
                // model.errorStatus = false;
            }
            return std;
        }
    

        public studentmodel FinedById(long id)
        {
            studentmodel student = db.models.Find(id);
            return student;
        }
        public studentmodel Delete(long id)
        {
            studentmodel student = db.models.Find(id);
            studentmodel stud = db.models.Remove(student);
            db.SaveChanges();
            return student;
        }

      
    }
}