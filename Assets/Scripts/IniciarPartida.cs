using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MySql.Data.MySqlClient;
using System.Data;
    
public class IniciarPartida : MonoBehaviour
{
    private MySqlConnection conexion;
    private MySqlCommand consola;

    public void Iniciar(){
        try
        {
            string DataConecction = "Server=beerorstain20.mysql.database.azure.com; Port=3306; Database=bosdb; Uid=adminbos@beerorstain20; Pwd=*camaja20*; SslMode=Preferred;";
            string Query = "UPDATE bosdb.partida SET estado = 1 WHERE idPartida = "+DatosGlobales.IdPartida+";";

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
