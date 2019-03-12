using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication2.Models;

namespace WebApplication2.Controllers
{
    public class IndexController : Controller
    {
        // GET: Index
        ef_PracticeEntities db = new ef_PracticeEntities();

        //数据库增加
        public ActionResult Index6()
        {
            user user = new user() {
                user1 = "abc",
                password = "123"
                
            };
            db.users.Add(user);
            db.SaveChanges();

            return View();
        }
        //数据库删除
        public ActionResult Index7()
        {
            user user = new user()
            {
                user1 = "zyz",
                password = "123"

            };
            //第一种方法
            //db.Entry(user).State = System.Data.Entity.EntityState.Deleted;
            //第二种方法
            db.users.Attach(user);
            db.users.Remove(user);
            db.SaveChanges();

            return View();
        }

        //数据库修改
        public ActionResult Index8()
        {
            user user = new user()
            {
                user1 = "zyz",
                password = "321"

            };
            db.Entry(user).State = System.Data.Entity.EntityState.Deleted;
            db.SaveChanges();

            return View();
        }

        //数据库查询
        public ActionResult Index9()
        {
            user user2 = db.users.Find("zyz");
            List<user> user = db.users.Where(ss=>ss.user1!="").OrderBy(ss=>ss.user1).Skip(1).ToList<user>();

            return View();
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Index10()
        {
            return View();
        }

        //控制器向视图传值
        public ActionResult Index2()
        {
            //ViewBag.name = "abc";
            //ViewData["name2"] = "efg";
            //TempData["name3"] = 1;
            //Reservation class1 = new Reservation()
            //{
            //    user = "xxx",
            //    userID = "444",
            //    password="abc"
            //};

            return View(/*class1*/);
        }

        //Index3和Index4完成分部视图的调用
        public ActionResult Index3()
        {
            return View();
        }
        public ActionResult Index4()
        {
            return PartialView("View");
        }

        //重定向
        public ActionResult Index5()
        {
            return RedirectToAction("Index4", "Index");
        }

        //ajax1
        [HttpPost]
        public JsonResult ajax_try(string i)
        {
            Reservation reservation1 = new Reservation()
            {
                Rsid = 1,
                Name = "张三",
                Phone = 12345678911
            };
            Reservation reservation2 = new Reservation()
            {
                Rsid = 2,
                Name = "李四",
                Phone = 98765432111
            };
            //初始化list中要存放的数组

            List<Reservation> list2 = new List<Reservation>();
            list2.Add(reservation1);
            list2.Add(reservation2);


            JsonClass json = new JsonClass();
            json.code = 200;
            json.dmsg = 1;
           // json.list = list2;



            //Hashtable ht = new Hashtable();
            //ht.Add(1,reservation1);
            //ht.Add(2,reservation2);
            //JsonClass2 json2 = new JsonClass2();
            //json2.code = 300;
            //json2.dmsg = 50;
            //json2.list = ht;


            return Json(new {json,list2 });
        }

        //ajax2
        [HttpPost]
        public JsonResult ajax_try2()
        {
            Reservation Json3 = new Reservation();
            this.TryUpdateModel(Json3);
 
            return Json(new { Json3 });
        }

        //form表单变量传值
        [HttpPost]
        public ActionResult form_try1(string user,string password)
        {            
            return Content(user+password);
        }

        //form类型传值
        [HttpPost]
        public ActionResult form_try2(Reservation sss)
        {
            return Content(/*sss.userID*/"sss");
        }

        //form传值自动更新到类
        [HttpPost]
        public ActionResult form_try3()
        {
            Reservation class1 = new Reservation();
            this.TryUpdateModel(class1);
            return Content(/*class1.user*/"sss");
        }


    }
}