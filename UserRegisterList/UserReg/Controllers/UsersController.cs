using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using UserReg.Models;
using System.Net.Http;
using Microsoft.Extensions.Options;

namespace UserReg.Controllers
{
    public class UsersController : Controller
    {
        private AppSettings _AppSettings { get; set; }

        public UsersController(IOptions<AppSettings> appsetting)
        {
            _AppSettings = appsetting.Value;
        }
        public IActionResult Index()
        {
            Users objUsers = new Users();
            List<DayList> objList = new List<DayList>();

            for (int i = 1; i < 4; i++)
            {
                DayList objDay = new DayList();
                objDay.Day = "Day " + i;
                objDay.IsChecked = false;
                objList.Add(objDay);
            }

            objUsers.DayListCheckBox = objList;

            return View(objUsers);
        }


        [HttpPost, ActionName("Create")]
        public IActionResult AddUser(Users objUsers)
        {
            //string sDateReg = Request.Form["txtDateReg"];

            List<string> objList = objUsers.DayListCheckBox.Where(x => x.IsChecked).Select(x => x.Day).ToList();

            foreach (string objItem in objList)
            {
                if (string.IsNullOrEmpty(objUsers.SelectedDays))
                {
                    objUsers.SelectedDays = objItem;
                }
                else {
                    objUsers.SelectedDays += " ," + objItem;
                }
            }
            
            var objClient = new HttpClient();

            string sUri = _AppSettings.ApiUri; 

            objClient.BaseAddress = new Uri(sUri);
            var objData = objClient.PostAsJsonAsync($"api/user/AddUser", objUsers).Result;

            if (objData.IsSuccessStatusCode)
                return RedirectToAction("GetUserList");
            else
                return NotFound();
            
        }

        [HttpGet]
        public IActionResult GetUserList()
        {
            List<Users> objUsers = new List<Users>();

            var objClient = new HttpClient();

            string sUri = _AppSettings.ApiUri; 

            objClient.BaseAddress = new Uri(sUri);
            var objData = objClient.GetAsync($"api/user/GetUserList").Result;

            if (objData.IsSuccessStatusCode)
                objUsers = objData.Content.ReadAsAsync<List<Users>>().Result;

            return View(objUsers);
        }
    }
}