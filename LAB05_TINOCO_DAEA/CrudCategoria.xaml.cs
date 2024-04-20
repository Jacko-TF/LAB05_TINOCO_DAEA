using LAB04_TINOCO_DAEA.models;
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
    /// Lógica de interacción para CrudCategoria.xaml
    /// </summary>
    public partial class CrudCategoria : Window
    {
        public CrudCategoria()
        {
            InitializeComponent();
        }

        private void Listar()
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
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Listar();
        }

        private void dgCategorias_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Categoria cat = dgCategorias.SelectedItem as Categoria;
            if (cat != null)
            {
                txtCod.Text = cat.CodCategoria.ToString();
                txtNombre.Text = cat.nombrecategoria.ToString();
                txtNombreDesc.Text = cat.descripcion.ToString();
                txtId.Text = cat.idcategoria.ToString();
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            

            try
            {
                SqlConnection connection = new SqlConnection(DBConnection.getCadenaConexion());

                connection.Open();

                SqlCommand command = new SqlCommand("USP_DeleteCategory", connection);

                command.CommandType = CommandType.StoredProcedure;

                string ID = txtId.Text;
                command.Parameters.AddWithValue("@id", ID);

                int rowsAffected = command.ExecuteNonQuery();

                if (rowsAffected > 0)
                {
                    ClearText();
                    MessageBox.Show($"Categoria con id = {ID} eliminada correctamente");
                    Listar();
                }
                else
                {
                    Console.WriteLine("Error al eliminar categoria");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private void ClearText()
        {
            txtCod.Clear();
            txtNombre.Clear();
            txtNombreDesc.Clear();
            txtId.Clear();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            

            try
            {
                SqlConnection connection = new SqlConnection(DBConnection.getCadenaConexion());

                connection.Open();

                SqlCommand command = new SqlCommand("USP_UpdateCategory", connection);

                command.CommandType = CommandType.StoredProcedure;

                string ID = txtId.Text;
                command.Parameters.AddWithValue("@id", ID);
                command.Parameters.AddWithValue("@nombrecategoria", txtNombre.Text);
                command.Parameters.AddWithValue("@descripcion", txtNombreDesc.Text);
                command.Parameters.AddWithValue("@CodCategoria", txtCod.Text);

                int rowsAffected = command.ExecuteNonQuery();

                if (rowsAffected > 0)
                {
                    ClearText();
                    MessageBox.Show($"Categoria con id = {ID} actualizada correctamente");
                    Listar();
                }
                else
                {
                    Console.WriteLine("Error al actualizar categoria");
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

                SqlCommand command = new SqlCommand("USP_CreateCategory", connection);

                command.CommandType = CommandType.StoredProcedure;

                string ID = txtId.Text;
                command.Parameters.AddWithValue("@id", ID);
                command.Parameters.AddWithValue("@nombrecategoria", txtNombre.Text);
                command.Parameters.AddWithValue("@descripcion", txtNombreDesc.Text);
                command.Parameters.AddWithValue("@CodCategoria", txtCod.Text);

                int rowsAffected = command.ExecuteNonQuery();

                if (rowsAffected > 0)
                {
                    ClearText();
                    MessageBox.Show($"Categoria creada correctamente");
                    Listar();
                }
                else
                {
                    Console.WriteLine("Error al crear categoria");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
