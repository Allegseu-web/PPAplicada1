using Microsoft.EntityFrameworkCore;
using PPAplicada1.DAL;
using PPAplicada1.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;

namespace PPAplicada1.BLL
{
    public class ArticuloBLL
    {
        //clases BLL
        public static bool Guardar(Articulos producto)
        {
            if (Coincidencia(producto) == true)
            {
                return false;
            }
            else
            {
                if (!Existe(producto.ArticuloId))
                {
                    return Insertar(producto);
                }
                else
                {
                    return Modificar(producto);
                }
            }
        }

        private static bool Insertar(Articulos producto)
        {
            bool paso = false;
            Contexto contexto = new Contexto();

            try
            {
                
                contexto.articulos.Add(producto);
                paso = contexto.SaveChanges() > 0;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }

            return paso;
        }

        private static bool Modificar(Articulos estudiante)
        {
            bool paso = false;
            Contexto contexto = new Contexto();

            try
            {
                
                contexto.Entry(estudiante).State = EntityState.Modified;
                paso = contexto.SaveChanges() > 0;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }
            return paso;
        }

        public static bool Eliminar(int id)
        {
            bool paso = false;
            Contexto contexto = new Contexto();
            try
            {
                
                var estudiante = contexto.articulos.Find(id);

                if (estudiante != null)
                {
                    contexto.articulos.Remove(estudiante);
                    paso = contexto.SaveChanges() > 0;
                }
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }

            return paso;
        }

        public static Articulos Buscar(int id)
        {
            Contexto contexto = new Contexto();
            Articulos estudiante;

            try
            {
                estudiante = contexto.articulos.Find(id);
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }

            return estudiante;
        }

        private static bool Existe(int id)
        {
            Contexto contexto = new Contexto();
            bool encontrado = false;

            try
            {
                encontrado = contexto.articulos.Any(e => e.ArticuloId == id);
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }
            return encontrado;
        }

        private static bool Coincidencia(Articulos producto)
        {
            Contexto p = new Contexto();
            int i = 1;
            while (true)
            {
                if (Buscar(i) != null)
                {
                    var art = Buscar(i);
                    if(art.Descripcion == producto.Descripcion)
                    {
                        MessageBox.Show("Este producto ya existe, edite el ya existente. " + " Su Id es :" + art.ArticuloId, "Informacion",
                            MessageBoxButton.OK, MessageBoxImage.Information);

                        return true;
                    }
                }
                else
                {
                    return false;
                }
                i++;
            }
        }
    }
}
