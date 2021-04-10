using HDot_Vew.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HDot_Vew.Interface
{
   public interface IDetails
    {
        string insertdata(DetailsModel model);

        IEnumerable<DetailsModel> GetDetails();
        string deletedata(DetailsModel model);
        string editdata(DetailsModel model);
        // string GetDetails();
        string login(LoginModel model);
    }
}
