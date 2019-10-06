using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace HelloWord.Controllers
{
    public class CalculatorController : Controller
    {
        // GET: /<controller>/
        public IActionResult Index()
        {
            return View();
        }
        public ActionResult Calculate(double a = 0, double b = 0, char op = '+')
        {
            ViewBag.a = a;
            ViewBag.b = b;
            ViewBag.op = op;
            switch (op)
            {
                case '+':
                    ViewBag.KetQua = a + b;
                    break;
                case '-':
                    ViewBag.KetQua = a - b;
                    break;
                case 'x':
                    ViewBag.KetQua = a * b;
                    break;
                case ':':
                    ViewBag.KetQua = a / b;
                    break;
            }
            return View("Index");
        }

    }
}
