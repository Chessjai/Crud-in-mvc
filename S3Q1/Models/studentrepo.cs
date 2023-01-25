using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace S3Q1.Models
{
    public class studentrepo : Interface1
    {
        dbcontext db=new dbcontext();
        public studentmodel Create(studentmodel model)
        {  
                try
                {
                    var stud = db.models.Add(new studentmodel()
                    {
                        Name = model.Name,

                        Age = model.Age,

                    });
                    if (db != null && db.SaveChanges() > 0)
                    {

                        model.Id = stud.Id;
                    }
                }
                catch (Exception ex)
                {
                throw;
         
            }
                return model;

            }

        public studentmodel Delete(studentmodel id)
        {
            db.Entry(id).State = EntityState.Deleted;

            int a = db.SaveChanges();
            db.SaveChanges();

            return id;
        }


        public studentmodel Edit(studentmodel model)
        {
            db.Entry(model).State = EntityState.Modified;

            int a = db.SaveChanges();

            return model;

        }

        public studentmodel Read(long id)
        {
            studentmodel models = new studentmodel();

            var stud = db.models.Where(p => p.Id == id).FirstOrDefault();


            return models;

        }

      

        IEnumerable Interface1.ReadAll()
        {
            List<studentmodel> Std = new List<studentmodel>();
            Std = db.models.ToList();
            return Std;
        }
    }
}