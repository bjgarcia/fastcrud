using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CrudFast.Data;
using CrudFast.Data.Domain;

namespace CrudFast
{
    public partial class ZipList : System.Web.UI.Page
    {
        private int pageSize = 4;
        private int currentPage = 1;
        
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected IEnumerable<ZipCode> GetZipCodes()
        {
            List<ZipCode> zipcodes = null;

            using (IZipCodeRepository zRepo = new ZipCodeRepository())
            {
                zipcodes = zRepo.Get()
                    .OrderBy(z => z.city)
                    .Skip((currentPage - 1) * pageSize).ToList();
            }
            return zipcodes;
        }
        
        private int GetPageParameter()
        {
            int page;
            string reqValue = (string)RouteData.Values["page"] ?? Request.QueryString["page"];
            return reqValue != null && int.TryParse(reqValue, out page) ? page : 1;
        }
        
        protected int CurrentPage
        {
            get
            {
                int page = GetPageParameter();
                return page > MaxPage ? MaxPage : page;
            }
        }

        protected int MaxPage
        {
            get
            {
                int maxPage = 0;
                using (IZipCodeRepository zRepo = new ZipCodeRepository())
                {
                    maxPage = (int)Math.Ceiling((decimal)zRepo.Get().Count() / pageSize);
                }
                return maxPage; 
            }
        }
    }
}