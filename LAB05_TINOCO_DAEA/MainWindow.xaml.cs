using LAB05_TINOCO_DAEA.Models;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace LAB05_TINOCO_DAEA
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
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

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            try
            {
                SqlConnection connection = new SqlConnection(DBConnection.getCadenaConexion());

                connection.Open();

                SqlCommand command = new SqlCommand("USP_InsertClient", connection);

                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.AddWithValue("@id", txtId.Text);
                command.Parameters.AddWithValue("@nombreCompañia", txtNombreCompañia.Text);
                command.Parameters.AddWithValue("@nombreContacto", txtNombreContacto.Text);
                command.Parameters.AddWithValue("@cargoContacto", txtCargoContacto.Text);
                command.Parameters.AddWithValue("@direccion", txtDireccion.Text);
                command.Parameters.AddWithValue("@ciudad", txtCiudad.Text);
                command.Parameters.AddWithValue("@region", txtRegion.Text);
                command.Parameters.AddWithValue("@codPostal", txtCodigoPostal.Text);
                command.Parameters.AddWithValue("@pais", txtPais.Text);
                command.Parameters.AddWithValue("@telefono", txtTelefono.Text);
                command.Parameters.AddWithValue("@fax", txtFax.Text);

                int rowsAffected = command.ExecuteNonQuery();

                if (rowsAffected > 0)
                {
                    ClearText();
                    MessageBox.Show("Client saved successfully");
                }
                else
                {
                    Console.WriteLine("Error al insertar datos");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private void ClearText()
        {
            txtCargoContacto.Clear();
            txtRegion.Clear();
            txtCodigoPostal.Clear();
            txtDireccion.Clear();
            txtCiudad.Clear();
            txtFax.Clear();
            txtId.Clear();
            txtNombreCompañia.Clear();
            txtTelefono.Clear();
            txtNombreContacto.Clear();
            txtPais.Clear();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            try
            {
                SqlConnection connection = new SqlConnection(DBConnection.getCadenaConexion());

                connection.Open();

                SqlCommand command = new SqlCommand("USP_UpdateClient", connection);

                command.CommandType = CommandType.StoredProcedure;

                string ID = txtId.Text;
                command.Parameters.AddWithValue("@id", ID);
                command.Parameters.AddWithValue("@nombreCompañia", txtNombreCompañia.Text);
                command.Parameters.AddWithValue("@nombreContacto", txtNombreContacto.Text);
                command.Parameters.AddWithValue("@cargoContacto", txtCargoContacto.Text);
                command.Parameters.AddWithValue("@direccion", txtDireccion.Text);
                command.Parameters.AddWithValue("@ciudad", txtCiudad.Text);
                command.Parameters.AddWithValue("@region", txtRegion.Text);
                command.Parameters.AddWithValue("@codPostal", txtCodigoPostal.Text);
                command.Parameters.AddWithValue("@pais", txtPais.Text);
                command.Parameters.AddWithValue("@telefono", txtTelefono.Text);
                command.Parameters.AddWithValue("@fax", txtFax.Text);

                int rowsAffected = command.ExecuteNonQuery();

                if (rowsAffected > 0)
                {
                    ClearText();
                    MessageBox.Show($"Client whit id = {ID} updated successfully");
                }
                else
                {
                    Console.WriteLine("Error al actualizar cliente");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            try
            {
                SqlConnection connection = new SqlConnection(DBConnection.getCadenaConexion());

                connection.Open();

                SqlCommand command = new SqlCommand("USP_DeleteClient", connection);

                command.CommandType = CommandType.StoredProcedure;

                string ID = txtId.Text;
                command.Parameters.AddWithValue("@id", ID);

                int rowsAffected = command.ExecuteNonQuery();

                if (rowsAffected > 0)
                {
                    ClearText();
                    MessageBox.Show($"Client whit id = {ID} DELETED successfully");
                }
                else
                {
                    Console.WriteLine("Error al eliminar cliente");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}