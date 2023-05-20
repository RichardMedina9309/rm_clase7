using System;
using System.Collections.Generic;
using System.Text;
using SQLite; //Utilizar los métodos de la DB 

namespace rm_clase7
{
    public interface DataBase
    {
        //Creamos el método
        SQLiteAsyncConnection GetConnection();  //Defino el método de conexión.

    }
}
