using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using MySql.Data.MySqlClient;
using System.Data;

public class RMPJuego : MonoBehaviour
{

    private MySqlConnection conexion;
    private MySqlCommand consola;
    private MySqlConnection conexion2;
    private MySqlCommand consola2;
    public GameObject Mensaje;
    public Text textoMensaje;
    public float timeRemaining = 0.5f;
    private bool gamerunning;
    string idNuevo = "";
    string idAntiguo = "";
    string idJugador = "0";
    string nombreJugador = "";
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
                timeRemaining = 0.5f;
                try
                {

                    string DataConecction = "Server=beerorstain20.mysql.database.azure.com; Port=3306; Database=bosdb; Uid=adminbos@beerorstain20; Pwd=*camaja20*; SslMode=Preferred;";
                    string Query = "SELECT * FROM bosdb.jugadortcarta WHERE idPartida = " + DatosGlobales.IdPartida + " ORDER BY idjugadortcarta DESC LIMIT 1;";

                    conexion = new MySqlConnection(DataConecction);
                    consola = new MySqlCommand(Query, conexion);



                    conexion.Open();
                    MySqlDataReader reader = consola.ExecuteReader();
                    while (reader.Read())
                    {
                        idNuevo = reader["idjugadortcarta"].ToString();
                        idJugador = reader["idJugador"].ToString();
                        
                    }
                    if (idNuevo != "")
                    {
                        if (idNuevo != idAntiguo)
                        {
                            idAntiguo = idNuevo;

                            string DataConecction2 = "Server=beerorstain20.mysql.database.azure.com; Port=3306; Database=bosdb; Uid=adminbos@beerorstain20; Pwd=*camaja20*; SslMode=Preferred;";
                            string Query2 = "SELECT * FROM bosdb.jugador WHERE idJugador = "+idJugador+"";

                            conexion2 = new MySqlConnection(DataConecction2);
                            consola2 = new MySqlCommand(Query2, conexion2);

                            conexion2.Open();
                            MySqlDataReader reader2 = consola2.ExecuteReader();
                            while (reader2.Read())
                            {
                                nombreJugador = reader2["nombre"].ToString();
                            }
                            conexion2.Close();
                            textoMensaje.text = "¡"+nombreJugador+ " tiene la carta actaul!";
                            
                        }
                    }

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
