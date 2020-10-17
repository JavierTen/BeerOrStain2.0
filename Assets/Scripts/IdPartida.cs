using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using MySql.Data.MySqlClient;
using System.Data;


public class IdPartida : MonoBehaviour
{
    private MySqlConnection conexion;
    private MySqlCommand consola;

    public Text idPartida;
    void Start()
    {
        try
        {

            string DataConecction = "Server=beerorstain20.mysql.database.azure.com; Port=3306; Database=bosdb; Uid=adminbos@beerorstain20; Pwd=*camaja20*; SslMode=Preferred;";
            string Query = "SELECT idPartida FROM bosdb.partida ORDER BY idPartida DESC LIMIT 1";

            conexion = new MySqlConnection(DataConecction);
            consola = new MySqlCommand(Query, conexion);

            conexion.Open();
            MySqlDataReader reader = consola.ExecuteReader();
            while (reader.Read())
            {
                DatosGlobales.IdPartida =reader["idPartida"].ToString();
            }
            idPartida.text = DatosGlobales.IdPartida.ToString();
            conexion.Close();

        }
        catch (MySqlException ex)
        {

            Debug.LogError("Error: " + ex);
        }
    }

}
