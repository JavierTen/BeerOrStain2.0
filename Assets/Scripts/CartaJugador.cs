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

        if (cartasJugador[nCarta].ToString() == "RegA0" || cartasJugador[nCarta].ToString() == "RegA1" || cartasJugador[nCarta].ToString() == "RegA2" || cartasJugador[nCarta].ToString() == "RegC0" || cartasJugador[nCarta].ToString() == "RegC1" || cartasJugador[nCarta].ToString() == "RegC2" ||  cartasJugador[nCarta].ToString() == "RegJ0" || cartasJugador[nCarta].ToString() == "RegJ1" || cartasJugador[nCarta].ToString() == "RegJ2" || cartasJugador[nCarta].ToString() == "RegK0" ||  cartasJugador[nCarta].ToString() == "RegK1" || cartasJugador[nCarta].ToString() == "RegK2" || cartasJugador[nCarta].ToString() == "RegM0" || cartasJugador[nCarta].ToString() == "RegM1" || cartasJugador[nCarta].ToString() == "RegM2" || cartasJugador[nCarta].ToString() == "RegN0" ||cartasJugador[nCarta].ToString() == "RegP0" || cartasJugador[nCarta].ToString() == "RegP1" ||  cartasJugador[nCarta].ToString() == "RegP2" || cartasJugador[nCarta].ToString() == "RegR0" ||  cartasJugador[nCarta].ToString() == "RegR1" || cartasJugador[nCarta].ToString() == "RegR2" || cartasJugador[nCarta].ToString() == "RegU0" || cartasJugador[nCarta].ToString() == "RegU1" || cartasJugador[nCarta].ToString() == "RegU2" || cartasJugador[nCarta].ToString() == "RegV0" ||cartasJugador[nCarta].ToString() == "RegV1" || cartasJugador[nCarta].ToString() == "RegV2")
        {
            GetComponent<Button>().interactable = false;
        }
    }

}
