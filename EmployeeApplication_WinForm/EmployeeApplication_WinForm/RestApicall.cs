using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace EmployeeApplication_WinForm
{
    public static class RestApicall
    {
        public static readonly string baseurl = "https://gorest.co.in/public/v2/users";
        public static readonly string acesstoken = "8771545378d8dd641b3d03bc7708639d971de73524825367537fcc236c79b8fe";
        public static string EmpJson(string jsonStr)
        {
            JToken json = JToken.Parse(jsonStr);
            return json.ToString(Newtonsoft.Json.Formatting.Indented);

        }

        //[HttpGet]
        public static async Task<string>GetAll()
        {
            using (HttpClient client=new HttpClient())
            {
                //client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", acesstoken);
                using (HttpResponseMessage res=await client.GetAsync(baseurl+ ""))
                {
                    using (HttpContent content = res.Content)
                    {
                        var data = await content.ReadAsStringAsync();
                       
                        if (data!=null)
                        {
                             return data;   
                        }
                    }
                }
            }
      
           return string.Empty;
        }

        //[GetById]
        public static async Task<String> GetById(string id)
        {
            using (HttpClient client = new HttpClient())
            {
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", acesstoken);
                using (HttpResponseMessage res = await client.GetAsync(baseurl + "?id=" + id))
                {
                    using (HttpContent content = res.Content)
                    {
                        string data = await content.ReadAsStringAsync();
                        if (data != null)
                        {
                            return data;
                        }
                    }
                }
            }
            return string.Empty;
        }
        //[HttpPost]
            public static async Task<String>AddEmployee(string name, string email, string gender, string status)
            {
                var inputdata =new Dictionary<string, string>
                {
                    {"name",name},
                    {"email",email},
                    {"gender",gender},
                    {"status",status}

                };
                var input = new FormUrlEncodedContent(inputdata);

                using (HttpClient client = new HttpClient())
                {
               
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", acesstoken);
                    using (HttpResponseMessage res = await client.PostAsync(baseurl + "" ,input))
                    {
                        using (HttpContent content = res.Content)
                        {
                            string data = await content.ReadAsStringAsync();
                            if (data != null)
                            {
                                return data;
                            }
                        }
                    }
                }
                return string.Empty;
        }
        //[HttpPut]
        public static async Task<String> UpdateEmployee(string id,string name, string email, string gender, string status)
        {
            var inputdata = new Dictionary<string, string>
                {
                    {"name",name},
                    {"email",email},
                    {"gender",gender},
                    {"status",status}

                };
            var input = new FormUrlEncodedContent(inputdata);

            using (HttpClient client = new HttpClient())
            {
                
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", acesstoken);
                using (HttpResponseMessage res = await client.PutAsync(baseurl + "/" + id, input))
                {
                    using (HttpContent content = res.Content)
                    {
                        string data = await content.ReadAsStringAsync();
                        if (data != null)
                        {
                            return data;
                        }
                    }
                }
            }
            return string.Empty;
        }
        //[HttpDelete]
        public static async Task<String> DeleteEmployee(string id)
        {
            using (HttpClient client = new HttpClient())
            {
              
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", acesstoken);
                using (HttpResponseMessage res = await client.DeleteAsync(baseurl + "/" + id))
                {
                    using (HttpContent content = res.Content)
                    {
                        MessageBox.Show(res.StatusCode.ToString());
                        string data = await content.ReadAsStringAsync();
                        if (data != null)
                        {
                            return data;
                           
                        }
                    }
                }
            }
            return string.Empty;
            
        }

    }
}
