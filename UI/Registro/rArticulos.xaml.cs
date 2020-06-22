using PPAplicada1.BLL;
using PPAplicada1.Entidades;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace PPAplicada1.UI.Registro
{
    /// <summary>
    /// Interaction logic for RegistrodeProductos.xaml
    /// </summary>
    /// Un comit para el profe Enel.
    public partial class RegistrodeProductos : Window
    {
        Articulos articulos = new Articulos();
        public RegistrodeProductos()
        {
            InitializeComponent();
            this.DataContext = articulos;
        }

        private void NuevoBotton_Click(object sender, RoutedEventArgs e)
        {
            Limpiar();
        }

        private void GuardarBotton_Click(object sender, RoutedEventArgs e)
        {
            if (!Validar())
            {
                return;
            }
            else
            {
                var esOk = ArticuloBLL.Guardar(articulos);
                if(esOk)
                {
                    Limpiar();
                    MessageBox.Show("Guardado!", "Exito",MessageBoxButton.OK, MessageBoxImage.Information);
                }
                else
                {
                    MessageBox.Show("Guardado Fallido", "Fallo",MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

        private void Limpiar()
        {
            this.articulos = new Articulos();
            this.DataContext = articulos;
        }

        private bool Validar()
        {
            if(DescripcionTextBox.Text.Length == 0)
            {
                MessageBox.Show("El campo descripción esta vacio.", "Fallo", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
            else
            {
                return true;
            }
        }

        private void BuscarButton_Click(object sender, RoutedEventArgs e)
        {
            var producto = ArticuloBLL.Buscar(int.Parse(ProductoIdTexBox.Text));

            if (producto != null)
            {
                this.articulos = producto;
            }
            else
            {
                this.articulos = new Articulos();
                MessageBox.Show("El ProductoId introduccido no existe.", "No encontrado", MessageBoxButton.OK);
            }
            this.DataContext = this.articulos;
        }

        private void EliminarBotton_Click(object sender, RoutedEventArgs e)
        {
            if (ArticuloBLL.Eliminar(int.Parse(ProductoIdTexBox.Text)))
            {
                Limpiar();
                MessageBox.Show("Articulo Eliminado", "Exito",
                    MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
                MessageBox.Show("No fue posible eliminar", "Fallo",
                    MessageBoxButton.OK, MessageBoxImage.Error);
        }

        private void ValorInventarioTextBox_MouseEnter(object sender, MouseEventArgs e)
        {
            if (CostoTextBox.Text.Length == 0 || ExistenciaTextBox.Text.Length == 0)
            {
                MessageBox.Show("Debe de llenar los campos Costo y Existencia", "Notificacion", MessageBoxButton.OK, MessageBoxImage.Exclamation);
            }
            else
            {
                this.articulos.ValorInventario = Double.Parse(CostoTextBox.Text) * Double.Parse(ExistenciaTextBox.Text);
                ValorInventarioTextBox.Text = articulos.ValorInventario.ToString();
            }
        }

        private void ValorInventarioTextBox_MouseLeave(object sender, MouseEventArgs e)
        {
            if (CostoTextBox.Text.Length == 0)
            {
                CostoTextBox.Text = "0";
            }
            else if (ExistenciaTextBox.Text.Length == 0)
            {
                ExistenciaTextBox.Text = "0";
            }
            else
            {
                this.articulos.ValorInventario = Double.Parse(CostoTextBox.Text) * Double.Parse(ExistenciaTextBox.Text);
                ValorInventarioTextBox.Text = articulos.ValorInventario.ToString();
            }
        }
    }
}
