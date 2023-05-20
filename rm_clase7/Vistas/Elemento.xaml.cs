﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;
using System.IO;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;


namespace rm_clase7.Vistas
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Elemento : ContentPage
    {
        //Variable global para la clave primaria
        public int idSeleccioando;
        private SQLiteAsyncConnection conexion;

        IEnumerable<Estudiante> RActualizar;
        IEnumerable<Estudiante> REliminar;
                                                  

        public Elemento(int id, string nombre, string usuario, string contrasena)
        {
            InitializeComponent();
            txtID.Text = id.ToString();
            txtNombre.Text = nombre;
            txtUsuario.Text = usuario;
            txtContrasena.Text = contrasena;

            conexion = DependencyService.Get<DataBase>().GetConnection();
            idSeleccioando = id;
        }

        public static IEnumerable<Estudiante> Eliminar(SQLiteConnection db, int id)
        {
            return db.Query<Estudiante>("DELETE FROM Estudiante where id = ?", id);
        }

        public static IEnumerable<Estudiante> Actualizar(SQLiteConnection db,string nombre, string usuario, string contrasena,  int id) 
        {
            return db.Query<Estudiante>("UPDATE Estudiante set Nombre = ?, Usuario = ?, Contrasena = ? where id = ?", nombre, usuario, contrasena, id);
        }

        private void btnActualizar_Clicked(object sender, EventArgs e)
        {
            try
            {
                var ruta = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "uisrael.db3");
                var db = new SQLiteConnection(ruta);
                RActualizar = Actualizar(db, txtNombre.Text, txtUsuario.Text, txtContrasena.Text, idSeleccioando);
                Navigation.PushAsync(new ConsultaRegistros());
            }
            catch (Exception ex)
            {

                DisplayAlert("Alerta", ex.Message, "Cerrar");
            }
        }

        private void btnEliminar_Clicked(object sender, EventArgs e)
        {
            try
            {
                var ruta = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "uisrael.db3");
                var db = new SQLiteConnection(ruta);
                REliminar = Eliminar(db, idSeleccioando);
                Navigation.PushAsync(new ConsultaRegistros());
            }
            catch (Exception ex)
            {

                DisplayAlert("Alerta", ex.Message, "Cerrar");
            }
        }
    }
}