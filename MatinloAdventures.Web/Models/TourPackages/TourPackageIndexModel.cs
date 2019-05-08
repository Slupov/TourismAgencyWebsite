using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MatinloAdventures.Data.Models;

namespace MatinloAdventures.Web.Models.TourPackages
{
    public class TourPackageIndexModel
    {
        public List<IGrouping<string, MatinloAdventures.Data.Models.TourPackage>> TourPackages { get; set; }
        public List<TourPackageComment> Comments { get; set; }

        public string Username { get; set; }
        public string Email { get; set; }
    }
}
