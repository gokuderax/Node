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

        public void delete(String url)
        {

            try
            {
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
                request.Method = "DELETE";
                //request.Method = WebRequestMethods.Http.Post;
               
                //request.Headers.Add("x-access-token", this.newUser.Token);

                //request.Headers.Add("nifcif", nuevoUsuario.nifcif);
                request.ContentType = "aplication/json";

                HttpWebResponse response = (HttpWebResponse)request.GetResponse(); //response es un json
                StreamReader sr = new StreamReader(response.GetResponseStream(), Encoding.UTF8);
                String cadena = sr.ReadToEnd();
                MessageBox.Show(cadena);
            }
            catch (WebException exceptionWEB_GET)
            {

                MessageBox.Show(exceptionWEB_GET.Message + ". :( (usuarios)");

            }
            catch (Exception exceptionGET)
            {
                MessageBox.Show("exception al hacer get: (usuarios)" + exceptionGET.Message);

            }
        }

        public List<User> putUser(User user,string url)
        {
              try{
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url); // + (WebUtility.UrlEncode(JsonConvert.SerializeObject(txtNombre.ToString()))));
                request.Method = WebRequestMethods.Http.Put; //post for post, duh
                request.ContentType = "application/json; charset=UTF-8";
                request.Accept = "application/json"; 
                string userJson = JsonConvert.SerializeObject(user);

                    using (var streamWriter = new StreamWriter(request.GetRequestStream()))
                    {
                        string json = JsonConvert.SerializeObject(user);

                        streamWriter.Write(json);
                        streamWriter.Flush();
                        streamWriter.Close();
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
        public List<User> getUser(string url)
        {
            try
            {
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url); // + (WebUtility.UrlEncode(JsonConvert.SerializeObject(txtNombre.ToString()))));
                request.Method = WebRequestMethods.Http.Get; //post for post, duh
                request.ContentType = "application/json; charset=UTF-8";
                request.Accept = "application/json";
                //string userJson = JsonConvert.SerializeObject(user);
                HttpWebResponse response = (HttpWebResponse)request.GetResponse(); //response es un json
                StreamReader sr = new StreamReader(response.GetResponseStream(), Encoding.UTF8);
                String cadena = sr.ReadToEnd();
                List<User> userRecib = JsonConvert.DeserializeObject<List<User>>(cadena);
                MessageBox.Show(userRecib[0].ToString());
                return userRecib;
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
        public List<User> postUser(User user, string url,bool login)
        {
                try{
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url); // + (WebUtility.UrlEncode(JsonConvert.SerializeObject(txtNombre.ToString()))));
                request.Method = WebRequestMethods.Http.Post; //post for post, duh
                request.ContentType = "application/json; charset=UTF-8";
                request.Accept = "application/json"; 
                string userJson = JsonConvert.SerializeObject(user);
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




        public List<Shop> postShop(Shop Shop, string url)
        {
            try
            {
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url); // + (WebUtility.UrlEncode(JsonConvert.SerializeObject(txtNombre.ToString()))));
                request.Method = WebRequestMethods.Http.Post; //post for post, duh
                request.ContentType = "application/json; charset=UTF-8";
                request.Accept = "application/json";
                string userJson = JsonConvert.SerializeObject(Shop);
                    using (var streamWriter = new StreamWriter(request.GetRequestStream()))
                    {
                        string json = JsonConvert.SerializeObject(Shop);

                        streamWriter.Write(json);
                        streamWriter.Flush();
                        streamWriter.Close();
                    }

                HttpWebResponse response = (HttpWebResponse)request.GetResponse(); //response es un json
                StreamReader sr = new StreamReader(response.GetResponseStream(), Encoding.UTF8);
                String cadena = sr.ReadToEnd();
                List<Shop> shopRecib = JsonConvert.DeserializeObject<List<Shop>>(cadena);
                return shopRecib;
  

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

        public List<Shop> getShop(string url)
        {
            try
            {
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url); // + (WebUtility.UrlEncode(JsonConvert.SerializeObject(txtNombre.ToString()))));
                request.Method = WebRequestMethods.Http.Get; //post for post, duh
                request.ContentType = "application/json; charset=UTF-8";
                request.Accept = "application/json";
                //string userJson = JsonConvert.SerializeObject(user);
                HttpWebResponse response = (HttpWebResponse)request.GetResponse(); //response es un json
                StreamReader sr = new StreamReader(response.GetResponseStream(), Encoding.UTF8);
                String cadena = sr.ReadToEnd();
                List<Shop> shopRecib = JsonConvert.DeserializeObject<List<Shop>>(cadena);
                return shopRecib;
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
        public void deleteShop(String url)
        {

            try
            {
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
                request.Method = "DELETE";
                //request.Method = WebRequestMethods.Http.Post;

                //request.Headers.Add("x-access-token", this.newUser.Token);

                //request.Headers.Add("nifcif", nuevoUsuario.nifcif);
                request.ContentType = "aplication/json";

                HttpWebResponse response = (HttpWebResponse)request.GetResponse(); //response es un json
                StreamReader sr = new StreamReader(response.GetResponseStream(), Encoding.UTF8);
                String cadena = sr.ReadToEnd();
                MessageBox.Show(cadena);
            }
            catch (WebException exceptionWEB_GET)
            {

                MessageBox.Show(exceptionWEB_GET.Message + ". :( (usuarios)");

            }
            catch (Exception exceptionGET)
            {
                MessageBox.Show("exception al hacer get: (usuarios)" + exceptionGET.Message);

            }
        }

        public List<Shop> putShop(Shop shop, string url)
        {
            try
            {
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url); // + (WebUtility.UrlEncode(JsonConvert.SerializeObject(txtNombre.ToString()))));
                request.Method = WebRequestMethods.Http.Put; //post for post, duh
                request.ContentType = "application/json; charset=UTF-8";
                request.Accept = "application/json";
                string userJson = JsonConvert.SerializeObject(shop);

                using (var streamWriter = new StreamWriter(request.GetRequestStream()))
                {
                    string json = JsonConvert.SerializeObject(shop);

                    streamWriter.Write(json);
                    streamWriter.Flush();
                    streamWriter.Close();
                }

                HttpWebResponse response = (HttpWebResponse)request.GetResponse(); //response es un json
                StreamReader sr = new StreamReader(response.GetResponseStream(), Encoding.UTF8);
                String cadena = sr.ReadToEnd();
                List<Shop> shopRecib = JsonConvert.DeserializeObject<List<Shop>>(cadena);
                return shopRecib;
       
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


        public List<Product> postProduct(Product producto, string url)
        {
            try
            {
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url); // + (WebUtility.UrlEncode(JsonConvert.SerializeObject(txtNombre.ToString()))));
                request.Method = WebRequestMethods.Http.Post; //post for post, duh
                request.ContentType = "application/json; charset=UTF-8";
                request.Accept = "application/json";
                string userJson = JsonConvert.SerializeObject(producto);
                using (var streamWriter = new StreamWriter(request.GetRequestStream()))
                {
                    string json = JsonConvert.SerializeObject(producto);

                    streamWriter.Write(json);
                    streamWriter.Flush();
                    streamWriter.Close();
                }

                HttpWebResponse response = (HttpWebResponse)request.GetResponse(); //response es un json
                StreamReader sr = new StreamReader(response.GetResponseStream(), Encoding.UTF8);
                String cadena = sr.ReadToEnd();
                List<Product> productRecib = JsonConvert.DeserializeObject<List<Product>>(cadena);
                return productRecib;


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

        public List<Product> getProduct(string url)
        {
            try
            {
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url); // + (WebUtility.UrlEncode(JsonConvert.SerializeObject(txtNombre.ToString()))));
                request.Method = WebRequestMethods.Http.Get; //post for post, duh
                request.ContentType = "application/json; charset=UTF-8";
                request.Accept = "application/json";
                //string userJson = JsonConvert.SerializeObject(user);
                HttpWebResponse response = (HttpWebResponse)request.GetResponse(); //response es un json
                StreamReader sr = new StreamReader(response.GetResponseStream(), Encoding.UTF8);
                String cadena = sr.ReadToEnd();
                List<Product> productRecib = JsonConvert.DeserializeObject<List<Product>>(cadena);
                return productRecib;
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

        public List<Product> putProduct(Product product, string url)
        {
            try
            {
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url); // + (WebUtility.UrlEncode(JsonConvert.SerializeObject(txtNombre.ToString()))));
                request.Method = WebRequestMethods.Http.Put; //post for post, duh
                request.ContentType = "application/json; charset=UTF-8";
                request.Accept = "application/json";
                string userJson = JsonConvert.SerializeObject(product);

                using (var streamWriter = new StreamWriter(request.GetRequestStream()))
                {
                    string json = JsonConvert.SerializeObject(product);

                    streamWriter.Write(json);
                    streamWriter.Flush();
                    streamWriter.Close();
                }

                HttpWebResponse response = (HttpWebResponse)request.GetResponse(); //response es un json
                StreamReader sr = new StreamReader(response.GetResponseStream(), Encoding.UTF8);
                String cadena = sr.ReadToEnd();
                List<Product> productRecib = JsonConvert.DeserializeObject<List<Product>>(cadena);
                return productRecib;

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
