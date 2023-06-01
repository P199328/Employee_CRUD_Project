using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace EmployeeApplication_WinForm
{
    
    public class JWTToken
    {
       
        private static readonly string acesstoken = "8771545378d8dd641b3d03bc7708639d971de73524825367537fcc236c79b8fe";
        public string BearerToken
        {
            get
            {
                return acesstoken;
            }
        }
    }
   
    
    
}

