
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using WpfAnimatedGif;

namespace App_Escritorio
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        ImageAnimationController img;
        public MainWindow()
        {
            InitializeComponent();
 
        }

        private void btnRegistroUser(object sender, RoutedEventArgs e)
        {
            User user = new User();
            Rest rest = new Rest();
            Principal principal = new Principal();

            user.email = txtLoginEmail.Text;
            user.password = txtLoginPass.Password;
            string result = rest.login(user, "http://localhost:3000/v1/token/");
                if(result.Contains("No")|| result.Contains("err"))
                 {
                     principal.Show();
                     this.Close();
                 }
                else
               {
                principal.Show();
                this.Close();
                MessageBox.Show("Login correcto");
            }

                principal.Show();
                this.Close();
                        
        }

        private void btnEntrar(object sender, RoutedEventArgs e)
        {
            img = ImageBehavior.GetAnimationController(gifEntrar);
            img.Play();
        }

    }
}