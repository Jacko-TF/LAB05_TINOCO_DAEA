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
            string connectionString = "Data Source=LAB1504-15\\SQLEXPRESS;Initial Catalog=NeptunoDB;User Id=jacko;Password=admin123";

            List<Cliente> clientes = new List<Cliente>();

            try
            {
                SqlConnection connection = new SqlConnection(connectionString);

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


                dgClients.ItemsSource = clientes;

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private void dgClients_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
