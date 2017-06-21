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
        Rest rest = new Rest();
        public Principal()
        {
            InitializeComponent();
            gbUsuarios.Visibility = System.Windows.Visibility.Visible;
            gbTienda.Visibility = System.Windows.Visibility.Hidden;
            gbProductos.Visibility = System.Windows.Visibility.Hidden;
            gbFactura.Visibility = System.Windows.Visibility.Hidden;
            cbTipoU.Items.Add("Cliente");
            cbTipoU.Items.Add("Empleado");
            cbTipoU.Items.Add("Trabajador");
        }

        private void MenuUsuarios(object sender, RoutedEventArgs e)
        {
            gbUsuarios.Visibility = System.Windows.Visibility.Visible;
            gbTienda.Visibility = System.Windows.Visibility.Hidden;
            gbProductos.Visibility = System.Windows.Visibility.Hidden;
            gbFactura.Visibility = System.Windows.Visibility.Hidden;

            scwUser.Visibility = System.Windows.Visibility.Visible;
            gbControlBuscarUsuario.Visibility = System.Windows.Visibility.Hidden;
            scwTienda.Visibility = System.Windows.Visibility.Hidden;
            gbControlBuscarTienda.Visibility = System.Windows.Visibility.Hidden;
            scwProducts.Visibility = System.Windows.Visibility.Hidden;
            gbControlBuscarProducts.Visibility = System.Windows.Visibility.Hidden;
            scwInvoices.Visibility = System.Windows.Visibility.Hidden;
            gbControlBuscarInvoice.Visibility = System.Windows.Visibility.Hidden;
        }

        private void MenuTiendas(object sender, RoutedEventArgs e)
        {
            btnEnviarTienda.Content = "Registrar Tienda";
            gbUsuarios.Visibility = System.Windows.Visibility.Hidden;
            gbTienda.Visibility = System.Windows.Visibility.Visible;
            gbProductos.Visibility = System.Windows.Visibility.Hidden;
            gbFactura.Visibility = System.Windows.Visibility.Hidden;

            scwUser.Visibility = System.Windows.Visibility.Hidden;
            gbControlBuscarUsuario.Visibility = System.Windows.Visibility.Hidden;
            scwTienda.Visibility = System.Windows.Visibility.Visible;
            gbControlBuscarTienda.Visibility = System.Windows.Visibility.Hidden;
            scwProducts.Visibility = System.Windows.Visibility.Hidden;
            gbControlBuscarProducts.Visibility = System.Windows.Visibility.Hidden;
            scwInvoices.Visibility = System.Windows.Visibility.Hidden;
            gbControlBuscarInvoice.Visibility = System.Windows.Visibility.Hidden;
        }

        private void MenuProductos(object sender, RoutedEventArgs e)
        {
            btnEnviarProducto.Content = "Registrar Producto";

            gbUsuarios.Visibility = System.Windows.Visibility.Hidden;
            gbTienda.Visibility = System.Windows.Visibility.Hidden;
            gbProductos.Visibility = System.Windows.Visibility.Visible;
            gbFactura.Visibility = System.Windows.Visibility.Hidden;

            scwUser.Visibility = System.Windows.Visibility.Hidden;
            gbControlBuscarUsuario.Visibility = System.Windows.Visibility.Hidden;
            scwTienda.Visibility = System.Windows.Visibility.Hidden;
            gbControlBuscarTienda.Visibility = System.Windows.Visibility.Hidden;
            scwProducts.Visibility = System.Windows.Visibility.Visible;
            gbControlBuscarProducts.Visibility = System.Windows.Visibility.Hidden;
            scwInvoices.Visibility = System.Windows.Visibility.Hidden;
            gbControlBuscarInvoice.Visibility = System.Windows.Visibility.Hidden;
        }

        private void MenuFacturas(object sender, RoutedEventArgs e)
        {
            btnEnviarProducto.Content = "Registrar Factura";

            gbUsuarios.Visibility = System.Windows.Visibility.Hidden;
            gbTienda.Visibility = System.Windows.Visibility.Hidden;
            gbProductos.Visibility = System.Windows.Visibility.Hidden;
            gbFactura.Visibility = System.Windows.Visibility.Visible;

            List<User> listUsers;
            List<Shop> listShops;
            List<Product> listProducts;

            scwUser.Visibility = System.Windows.Visibility.Hidden;
            gbControlBuscarUsuario.Visibility = System.Windows.Visibility.Hidden;
            scwTienda.Visibility = System.Windows.Visibility.Hidden;
            gbControlBuscarTienda.Visibility = System.Windows.Visibility.Hidden;
            scwProducts.Visibility = System.Windows.Visibility.Hidden;
            gbControlBuscarProducts.Visibility = System.Windows.Visibility.Hidden;
            scwInvoices.Visibility = System.Windows.Visibility.Visible;
            gbControlBuscarInvoice.Visibility = System.Windows.Visibility.Hidden;

            cbIdU.Items.Clear();
            cbIdT.Items.Clear();
            cbIdPI.Items.Clear();

            listUsers = rest.getUser("http://localhost:3000/v1/user/");
            if (listUsers != null) { 
                   for (int i = 0; i < listUsers.Count; i++)
                   {
                     cbIdU.Items.Add(listUsers[i].nombre);
                  }
            }

            listShops = rest.getShop("http://localhost:3000/v1/shop/");
            if (listShops != null) {
                for (int i = 0; i < listShops.Count; i++)
                 {
                    cbIdT.Items.Add(listShops[i].nombre);
                 }
            }

            listProducts = rest.getProduct("http://localhost:3000/v1/product/");

            if (listProducts != null) { 
                for (int i = 0; i < listProducts.Count; i++)
                 {
                    cbIdPI.Items.Add(listProducts[i].nombre);
                  }
            }
        }

        private void MenuSalir(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            List<User> listUsers;

            object row = MyGrid.SelectedItem;
            int columnIndex = MyGrid.Columns.Single(c => c.Header.Equals("_id")).DisplayIndex;
            String cellValue = (MyGrid.SelectedCells[columnIndex].Column.GetCellContent(row) as TextBlock).Text;

            MessageBoxResult messageBoxResult;
            messageBoxResult = System.Windows.MessageBox.Show("Está apunto de eliminar el usuario con id \"" + cellValue + "\" \n Los usuarios eliminadas no podrán recuperarse. \n ¿Seguro que desea continuar?", "Confirmación de borrado", System.Windows.MessageBoxButton.YesNo);


            if (messageBoxResult == MessageBoxResult.Yes || messageBoxResult == MessageBoxResult.OK)
            {
                rest.delete("http://localhost:3000/v1/user/"+cellValue);
                listUsers = rest.getUser("http://localhost:3000/v1/user/");
                this.MyGrid.ItemsSource = listUsers;

            }
        }


        private void btnControlUsuario_Click(object sender, RoutedEventArgs e)
        {
            Button btn = sender as Button;
            List<User> listUsers;
            List<Shop> listShops;
            List<Product> listProducts;
            List<Invoice> listInvoices;

            switch (btn.Name)
            {
                case "InsertUsuarios":
                    btnEnviarUsuario.Content = "Registrar Usuario";
                    scwUser.Visibility = System.Windows.Visibility.Visible;
                    gbControlBuscarUsuario.Visibility = System.Windows.Visibility.Hidden;
                    scwTienda.Visibility = System.Windows.Visibility.Hidden;
                    gbControlBuscarTienda.Visibility = System.Windows.Visibility.Hidden;
                    scwProducts.Visibility = System.Windows.Visibility.Hidden;
                    gbControlBuscarProducts.Visibility = System.Windows.Visibility.Hidden;

                    txtId.Visibility = System.Windows.Visibility.Hidden;
                    lblId.Visibility = System.Windows.Visibility.Hidden;

                    break;

                case "BuscarUsuarios":
                    btnBuscarUsuario.Content = "Buscar Usuario";
                    scwUser.Visibility = System.Windows.Visibility.Hidden;
                    gbControlBuscarUsuario.Visibility = System.Windows.Visibility.Visible;
                    scwTienda.Visibility = System.Windows.Visibility.Hidden;
                    gbControlBuscarTienda.Visibility = System.Windows.Visibility.Hidden;
                    scwProducts.Visibility = System.Windows.Visibility.Hidden;
                    gbControlBuscarProducts.Visibility = System.Windows.Visibility.Hidden;
                    listUsers = rest.getUser("http://localhost:3000/v1/user/");
                    this.MyGrid.ItemsSource = listUsers;

                    break;
                case "ModificarUsuarios":
                    btnEnviarUsuario.Content = "Modificar Usuario";
                    scwUser.Visibility = System.Windows.Visibility.Visible;
                    gbControlBuscarUsuario.Visibility = System.Windows.Visibility.Hidden;
                    scwTienda.Visibility = System.Windows.Visibility.Hidden;
                    gbControlBuscarTienda.Visibility = System.Windows.Visibility.Hidden;
                    scwProducts.Visibility = System.Windows.Visibility.Hidden;
                    gbControlBuscarProducts.Visibility = System.Windows.Visibility.Hidden;
                    listUsers = rest.getUser("http://localhost:3000/v1/user/");
                    this.MyGrid.ItemsSource = listUsers;

                    txtId.Visibility = System.Windows.Visibility.Visible;
                    lblId.Visibility = System.Windows.Visibility.Visible;

                    break;

                case "InsertTiendas":
                    btnEnviarTienda.Content = "Registrar Tienda";
                    scwUser.Visibility = System.Windows.Visibility.Hidden;     
                    gbControlBuscarUsuario.Visibility = System.Windows.Visibility.Hidden;
                    scwTienda.Visibility = System.Windows.Visibility.Visible;
                    gbControlBuscarTienda.Visibility = System.Windows.Visibility.Hidden;
                    scwProducts.Visibility = System.Windows.Visibility.Hidden;
                    gbControlBuscarProducts.Visibility = System.Windows.Visibility.Hidden;
                    break;
                case "BuscarTiendas":
                    btnEnviarTienda.Content = "Buscar Tienda";
                    scwUser.Visibility = System.Windows.Visibility.Hidden;     
                    gbControlBuscarUsuario.Visibility = System.Windows.Visibility.Hidden;
                    scwTienda.Visibility = System.Windows.Visibility.Hidden;
                    gbControlBuscarTienda.Visibility = System.Windows.Visibility.Visible;
                    scwProducts.Visibility = System.Windows.Visibility.Hidden;
                    gbControlBuscarProducts.Visibility = System.Windows.Visibility.Hidden;

                    listShops = rest.getShop("http://localhost:3000/v1/shop/");
                    this.MyGrid.ItemsSource = listShops;

                    break;
                case "ModificarTiendas":
                    btnEnviarTienda.Content = "Modificar Tienda";
                    scwUser.Visibility = System.Windows.Visibility.Hidden;     
                    gbControlBuscarUsuario.Visibility = System.Windows.Visibility.Hidden;
                    scwTienda.Visibility = System.Windows.Visibility.Visible;
                    gbControlBuscarTienda.Visibility = System.Windows.Visibility.Hidden;
                    scwProducts.Visibility = System.Windows.Visibility.Hidden;
                    gbControlBuscarProducts.Visibility = System.Windows.Visibility.Hidden;


                    break;
                case "InsertProductos":
                    btnEnviarProducto.Content = "Registrar Producto";
                    scwUser.Visibility = System.Windows.Visibility.Hidden;
                    gbControlBuscarUsuario.Visibility = System.Windows.Visibility.Hidden;
                    scwTienda.Visibility = System.Windows.Visibility.Hidden;
                    gbControlBuscarTienda.Visibility = System.Windows.Visibility.Hidden;
                    scwProducts.Visibility = System.Windows.Visibility.Visible;
                    gbControlBuscarProducts.Visibility = System.Windows.Visibility.Hidden;
                    break;

                case "BuscarProductos":
                    btnEnviarProducto.Content = "Buscar Producto";
                    scwUser.Visibility = System.Windows.Visibility.Hidden;
                    gbControlBuscarUsuario.Visibility = System.Windows.Visibility.Hidden;
                    scwTienda.Visibility = System.Windows.Visibility.Hidden;
                    gbControlBuscarTienda.Visibility = System.Windows.Visibility.Hidden;
                    scwProducts.Visibility = System.Windows.Visibility.Hidden;
                    gbControlBuscarProducts.Visibility = System.Windows.Visibility.Visible;
                    listProducts = rest.getProduct("http://localhost:3000/v1/product/");
                    this.MyGrid.ItemsSource = listProducts;
                    break;
                case "ModificarProductos":
                    btnEnviarProducto.Content = "Modificar Producto";
                    scwUser.Visibility = System.Windows.Visibility.Hidden;
                    gbControlBuscarUsuario.Visibility = System.Windows.Visibility.Hidden;
                    scwTienda.Visibility = System.Windows.Visibility.Hidden;
                    gbControlBuscarTienda.Visibility = System.Windows.Visibility.Hidden;
                    scwProducts.Visibility = System.Windows.Visibility.Visible;
                    gbControlBuscarProducts.Visibility = System.Windows.Visibility.Hidden;
                    listProducts = rest.getProduct("http://localhost:3000/v1/product/");
                    this.MyGrid.ItemsSource = listProducts;
                    break;
                case "InsertInvoices":
                    btnEnviarProducto.Content = "Registrar Factura";
                    scwUser.Visibility = System.Windows.Visibility.Hidden;
                    gbControlBuscarUsuario.Visibility = System.Windows.Visibility.Hidden;
                    scwTienda.Visibility = System.Windows.Visibility.Hidden;
                    gbControlBuscarTienda.Visibility = System.Windows.Visibility.Hidden;
                    scwProducts.Visibility = System.Windows.Visibility.Hidden;
                    gbControlBuscarProducts.Visibility = System.Windows.Visibility.Hidden;
                    scwInvoices.Visibility = System.Windows.Visibility.Visible;
                    gbControlBuscarInvoice.Visibility = System.Windows.Visibility.Hidden;
                    cbIdU.Items.Clear();
                    cbIdT.Items.Clear();
                    cbIdPI.Items.Clear();
                    listUsers = rest.getUser("http://localhost:3000/v1/user/");
                    for (int i = 0; i < listUsers.Count; i++)
                    {
                        cbIdU.Items.Add(listUsers[i].nombre);
                    }
                    listShops = rest.getShop("http://localhost:3000/v1/shop/");
                    for (int i = 0; i < listShops.Count; i++)
                    {
                        cbIdT.Items.Add(listShops[i].nombre);
                    }
                    listProducts = rest.getProduct("http://localhost:3000/v1/product/");
                    for (int i = 0; i < listProducts.Count; i++)
                    {
                        cbIdPI.Items.Add(listProducts[i].nombre);
                    }
                    break;

                case "BuscarInvoices":
                    btnEnviarProducto.Content = "Buscar Factura";
                    scwUser.Visibility = System.Windows.Visibility.Hidden;
                    gbControlBuscarUsuario.Visibility = System.Windows.Visibility.Hidden;
                    scwTienda.Visibility = System.Windows.Visibility.Hidden;
                    gbControlBuscarTienda.Visibility = System.Windows.Visibility.Hidden;
                    scwProducts.Visibility = System.Windows.Visibility.Hidden;
                    gbControlBuscarProducts.Visibility = System.Windows.Visibility.Hidden;
                    scwInvoices.Visibility = System.Windows.Visibility.Hidden;
                    gbControlBuscarInvoice.Visibility = System.Windows.Visibility.Visible;
                    listInvoices = rest.getInvoice("http://localhost:3000/v1/invoice/");
                    this.MyGrid.ItemsSource = listInvoices;
                    break;
                case "ModificarInvoices":
                    btnEnviarProducto.Content = "Modificar Factura";
                    scwUser.Visibility = System.Windows.Visibility.Hidden;
                    gbControlBuscarUsuario.Visibility = System.Windows.Visibility.Hidden;
                    scwTienda.Visibility = System.Windows.Visibility.Hidden;
                    gbControlBuscarTienda.Visibility = System.Windows.Visibility.Hidden;
                    scwProducts.Visibility = System.Windows.Visibility.Hidden;
                    gbControlBuscarProducts.Visibility = System.Windows.Visibility.Hidden;
                    scwInvoices.Visibility = System.Windows.Visibility.Visible;
                    gbControlBuscarInvoice.Visibility = System.Windows.Visibility.Hidden;
                    listInvoices = rest.getInvoice("http://localhost:3000/v1/invoice/");
                    this.MyGrid.ItemsSource = listInvoices;
                    break;
            }
        }

        private void btnHacerCosas(object sender, RoutedEventArgs e)
        {
            Button btn = sender as Button;
            DataTable dtDatos = new DataTable();
            User user = new User();
            Shop shop = new Shop();
            Product product = new Product();
            Invoice invoice = new Invoice();
            Rest rest = new Rest();
            List<User> listUsers;
            List<Shop> listShops;
            List<Product> listProducts;
            List<Invoice> listInvoices;
            switch (btn.Content.ToString())
            {
                case "Registrar Usuario":
                                  //  user.typeUser[0] = cbTipoU.SelectedValue.ToString();
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



                                    listUsers = rest.postUser(user, "http://localhost:3000/v1/user/", false);
                                    if (listUsers != null)
                                    {
                                        listUsers = rest.getUser("http://localhost:3000/v1/user/");
                                        this.MyGrid.ItemsSource = listUsers;
                                    }

                    break;
                    case "Buscar Usuario":
                                   listUsers = rest.getUser("http://localhost:3000/v1/user/"+txtIdB.Text);
                                   this.MyGrid.ItemsSource = listUsers;
                    break;
                    case "Modificar Usuario":
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



                                    listUsers = rest.putUser(user, "http://localhost:3000/v1/user/" + txtId.Text);
                                    if (listUsers != null)
                                    {
                                        listUsers = rest.getUser("http://localhost:3000/v1/user/");
                                        this.MyGrid.ItemsSource = listUsers;
                                    }
                    break;
                    case "Registrar Tienda":
                                    shop.id = txtIdT.Text;
                                    shop.nombre = txtNombreT.Text;
                                    shop.tipo_via = txtTipoViaT.Text;
                                    shop.nombre_via = txtNombreViaT.Text;
                                    shop.numero = txtNumeroT.Text;
                                    shop.cod_postal = txtCodPostalT.Text;
                                    shop.municipio = txtMunicipioT.Text;
                                    shop.provincia = txtProvinciaT.Text;
                                    shop.pais = txtPaisT.Text;
                                    shop.telefono = txtTelefonoT.Text;
                                    shop.fax = txtFaxT.Text;
                                    shop.email = txtEmailT.Text;
                                    shop.encargado = txtEncargadoT.Text;



                                    listShops = rest.postShop(shop, "http://localhost:3000/v1/shop/");
                                    if (listShops != null)
                                    {
                                        listShops = rest.getShop("http://localhost:3000/v1/shop/");
                                        this.MyGrid.ItemsSource = listShops;
                                    }
                    break;
                    case "Buscar Tienda":
                                     listShops = rest.getShop("http://localhost:3000/v1/shop/" + txtId.Text);
                                    this.MyGrid.ItemsSource = listShops;
                    break;
                    case "Modificar Tienda":
                                    shop.id = txtIdT.Text;
                                    shop.nombre = txtNombreT.Text;
                                    shop.tipo_via = txtTipoViaT.Text;
                                    shop.nombre_via = txtNombreViaT.Text;
                                    shop.numero = txtNumeroT.Text;
                                    shop.cod_postal = txtCodPostalT.Text;
                                    shop.municipio = txtMunicipioT.Text;
                                    shop.provincia = txtProvinciaT.Text;
                                    shop.pais = txtPaisT.Text;
                                    shop.telefono = txtTelefonoT.Text;
                                    shop.fax = txtFaxT.Text;
                                    shop.email = txtEmailT.Text;
                                    shop.encargado = txtEncargadoT.Text;

                                    listShops = rest.putShop(shop, "http://localhost:3000/v1/user/" + txtId.Text);
                                    if (listShops != null)
                                    {
                                        listShops = rest.getShop("http://localhost:3000/v1/user/");
                                        this.MyGrid.ItemsSource = listShops;
                                    }
                    break;
                    case "Registrar Producto":
                                    product.id = txtIdP.Text;
                                    product.referencia = txtReferenciaP.Text;
                                    product.nombre = txtNombreP.Text;
                                    product.modelo = txtModeloP.Text;
                                    product.descripcion = txtDescripcionP.Text;
                                    product.categoria = txtCategoriaP.Text;
                                    product.importe = txtImporteP.Text;
                                    product.iva = txtIvaP.Text;
                                    product.proveedor = txtProveedorP.Text;
                                    product.tienda_stock= txtTiendaStockP.Text;
        
                                    listProducts = rest.postProduct(product, "http://localhost:3000/v1/product/");
                                    if (listProducts != null)
                                    {
                                        listProducts = rest.getProduct("http://localhost:3000/v1/product/");
                                        this.MyGrid.ItemsSource = listProducts;
                                    }
                    break;
                    case "Buscar Producto":
                                    listProducts = rest.getProduct("http://localhost:3000/v1/product/" + txtId.Text);
                                    this.MyGrid.ItemsSource = listProducts;
                    break;
                    case "Modificar Producto":
                                    product.id = txtIdP.Text;
                                    product.referencia = txtReferenciaP.Text;
                                    product.nombre = txtNombreP.Text;
                                    product.modelo = txtModeloP.Text;
                                    product.descripcion = txtDescripcionP.Text;
                                    product.categoria = txtCategoriaP.Text;
                                    product.importe = txtImporteP.Text;
                                    product.iva = txtIvaP.Text;
                                    product.proveedor = txtProveedorP.Text;
                                    product.tienda_stock=(txtTiendaStockP.Text);

                                    listProducts = rest.putProduct(product, "http://localhost:3000/v1/product/");
                                    if (listProducts != null)
                                    {
                                        listProducts = rest.getProduct("http://localhost:3000/v1/product/");
                                        this.MyGrid.ItemsSource = listProducts;
                                    }
                    break;
                    case "Registrar Factura":
                                    invoice.id =    txtIdBI.Text;
                                    invoice.id_client = cbIdU.SelectedItem.ToString();
                                    invoice.id_shop = cbIdT.SelectedItem.ToString();
                                    invoice.id_salesperson = cbIdSP.SelectedItem.ToString();
                                    invoice.taxes = txtTaxesI.Text;
                                    invoice.base_total = txtBaseTotalI.Text;
                                    invoice.base_advanced = txtBaseAdvancedI.Text;
                                    invoice.observations = txtObservaciones.Text;
                                    invoice.validated = txtValidatedI.Text;
                                    invoice.date = txtDateI.Text;
                                    invoice.products[0] = cbIdPI.SelectedItem.ToString();

                    //product.tienda_stock.AddRange(txtTiendaStockP.Text.Split(','));

                                    listInvoices = rest.postInvoice(invoice, "http://localhost:3000/v1/invoice/");
                                    if (listInvoices != null)
                                    {
                                        listInvoices = rest.getInvoice("http://localhost:3000/v1/invoicet/");
                                        this.MyGrid.ItemsSource = listInvoices;
                                    }
                    break;
                    case "Buscar Factura":
                                    listInvoices = rest.getInvoice("http://localhost:3000/v1/invoice/" + txtId.Text);
                                    this.MyGrid.ItemsSource = listInvoices;
                    break;
                    case "Modificar Factura":
                                    invoice.id = txtIdBI.Text;
                                    invoice.id_client = cbIdU.SelectedItem.ToString();
                                    invoice.id_shop = cbIdT.SelectedItem.ToString();
                                    invoice.id_salesperson = cbIdSP.SelectedItem.ToString();
                                    invoice.taxes = txtTaxesI.Text;
                                    invoice.base_total = txtBaseTotalI.Text;
                                    invoice.base_advanced = txtBaseAdvancedI.Text;
                                    invoice.observations = txtObservaciones.Text;
                                    invoice.validated = txtValidatedI.Text;
                                    invoice.date = txtDateI.Text;
                                    invoice.products[0] = cbIdPI.SelectedItem.ToString();

                                    //product.tienda_stock.AddRange(txtTiendaStockP.Text.Split(','));

                                    listInvoices = rest.putInvoice(invoice, "http://localhost:3000/v1/invoice/");
                                    if (listInvoices != null)
                                    {
                                        listInvoices = rest.getInvoice("http://localhost:3000/v1/invoicet/");
                                        this.MyGrid.ItemsSource = listInvoices;
                                    }
                    break;
            }
        }
    }
}
