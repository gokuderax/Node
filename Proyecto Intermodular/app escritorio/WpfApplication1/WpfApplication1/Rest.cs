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
        public string login(User user, string url)
        {
            try
            {
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url); // + (WebUtility.UrlEncode(JsonConvert.SerializeObject(txtNombre.ToString()))));
                request.Method = WebRequestMethods.Http.Post; //post for post, duh
                request.ContentType = "application/json; charset=UTF-8";
                request.Accept = "application/json";
                string userJson = JsonConvert.SerializeObject(user);

                request.Headers.Set("email", user.email);
                request.Headers.Set("password", user.password);
                HttpWebResponse response = (HttpWebResponse)request.GetResponse(); //response es un json
                StreamReader sr = new StreamReader(response.GetResponseStream(), Encoding.UTF8);
                String cadena = sr.ReadToEnd();

                if (cadena.Contains("rro") || cadena.Contains("Not"))
                    return cadena;
                else
                {
                    token = cadena;
                    return cadena;
                }
            }
            catch (WebException exceptionWEB_GET)
            {
                MessageBox.Show(exceptionWEB_GET.Message.ToString());
                return exceptionWEB_GET.Message.ToString();
            }
            catch (Exception exceptionGET)
            {
                MessageBox.Show(exceptionGET.Message);
                return exceptionGET.Message;
            }
        }
        public void delete(String url)
        {

            try
            {
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
                request.Method = "DELETE";
                //request.Method = WebRequestMethods.Http.Post;
               
                request.Headers.Set("x-access-token",token);

                //request.Headers.Set("nifcif", nuevoUsuario.nifcif);
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
                request.Headers.Set("x-access-token", token);
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
                MessageBox.Show(token);
                request.Headers.Set("x-access-token", token);
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
                request.Headers.Set("x-access-token", token);
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
                    MessageBox.Show(cadena.ToString());
                    return userRecib;

            }
            catch (WebException exceptionWEB_GET)
            {

               StreamReader sr = new StreamReader(exceptionWEB_GET.Response.GetResponseStream(), Encoding.UTF8);
                String cadena = sr.ReadToEnd();
          
              MessageBox.Show(cadena.ToString());
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
                request.Headers.Set("x-access-token", token);
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
                request.Headers.Set("x-access-token", token);
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
       

        public List<Shop> putShop(Shop shop, string url)
        {
            try
            {
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url); // + (WebUtility.UrlEncode(JsonConvert.SerializeObject(txtNombre.ToString()))));
                request.Method = WebRequestMethods.Http.Put; //post for post, duh
                request.Headers.Set("x-access-token", token);
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
                request.Headers.Set("x-access-token", token);
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
                request.Headers.Set("x-access-token", token);
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
                request.Headers.Set("x-access-token", token);
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



        public List<Invoice> postInvoice(Invoice invoice, string url)
        {
            try
            {
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url); // + (WebUtility.UrlEncode(JsonConvert.SerializeObject(txtNombre.ToString()))));
                request.Method = WebRequestMethods.Http.Post; //post for post, duh
                request.Headers.Set("x-access-token", token);
                request.ContentType = "application/json; charset=UTF-8";
                request.Accept = "application/json";
                string userJson = JsonConvert.SerializeObject(invoice);
                using (var streamWriter = new StreamWriter(request.GetRequestStream()))
                {
                    string json = JsonConvert.SerializeObject(invoice);

                    streamWriter.Write(json);
                    streamWriter.Flush();
                    streamWriter.Close();
                }

                HttpWebResponse response = (HttpWebResponse)request.GetResponse(); //response es un json
                StreamReader sr = new StreamReader(response.GetResponseStream(), Encoding.UTF8);
                String cadena = sr.ReadToEnd();
                List<Invoice> invoiceRecib = JsonConvert.DeserializeObject<List<Invoice>>(cadena);
                return invoiceRecib;


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

        public List<Invoice> getInvoice(string url)
        {
            try
            {
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url); // + (WebUtility.UrlEncode(JsonConvert.SerializeObject(txtNombre.ToString()))));
                request.Method = WebRequestMethods.Http.Get; //post for post, duh
                request.Headers.Set("x-access-token", token);
                request.ContentType = "application/json; charset=UTF-8";
                request.Accept = "application/json";
                //string userJson = JsonConvert.SerializeObject(user);
                HttpWebResponse response = (HttpWebResponse)request.GetResponse(); //response es un json
                StreamReader sr = new StreamReader(response.GetResponseStream(), Encoding.UTF8);
                String cadena = sr.ReadToEnd();
                List<Invoice> invoiceRecib = JsonConvert.DeserializeObject<List<Invoice>>(cadena);
                return invoiceRecib;
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

        public List<Invoice> putInvoice(Invoice invoice, string url)
        {
            try
            {
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url); // + (WebUtility.UrlEncode(JsonConvert.SerializeObject(txtNombre.ToString()))));
                request.Method = WebRequestMethods.Http.Put; //post for post, duh
                request.Headers.Set("x-access-token", token);
                request.ContentType = "application/json; charset=UTF-8";
                request.Accept = "application/json";
                string userJson = JsonConvert.SerializeObject(invoice);

                using (var streamWriter = new StreamWriter(request.GetRequestStream()))
                {
                    string json = JsonConvert.SerializeObject(invoice);

                    streamWriter.Write(json);
                    streamWriter.Flush();
                    streamWriter.Close();
                }

                HttpWebResponse response = (HttpWebResponse)request.GetResponse(); //response es un json
                StreamReader sr = new StreamReader(response.GetResponseStream(), Encoding.UTF8);
                String cadena = sr.ReadToEnd();
                List<Invoice> invoiceRecib = JsonConvert.DeserializeObject<List<Invoice>>(cadena);
                return invoiceRecib;

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
