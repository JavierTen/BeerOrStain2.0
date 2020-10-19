using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using MySql.Data.MySqlClient;
using System.Data;


public class CartaJugador : MonoBehaviour
{
    private MySqlConnection conexion;
    private MySqlCommand consola;

    ArrayList cartasJugador = new ArrayList();
    public int nCarta;
    public string boton;
    private Image cartaBoton;
    void Awake()
    {
        try
        {
            string DataConecction = "Server=beerorstain20.mysql.database.azure.com; Port=3306; Database=bosdb; Uid=adminbos@beerorstain20; Pwd=*camaja20*; SslMode=Preferred;";
            string Query = "SELECT idJugador FROM bosdb.jugador WHERE idPartida = " + DatosGlobales.IdPartida + " AND nombre = '" + DatosGlobales.NickUsuario + "';";

            conexion = new MySqlConnection(DataConecction);
            consola = new MySqlCommand(Query, conexion);


            conexion.Open();
            MySqlDataReader reader = consola.ExecuteReader();
            while (reader.Read())
            {
                DatosGlobales.IdJugador = reader["idJugador"].ToString();
            }

            conexion.Close();

        }
        catch (MySqlException ex)
        {

            Debug.LogError("Error: " + ex);
        }
    }
    void Start()
    {
        try
        {
            string DataConecction = "Server=beerorstain20.mysql.database.azure.com; Port=3306; Database=bosdb; Uid=adminbos@beerorstain20; Pwd=*camaja20*; SslMode=Preferred;";
            string Query = "SELECT nombre FROM bosdb.cartajugador WHERE idPartida = " + DatosGlobales.IdPartida + " AND idJugador = " + DatosGlobales.IdJugador + ";";

            conexion = new MySqlConnection(DataConecction);
            consola = new MySqlCommand(Query, conexion);

            conexion.Open();
            MySqlDataReader reader = consola.ExecuteReader();
            while (reader.Read())
            {
                cartasJugador.Add(reader["nombre"]);
            }
            conexion.Close();


            cartaBoton = GameObject.Find(boton).GetComponent<Image>();


        }
        catch (MySqlException ex)
        {

            Debug.LogError("Error: " + ex);
        }

    }

    void Update()
    {
        cartaBoton.sprite = Resources.Load<Sprite>("Images/" + cartasJugador[nCarta]);
    }

    public void LanzarCarta()
    {
        if (DatosGlobales.CartaActualPiramide == cartasJugador[nCarta].ToString())
        {
            GetComponent<Button>().interactable = false;
        }

        else if (cartasJugador[nCarta] == "RegA0" || cartasJugador[nCarta] == "RegA1" || cartasJugador[nCarta] == "RegA2" || cartasJugador[nCarta] == "RegC0" || cartasJugador[nCarta] == "RegC1" || cartasJugador[nCarta] == "RegC2" ||  cartasJugador[nCarta] == "RegJ0" || cartasJugador[nCarta] == "RegJ1" || cartasJugador[nCarta] == "RegJ2" || cartasJugador[nCarta] == "RegK0" ||  cartasJugador[nCarta] == "RegK1" || cartasJugador[nCarta] == "RegK2" || cartasJugador[nCarta] == "RegM0" || cartasJugador[nCarta] == "RegM1" || cartasJugador[nCarta] == "RegM2" || cartasJugador[nCarta] == "RegN0" ||cartasJugador[nCarta] == "RegP0" || cartasJugador[nCarta] == "RegP1" ||  cartasJugador[nCarta] == "RegP2" || cartasJugador[nCarta] == "RegR0" ||  cartasJugador[nCarta] == "RegR1" || cartasJugador[nCarta] == "RegR2" || cartasJugador[nCarta] == "RegU0" || cartasJugador[nCarta] == "RegU1" || cartasJugador[nCarta] == "RegU2" || cartasJugador[nCarta] == "RegV0" ||cartasJugador[nCarta] == "RegV1" || cartasJugador[nCarta] == "RegV2")
        {
            GetComponent<Button>().interactable = false;
        }
    }

}
