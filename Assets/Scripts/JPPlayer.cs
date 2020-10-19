using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using MySql.Data.MySqlClient;
using System.Data;

public class JPPlayer : MonoBehaviour
{
    private MySqlConnection conexion;
    private MySqlCommand consola;
    public Vector2 pos;
    ArrayList cartasPiramide = new ArrayList();
    public GameObject boton;
    public Text nombre;
    void Start()
    {
        try
        {
            string DataConecction = "Server=beerorstain20.mysql.database.azure.com; Port=3306; Database=bosdb; Uid=adminbos@beerorstain20; Pwd=*camaja20*; SslMode=Preferred;";
            string Query = "SELECT * FROM bosdb.jugador WHERE idPartida = 4060";

            conexion = new MySqlConnection(DataConecction);
            consola = new MySqlCommand(Query, conexion);

            conexion.Open();
            MySqlDataReader reader = consola.ExecuteReader();
            while (reader.Read())
            {            
                nombre.text = reader["nombre"].ToString(); 
                Instantiate(boton);
                transform.position = pos;                     
            }
            conexion.Close();
        }
        catch (MySqlException ex)
        {
            Debug.LogError("Error: " + ex);
        }

    }

}
