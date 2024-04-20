using System.Data.SqlClient;
using System.Data;
using System.Text;
using System.Windows;
using LAB04_TINOCO_DAEA.models;

namespace LAB05_TINOCO_DAEA
{
    /// <summary>
    /// Lógica de interacción para Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        public Window1()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            List<Producto> productos = new List<Producto>();

            try
            {
                SqlConnection connection = new SqlConnection(DBConnection.getCadenaConexion());

                connection.Open();

                SqlCommand command = new SqlCommand("USP_ListProducts", connection);

                command.CommandType = CommandType.StoredProcedure;

                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    int id = reader.GetInt32("idproducto");
                    string nom = reader.GetString("nombreProducto");
                    string cant = reader.GetString("cantidadPorUnidad");
                    decimal pre = reader.GetDecimal("precioUnidad");
                    string cat;
                    if (!reader.IsDBNull("categoriaProducto"))
                    {
                        cat = reader.GetString("categoriaProducto");
                    }
                    else
                    {
                        cat = null;
                    }

                    productos.Add(new Producto(id, nom, cant, pre, cat));
                }

                connection.Close();

                dgProductos.ItemsSource = productos;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {

            List<Categoria> categorias = new List<Categoria>();

            try
            {
                SqlConnection connection = new SqlConnection(DBConnection.getCadenaConexion());

                connection.Open();

                SqlCommand command = new SqlCommand("USP_ListCategories", connection);

                command.CommandType = CommandType.StoredProcedure;

                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    int id = reader.GetInt32("idcategoria");
                    string nom = reader.GetString("nombrecategoria");
                    string des = reader.GetString("descripcion");
                    string cod = reader.GetString("CodCategoria");

                    categorias.Add(new Categoria(id, nom, des, cod));
                }

                connection.Close();

                dgCategorias.ItemsSource = categorias;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {

            List<Cliente> clientes = new List<Cliente>();
            try
            {
                SqlConnection connection = new SqlConnection(DBConnection.getCadenaConexion());
                connection.Open();

                SqlCommand command = new SqlCommand("USP_ListClients", connection);

                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    string idCliente = reader.GetString("idCliente");
                    string nombreCompañia = reader.GetString("NombreCompañia");
                    string nombreContacto = reader.GetString("NombreContacto");
                    string cargoContacto = reader.GetString("CargoContacto");
                    string direccion = reader.GetString("Direccion");
                    string telefono = reader.GetString("Telefono");

                    clientes.Add(new Cliente(idCliente, nombreCompañia, nombreContacto, cargoContacto, direccion, telefono));
                }
                connection.Close();
                dgCategorias.ItemsSource = clientes;

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
