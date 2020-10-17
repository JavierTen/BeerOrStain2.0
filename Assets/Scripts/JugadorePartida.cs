using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using MySql.Data.MySqlClient;
using System.Data;
public class JugadorePartida : MonoBehaviour
{
    private MySqlConnection conexion;
    private MySqlCommand consola;
    public Text jugadores;

    public float timeRemaining = 1;
    private bool gamerunning;
    void Update()
    {
        if (!gamerunning)
        {
            if (timeRemaining > 0)
            {
                timeRemaining -= Time.deltaTime;
            }
            else
            {
                timeRemaining = 1;
                try
                {
                    
                    string DataConecction = "Server=beerorstain20.mysql.database.azure.com; Port=3306; Database=bosdb; Uid=adminbos@beerorstain20; Pwd=*camaja20*; SslMode=Preferred;";
                    string Query = "SELECT nombre FROM bosdb.jugador where idPartida = "+DatosGlobales.IdPartida+";";

                    conexion = new MySqlConnection(DataConecction);
                    consola = new MySqlCommand(Query, conexion);

                    string nicks = "";
                    conexion.Open();
                    MySqlDataReader reader = consola.ExecuteReader();
                    while (reader.Read())
                    {
                        nicks = nicks + reader["nombre"]+"\n";
                        
                    }
                    jugadores.text = nicks.ToString();
                    
                    conexion.Close();

                }
                catch (MySqlException ex)
                {

                    Debug.LogError("Error: " + ex);
                }
            }
        }
    }
}
