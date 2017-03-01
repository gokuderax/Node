using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
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
using System.Windows.Shapes;

namespace App_Escritorio
{
    /// <summary>
    /// Lógica de interacción para Principal.xaml
    /// </summary>
    public partial class Principal : Window
    {
        public Principal()
        { 
            InitializeComponent();
            gbUsuarios.Visibility = System.Windows.Visibility.Hidden;
            gbTienda.Visibility = System.Windows.Visibility.Hidden;
            gbProductos.Visibility = System.Windows.Visibility.Hidden;
            gbFactura.Visibility = System.Windows.Visibility.Hidden;
        }

        private void MenuUsuarios(object sender, RoutedEventArgs e)
        {
            gbUsuarios.Visibility = System.Windows.Visibility.Visible;
            gbTienda.Visibility = System.Windows.Visibility.Hidden;
            gbProductos.Visibility = System.Windows.Visibility.Hidden;
            gbFactura.Visibility = System.Windows.Visibility.Hidden;

            gbControlUsuario.Visibility = System.Windows.Visibility.Visible;
        }

        private void MenuTiendas(object sender, RoutedEventArgs e)
        {
            gbUsuarios.Visibility = System.Windows.Visibility.Hidden;
            gbTienda.Visibility = System.Windows.Visibility.Visible;
            gbProductos.Visibility = System.Windows.Visibility.Hidden;
            gbFactura.Visibility = System.Windows.Visibility.Hidden;
        }

        private void MenuProductos(object sender, RoutedEventArgs e)
        {
            gbUsuarios.Visibility = System.Windows.Visibility.Hidden;
            gbTienda.Visibility = System.Windows.Visibility.Hidden;
            gbProductos.Visibility = System.Windows.Visibility.Visible;
            gbFactura.Visibility = System.Windows.Visibility.Hidden;
        }

        private void MenuFacturas(object sender, RoutedEventArgs e)
        {
            gbUsuarios.Visibility = System.Windows.Visibility.Hidden;
            gbTienda.Visibility = System.Windows.Visibility.Hidden;
            gbProductos.Visibility = System.Windows.Visibility.Hidden;
            gbFactura.Visibility = System.Windows.Visibility.Visible;
        }

        private void MenuSalir(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btnRegistroUser(object sender, RoutedEventArgs e)
        {
            User user = new User();
            user.nifcif = txtNifCif.Text;
            user.nombre = txtNombre.Text;
            user.apellido1 = txtApellido1.Text;
            user.apellido2 = txtApellido2.Text;
            user.tipo_via = txtTipoVia.Text;
            user.nombre_via = txtNombreVia.Text;
            user.numero = txtNumero.Text;
            user.piso = txtPiso.Text;
            user.puerta = txtPuerta.Text;
            user.cod_postal = txtCodPostal.Text;
            user.municipio = txtMunicipio.Text;
            user.provincia = txtProvincia.Text;
            user.pais = txtPais.Text;
            user.telefono1 = txtTelefono1.Text;
            user.telefono2 = txtTelefono2.Text;
            user.fax = txtFax.Text;
            user.email = txtEmail.Text;
            user.persona_contacto = txtPerContacto.Text;
            user.tipo_cliente = txtTipoClie.Text;
            user.password = txtPass.Password;
            user.cargo = txtCargo.Text;
            user.observaciones = txtObservaciones.Text;

            Rest rest = new Rest();

            List<User> result = rest.postUser(user, "http://localhost:3000/v1/user/", false);
            MessageBox.Show(result[0].apellido1.ToString());
            this.MyGrid.ItemsSource = result;
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
