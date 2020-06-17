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
            if(DescripcionTextBox.Text.Length == 0 && CostoTextBox.Text.Length == 0 && ExistenciaTextBox.Text.Length == 0)
            {
                MessageBox.Show("Los campos estan vacios");
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

        private void ExistenciaTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            /*double costo = 0, existencia = 0, valorinventario = 0;
            if(ExistenciaTextBox.Text == String.Empty)
            {
                ExistenciaTextBox.Text = "0";
                costo = Double.Parse(CostoTextBox.Text);
            }
            
            existencia = Double.Parse(ExistenciaTextBox.Text);
            valorinventario = Double.Parse(ValorInventarioTextBox.Text);
            valorinventario = costo * existencia;
            ValorInventarioTextBox.Text = valorinventario.ToString();*/

            articulos.ValorInventario = articulos.Costo * articulos.Existencias;
        }

        private void CostoTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            /*double costo = 0, existencia = 0, valorinventario = 0;
            if (CostoTextBox.Text == String.Empty)
            {
                CostoTextBox.Text = "0";
                costo = Double.Parse(CostoTextBox.Text);
            }
            
            existencia = Double.Parse(ExistenciaTextBox.Text);
            valorinventario = Double.Parse(ValorInventarioTextBox.Text);
            valorinventario = costo * existencia;
            ValorInventarioTextBox.Text = valorinventario.ToString();*/
            articulos.ValorInventario = articulos.Costo * articulos.Existencias;
        }
    }
}
