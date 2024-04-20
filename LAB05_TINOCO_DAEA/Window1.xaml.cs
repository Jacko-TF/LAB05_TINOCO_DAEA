using LAB05_TINOCO_DAEA.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
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

                command.CommandType = CommandType.StoredProcedure;

                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    string id = reader.GetString("idCliente");
                    string nomCom = reader.GetString("NombreCompañia");
                    string nomCont = reader.GetString("NombreContacto");
                    string ciudad = reader.GetString("Ciudad");
                    string pais = reader.GetString("Pais");

                    clientes.Add(new Cliente(id, nomCont, nomCont, ciudad, pais));
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
