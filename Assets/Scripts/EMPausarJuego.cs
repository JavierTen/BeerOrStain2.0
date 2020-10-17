using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MySql.Data.MySqlClient;
using System.Data;

public class EMPausarJuego : MonoBehaviour
{
    private MySqlConnection conexion;
    private MySqlCommand consola;
   public void EMPJuego(){
       try
        {
            string DataConecction = "Server=beerorstain20.mysql.database.azure.com; Port=3306; Database=bosdb; Uid=adminbos@beerorstain20; Pwd=*camaja20*; SslMode=Preferred;";
            string Query = "INSERT INTO bosdb.jugadortcarta(carta, idJugador, idPartida) VALUES ('"+DatosGlobales.CartaActualPiramide+"',"+DatosGlobales.IdJugador+","+DatosGlobales.IdPartida+");";

            conexion = new MySqlConnection(DataConecction);
            consola = new MySqlCommand(Query, conexion);

            conexion.Open();
            consola.ExecuteReader();
            conexion.Close();

        }
        catch (MySqlException ex)
        {

            Debug.LogError("Error: "+ex);
        }
   }
}
