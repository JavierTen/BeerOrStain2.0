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
    public GameObject Mensaje;
    public float timeRemaining = 0.5f;
    private bool gamerunning;
    string idNuevo = "";
    string idAntiguo = "";
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
                    string Query = "SELECT * FROM bosdb.jugadortcarta WHERE idPartida = "+DatosGlobales.IdPartida+" ORDER BY idjugadortcarta DESC LIMIT 1;";

                    conexion = new MySqlConnection(DataConecction);
                    consola = new MySqlCommand(Query, conexion);

                    

                    conexion.Open();
                    MySqlDataReader reader = consola.ExecuteReader();
                    while (reader.Read())
                    {
                        idNuevo = reader["idjugadortcarta"].ToString();
                    }
                    if (idNuevo != "")
                    {
                        if(idNuevo != idAntiguo ){
                            idAntiguo = idNuevo;
                            Mensaje.SetActive(true);
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
