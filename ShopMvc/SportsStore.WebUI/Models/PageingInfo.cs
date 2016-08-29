using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SportsStore.WebUI.Models
{
    public class PageingInfo
    {
        public int  Totalitem { get; set; }
        public int itemPerPage { get; set; }
        public int currentPage  { get; set; }

        public int TotalPages => (int)Math.Ceiling((decimal) (Totalitem/itemPerPage));
    }
}