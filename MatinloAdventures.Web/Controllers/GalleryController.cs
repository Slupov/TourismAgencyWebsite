using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;

namespace MatinloAdventures.Web.Controllers
{
    public class GalleryController : Controller
    {
        private readonly IHostingEnvironment _hostingEnvironment;

        public GalleryController(IHostingEnvironment hostingEnv)
        {
            _hostingEnvironment = hostingEnv;
        }

        public IActionResult Index()
        {
            List<string> files = Directory.GetFiles(_hostingEnvironment.WebRootPath + "/images/demo/gallery")
                .Where(x=> x.Contains(".jpg"))
                .Select(x=>"../" + x.Substring(x.IndexOf("images/demo", StringComparison.Ordinal)))
                .ToList();
            
            return View(files);
        }
    }
}