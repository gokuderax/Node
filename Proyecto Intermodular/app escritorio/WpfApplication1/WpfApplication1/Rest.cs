using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace App_Escritorio
{
    class Rest
    {
        private String token;
        public List<User> postUser(User user, string url,bool login)
        {
                try{
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url); // + (WebUtility.UrlEncode(JsonConvert.SerializeObject(txtNombre.ToString()))));
                request.Method = WebRequestMethods.Http.Post; //post for post, duh
                request.ContentType = "application/json; charset=UTF-8";
                request.Accept = "application/json"; string userJson = JsonConvert.SerializeObject(user);
                if (login == false)
                {
                    using (var streamWriter = new StreamWriter(request.GetRequestStream()))
                    {
                        string json = JsonConvert.SerializeObject(user);

                        streamWriter.Write(json);
                        streamWriter.Flush();
                        streamWriter.Close();
                    }
                }   
                else
                {
                    request.Headers.Set("username", user.email);
                    request.Headers.Set("password1", user.password);
                }
                    HttpWebResponse response = (HttpWebResponse)request.GetResponse(); //response es un json
                    StreamReader sr = new StreamReader(response.GetResponseStream(), Encoding.UTF8);
                    String cadena = sr.ReadToEnd();
                    List<User> userRecib = JsonConvert.DeserializeObject<List<User>>(cadena);
                    MessageBox.Show(userRecib[0].ToString());

                    if (cadena.Contains("rro") || cadena.Contains("Not"))
                        return userRecib;
                    else 
                    {
                        MessageBox.Show(userRecib[0].apellido1.ToString());
                        token = cadena;
                        return userRecib;
                    }
            
            }
            catch (WebException exceptionWEB_GET)
            {
                  MessageBox.Show(exceptionWEB_GET.Message.ToString());
                  return null;
            }
            catch (Exception exceptionGET)
            {
                MessageBox.Show(exceptionGET.Message);
                return null;
            }
        }


    }
}
