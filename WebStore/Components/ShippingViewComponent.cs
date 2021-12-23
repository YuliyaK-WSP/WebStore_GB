using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.AspNetCore.Mvc;
using WebStore.Services.Interfaces;
using System.Threading.Tasks;

namespace WebStore.Components
{
    public class ShippingViewComponent:ViewComponent
    {
        public IViewComponentResult Invoke() => View();
    }
}
