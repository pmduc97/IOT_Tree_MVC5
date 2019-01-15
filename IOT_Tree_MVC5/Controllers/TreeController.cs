using IOT_Tree_MVC5.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Text.RegularExpressions;
using System.IO;
using System.Diagnostics;

namespace IOT_Tree_MVC5.Controllers
{
    public class TreeController : Controller
    {
        private DatabaseFunction databaseFunc = new DatabaseFunction();
        private TableFunction tableFunc = new TableFunction();
        private TreeFunction treeFunc = new TreeFunction();
        private LoginData loginData = null;


        // GET: Danh sách database
        public ActionResult Index()
        {
            if (Session["admin"] == null)
            {
                return RedirectToAction("Login");
            }
            loginData = (LoginData)Session["admin"];
            List<DatabaseItem> listDatabaseItem = databaseFunc.getAllDatabase(loginData);
            return View(listDatabaseItem);
        }

        //POST: Tạo database
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(string databaseName)
        {
            if (Session["admin"] == null)
            {
                return RedirectToAction("Login");
            }
            loginData = (LoginData)Session["admin"];
            List<DatabaseItem> listDatabaseItem;
            if (string.IsNullOrEmpty(databaseName))
            {
                ViewBag.Messenger = "Tên database không được rỗng";
                listDatabaseItem = databaseFunc.getAllDatabase(loginData);
                return View(listDatabaseItem);
            }
            if (!Regex.IsMatch(databaseName, "^[a-zA-Z_][a-zA-Z0-9_]*$"))
            {
                ViewBag.Messenger = "Tên database không hợp lệ";
                listDatabaseItem = databaseFunc.getAllDatabase(loginData);
                return View(listDatabaseItem);
            }
            string Messenger = databaseFunc.createDatabase(loginData, databaseName);
            ViewBag.Messenger = Messenger;
            listDatabaseItem = databaseFunc.getAllDatabase(loginData);
            return View(listDatabaseItem);
        }

        /// <summary>
        /// GET Login
        /// </summary>
        /// <returns></returns>
        public ActionResult Login()
        {
            return View();
        }

        /// <summary>
        /// POST Login
        /// </summary>
        /// <param name="server"></param>
        /// <param name="port"></param>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult Login(string server, string port, string username, string password)
        {
            if (string.IsNullOrEmpty(server) || string.IsNullOrEmpty(port) || string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                ViewBag.Messengerr = "Thông tin nhập vào không đầy đủ";
                return View();
            }
            loginData = new LoginData(server, port, username, password);
            ConnectSQL connectSQL = new ConnectSQL();
            string result = connectSQL.Login(loginData);

            if (result.Equals("OK"))
            {
                Session["admin"] = loginData;
                return RedirectToAction("Index");
            }
            ViewBag.Messengerr = result;
            return View();
        }

        // List Table From DatabaseName
        public ActionResult Table(string database)
        {
            if (Session["admin"] == null)
            {
                return RedirectToAction("Login");
            }
            loginData = (LoginData)Session["admin"];
            List<TableItem> listTableItem;
            if (string.IsNullOrEmpty(database) || Regex.IsMatch(database, "^[a-zA-Z_][a-zA-Z0-9_]*$") == false)
            {
                return RedirectToAction("Index");
            }
            ViewBag.DatabaseName = database;
            listTableItem = listTableItem = tableFunc.getAllTableFromDatabase(loginData, database);
            return View(listTableItem);
        }

        //POST: Tạo table
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Table(string database, string table)
        {
            if (Session["admin"] == null)
            {
                return RedirectToAction("Login");
            }
            loginData = (LoginData)Session["admin"];
            List<TableItem> listTableItem;
            if (string.IsNullOrEmpty(database) || Regex.IsMatch(database, "^[a-zA-Z_][a-zA-Z0-9_]*$") == false)
            {
                return RedirectToAction("Index");
            }
            if (string.IsNullOrEmpty(table))
            {
                ViewBag.Messenger = "Tên table không được trống";
                ViewBag.DatabaseName = database;
                listTableItem = listTableItem = tableFunc.getAllTableFromDatabase(loginData, database);
                return View(listTableItem);
            }
            if (Regex.IsMatch(table, "^[a-zA-Z_][a-zA-Z0-9_]*$") == false)
            {
                ViewBag.Messenger = "Tên table không hợp lệ";
                ViewBag.DatabaseName = database;
                listTableItem = listTableItem = tableFunc.getAllTableFromDatabase(loginData, database);
                return View(listTableItem);
            }
            string msg = tableFunc.createTable(loginData, database, table);

            ViewBag.DatabaseName = database;
            listTableItem = listTableItem = tableFunc.getAllTableFromDatabase(loginData, database);
            ViewBag.Messenger = msg;
            return View(listTableItem);
        }

        //GET: Import Data
        public ActionResult ImportData(string database, string table)
        {
            if (Session["admin"] == null)
            {
                return RedirectToAction("Login");
            }
            if (string.IsNullOrEmpty(database) || Regex.IsMatch(database, "^[a-zA-Z_][a-zA-Z0-9_]*$") == false || string.IsNullOrEmpty(table) || Regex.IsMatch(table, "^[a-zA-Z_][a-zA-Z0-9_]*$") == false)
            {
                return RedirectToAction("Index");
            }
            ViewBag.Database = database;
            ViewBag.Table = table;
            return View();
        }

        //POST: Update File and Import
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ImportData(string database, string table, HttpPostedFileBase link)
        {
            if (Session["admin"] == null)
            {
                return RedirectToAction("Login");
            }
            if (string.IsNullOrEmpty(database) || Regex.IsMatch(database, "^[a-zA-Z_][a-zA-Z0-9_]*$") == false || string.IsNullOrEmpty(table) || Regex.IsMatch(table, "^[a-zA-Z_][a-zA-Z0-9_]*$") == false)
            {
                return RedirectToAction("Index");
            }
            if (link == null || link.ContentLength == 0)
            {
                ViewBag.Database = database;
                ViewBag.Table = table;
                ViewBag.Messenger = "File không hợp lệ";
                return View();
            }

            // extract only the filename
            var fileName = Path.GetFileName(link.FileName);
            int vitri = fileName.LastIndexOf('.');
            string duoiFile = fileName.Substring(vitri);
            fileName = fileName.Substring(0, vitri);
            fileName += "_" + DateTime.Now.ToString("yyyy-MM-dd_HH-mm-ss") + duoiFile;
            // store the file inside ~/App_Data/uploads folder
            var path = Path.Combine(Server.MapPath("~/App_Data/uploads"), fileName);
            link.SaveAs(path);
            string fullJson = tableFunc.readAllTextFromFile(Server.MapPath(@"~/App_Data/uploads/" + fileName));

            List<TreeItem> listTreeBL = tableFunc.jsonToObject(fullJson);

            loginData = (LoginData)Session["admin"];
            var watch = Stopwatch.StartNew();
            // the code that you want to measure comes here
            int rowInsert = tableFunc.insertDataToTable(loginData, database, table, listTreeBL);
            watch.Stop();
            var elapsedMs = watch.ElapsedMilliseconds;

            ViewBag.Row = rowInsert;
            ViewBag.Time = elapsedMs;

            ViewBag.Messenger = "ImportData thành công";
            ViewBag.Database = database;
            ViewBag.Table = table;
            return View();
        }

        //GET: Get Data
        public ActionResult GetData(string database, string table)
        {
            if (Session["admin"] == null)
            {
                return RedirectToAction("Login");
            }
            if (string.IsNullOrEmpty(database) || Regex.IsMatch(database, "^[a-zA-Z_][a-zA-Z0-9_]*$") == false || string.IsNullOrEmpty(table) || Regex.IsMatch(table, "^[a-zA-Z_][a-zA-Z0-9_]*$") == false)
            {
                return RedirectToAction("Index");
            }

            ViewBag.Database = database;
            ViewBag.Table = table;
            return View();
        }


        //POST: GetHinhVuong
        [HttpPost]
        [ValidateInput(false)]
        public JsonResult GetHinhVuong(string databaseName, string tableName, string lat, string lng, string banKinh)
        {
            if (Session["admin"] == null)
            {
                return Json(new
                {
                    code = -1
                });
            }
            if (string.IsNullOrEmpty(databaseName) || string.IsNullOrEmpty(tableName) || string.IsNullOrEmpty(lat) || string.IsNullOrEmpty(lng) || string.IsNullOrEmpty(banKinh))
            {
                return Json(new
                {
                    code = -2
                });
            }

            double Lat = 0;
            double Lng = 0;
            double BanKinh = 0;

            if (lat.Contains(',') || lng.Contains(',') || banKinh.Contains(','))
            {
                Debug.WriteLine("Lỗi dấu , ");
                return Json(new
                {
                    code = -101
                });
            }
            try
            {
                Lat = double.Parse(lat);
                Lng = double.Parse(lng);
                BanKinh = double.Parse(banKinh);
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Loi: " + ex.Message);
                return Json(new
                {
                    code = -101
                });
            }

            if (BanKinh == 0)
            {
                BanKinh = 0.00001;
            }

            loginData = (LoginData)Session["admin"];

            PointItem point = new PointItem(Lat, Lng);

            List<TreeLite> listItem = treeFunc.getHinhVuong(loginData, databaseName, tableName, point, BanKinh);
            var jsonResult = Json(new { lat = lat, lng = lng, data = listItem });
            jsonResult.MaxJsonLength = int.MaxValue;
            return jsonResult;
        }

        //POST: GetHinhTron
        [HttpPost]
        [ValidateInput(false)]
        public JsonResult GetHinhTron(string databaseName, string tableName, string lat, string lng, string banKinh)
        {
            if (Session["admin"] == null)
            {
                return Json(new
                {
                    code = -1
                });
            }
            if (string.IsNullOrEmpty(databaseName) || string.IsNullOrEmpty(tableName) || string.IsNullOrEmpty(lat) || string.IsNullOrEmpty(lng) || string.IsNullOrEmpty(banKinh))
            {
                return Json(new
                {
                    code = -2
                });
            }
            if (lat.Contains(',') || lng.Contains(',') || banKinh.Contains(','))
            {
                Debug.WriteLine("Loi dấu , ");
                return Json(new
                {
                    code = -101
                });
            }
            double Lat = 0;
            double Lng = 0;
            double BanKinh = 0;
            try
            {
                Lat = double.Parse(lat);
                Lng = double.Parse(lng);
                BanKinh = double.Parse(banKinh);
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Loi: " + ex.Message);
                return Json(new
                {
                    code = -101
                });
            }

            if (BanKinh == 0)
            {
                BanKinh = 0.00001;
            }

            loginData = (LoginData)Session["admin"];

            PointItem point = new PointItem(Lat, Lng);

            List<TreeLite> listItem = treeFunc.getHinhTron(loginData, databaseName, tableName, point, BanKinh);

            var jsonResult = Json(new { lat = lat, lng = lng, data = listItem });
            jsonResult.MaxJsonLength = int.MaxValue;
            return jsonResult;
        }
    }
}