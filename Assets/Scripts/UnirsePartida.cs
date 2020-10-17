using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using MySql.Data.MySqlClient;
using System.Data;
using UnityEngine.SceneManagement;

public class UnirsePartida : MonoBehaviour
{
    private MySqlConnection conexion;
    private MySqlCommand consola;
    public InputField partida;
    public InputField nick;
    public float timeRemaining = 3;
    private bool gamerunning;

    string idPartida = "0";

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
                    string Query = "SELECT estado FROM bosdb.partida WHERE idPartida = " + idPartida + " ;";

                    conexion = new MySqlConnection(DataConecction);
                    consola = new MySqlCommand(Query, conexion);

                    string estado = "";
                    conexion.Open();
                    MySqlDataReader reader = consola.ExecuteReader();
                    while (reader.Read())
                    {
                        estado = reader["estado"].ToString();
                        if (estado == "1")
                        {
                            SceneManager.LoadScene("Player");
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
    public void Uniser()
    {
        try
        {
            string DataConecction = "Server=beerorstain20.mysql.database.azure.com; Port=3306; Database=bosdb; Uid=adminbos@beerorstain20; Pwd=*camaja20*; SslMode=Preferred;";
            string Query = "INSERT INTO bosdb.jugador(nombre, idPartida, rol) VALUES ('" + nick.text + "'," + partida.text + ",1)";
            idPartida =partida.text;
            DatosGlobales.NickUsuario = nick.text;
            DatosGlobales.IdPartida = idPartida;

            conexion = new MySqlConnection(DataConecction);
            consola = new MySqlCommand(Query, conexion);

            conexion.Open();
            consola.ExecuteReader();
            conexion.Close();
        }
        catch (MySqlException ex)
        {
            Debug.LogError("Error: " + ex);
        }
    }
}
