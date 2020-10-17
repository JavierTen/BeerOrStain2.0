using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using MySql.Data.MySqlClient;
using System.Data;

public class CPModerador : MonoBehaviour
{
    private MySqlConnection conexion;
    private MySqlCommand consola;
    public float timeRemaining = 3;
    private bool gamerunning;
    public Text texto;
    public GameObject Mensaje;
    int item = 0;
    private int click = 0;
    ArrayList cartasPiramide = new ArrayList();

    private SpriteRenderer rend;
    private Sprite carta;

    void Start()
    {
        try
        {
            string DataConecction = "Server=beerorstain20.mysql.database.azure.com; Port=3306; Database=bosdb; Uid=adminbos@beerorstain20; Pwd=*camaja20*; SslMode=Preferred;";
            string Query = "SELECT nombre FROM bosdb.cartapiramide WHERE idPartida = " + DatosGlobales.IdPartida + ";";

            conexion = new MySqlConnection(DataConecction);
            consola = new MySqlCommand(Query, conexion);

            conexion.Open();
            MySqlDataReader reader = consola.ExecuteReader();
            while (reader.Read())
            {
                cartasPiramide.Add(reader["nombre"]);
            }
            conexion.Close();

        }
        catch (MySqlException ex)
        {
            Debug.LogError("Error: " + ex);
        }


    }
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
                if (item < 15)
                {
                    rend = GetComponent<SpriteRenderer>();
                    Debug.Log(cartasPiramide[item]);
                    carta = Resources.Load<Sprite>("Images/" + cartasPiramide[item].ToString());
                    EnviarCarta(cartasPiramide[item].ToString());
                    item = item + 1;
                    rend.sprite = carta;
                    transform.localScale = new Vector3(0.2156625f, 0.2178207f, 1f);

                }
                timeRemaining = 20;
            }
        }
    }

    public void EnviarCarta(string carta)
    {
        try
        {
            string DataConecction = "Server=beerorstain20.mysql.database.azure.com; Port=3306; Database=bosdb; Uid=adminbos@beerorstain20; Pwd=*camaja20*; SslMode=Preferred;";
            string Query = "INSERT INTO bosdb.cartaspiramidejugador (carta, idPartida) VALUES ('" + carta + "'," + DatosGlobales.IdPartida + ");";

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

    public void ChangeGameRunningState()
    {
        gamerunning = !gamerunning;
        if (click == 0)
        {
            texto.text = "CONTINUAR";
            click = +1;
        }
        else
        {
            texto.text = "PAUSAR";
            Mensaje.SetActive(false);
            click = 0;

        }

    }
}
