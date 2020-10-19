using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using MySql.Data.MySqlClient;
using System.Data;

public class SJToma : MonoBehaviour
{
    public GameObject panel;
    private MySqlConnection conexion;
    private MySqlCommand consola;

    public Text nombreJugadorToma;

    public void Enviar()
    {
        try
        {
            string DataConecction = "Server=beerorstain20.mysql.database.azure.com; Port=3306; Database=bosdb; Uid=adminbos@beerorstain20; Pwd=*camaja20*; SslMode=Preferred;";
            string Query = "INSERT INTO bosdb.jugadortoma (jugadorTomam,idjugadorEnv) VALUES ('"+nombreJugadorToma.text+"',"+DatosGlobales.IdJugador+");;";

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
        panel.SetActive(false);

    }
}
