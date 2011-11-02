using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagingSorting.Web.Models;
using System.Text;

namespace PagingSorting.Web.Controllers
{
    public class BaseController : Controller
    {
        //
        // GET: /Base/
        public IQueryable<People> PeopleList { get; set; }
        public const int PageSize = 20;


        public BaseController()
        {
            PeopleList = InitPeopleList();
        }

        private IQueryable<People> InitPeopleList()
        {
            List<People> list = new List<People>();
            Random random = new Random();
            for (int i = 0; i < 500; i++)
            {
                list.Add(new People { Username = BuildString(8), Id = i, Age = random.Next(0, 100) });
            }
            return list.AsQueryable();
        }

        private string BuildString(int size)
        {
            StringBuilder builder = new StringBuilder();
            Random random = new Random();
            char ch;
            for (int i = 0; i < size; i++)
            {
                ch = Convert.ToChar(Convert.ToInt32(Math.Floor(26 * random.NextDouble() + 65)));
                builder.Append(ch);
            }
            return builder.ToString();
        }

    }
}
