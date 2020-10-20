using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using MySql.Data.MySqlClient;
using System.Data;

public class RMCRegla : MonoBehaviour
{
    private MySqlConnection conexion;
    private MySqlCommand consola;
    private MySqlConnection conexion2;
    private MySqlCommand consola2;
    public GameObject Mensaje;
    public Text textoMensaje;
    public float timeRemaining = 0.3f;
    private bool gamerunning;
    string idNuevo = "";
    string idAntiguo = "";
    string idJugador = "0";
    string nombreJugador = "";
    string cartaRegla = "";
    ArrayList Verdad = new ArrayList();
    ArrayList Reto = new ArrayList();
    void Start()
    {
        Verdad.Add("¿Tienes una fantasía sexual prohibida?");
        Verdad.Add("¿Has besado a alguien de tu mismo sexo?");
        Verdad.Add("¿Tienes algún fetiche que me quieras confesar?");
        Verdad.Add("¿Tienes una página porno favorita?");
        Verdad.Add("¿Qué categoría porno es tu favorita?");
        Verdad.Add("¿Has entrado a alguna página de cybersex?");
        Verdad.Add("¿Alguna vez has pensado en ser infiel?");
        Verdad.Add("¿Qué harías si te quedas sin papel en un baño público?");
        Verdad.Add("¿Cuál es tu insulto favorito y extraño?");
        Verdad.Add("¿Cuál es la parte que más te gusta de tu cuerpo?");

        Reto.Add("Bromea llamando a alguien e intenta hablar durante 2 minutos seguidos");
        Reto.Add("Confiésate con tu crush por un mensaje. Envía captura de pantalla de la conversación.");
        Reto.Add("Escribe un estado en Facebook alabándome.");
        Reto.Add("Cierra los ojos y escribe un mensaje sin ver. Envíalo a alguien al azar y haz una captura de pantalla de la conversación como prueba.");
        Reto.Add("Lleva toda tu ropa al revés durante 15 min.");
        Reto.Add("Llama a alguien y confiésale tu nuevo amor por Justin Bieber.");
        Reto.Add("Llena tu boca de agua y di tu nombre completo.");
        Reto.Add("Envíame el enlace del último video de YouTube que viste.");
        Reto.Add("Hacer 25 abdominales sin parar.");
        Reto.Add("Rompe dos huevos en tu cabeza y luego hazte una selfie.");


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
                timeRemaining = 0.3f;
                try
                {

                    string DataConecction = "Server=beerorstain20.mysql.database.azure.com; Port=3306; Database=bosdb; Uid=adminbos@beerorstain20; Pwd=*camaja20*; SslMode=Preferred;";
                    string Query = "SELECT * FROM bosdb.rcregla WHERE idPartida = " + DatosGlobales.IdPartida + " ORDER BY idrcRegla DESC LIMIT 1;";

                    conexion = new MySqlConnection(DataConecction);
                    consola = new MySqlCommand(Query, conexion);



                    conexion.Open();
                    MySqlDataReader reader = consola.ExecuteReader();
                    while (reader.Read())
                    {
                        idNuevo = reader["idrcRegla"].ToString();
                        idJugador = reader["idJugador"].ToString();
                        cartaRegla = reader["carta"].ToString();

                    }
                    if (idNuevo != "")
                    {
                        if (idNuevo != idAntiguo)
                        {
                            idAntiguo = idNuevo;

                            string DataConecction2 = "Server=beerorstain20.mysql.database.azure.com; Port=3306; Database=bosdb; Uid=adminbos@beerorstain20; Pwd=*camaja20*; SslMode=Preferred;";
                            string Query2 = "SELECT * FROM bosdb.jugador WHERE idJugador = " + idJugador + "";

                            conexion2 = new MySqlConnection(DataConecction2);
                            consola2 = new MySqlCommand(Query2, conexion2);

                            conexion2.Open();
                            MySqlDataReader reader2 = consola2.ExecuteReader();
                            while (reader2.Read())
                            {
                                nombreJugador = reader2["nombre"].ToString();
                            }
                            conexion2.Close();
                            if (cartaRegla == "RegA0" || cartaRegla == "RegA1" || cartaRegla == "RegA2")
                            {
                                textoMensaje.text = "¡" + nombreJugador + " a utilizado el comodin ANULAR!\nEsto anula cualquier acción impuesta por otro jugador.\nSolo aplica para quien utilizó el comodin";

                            }
                            else if (cartaRegla == "RegC0" || cartaRegla == "RegC1" || cartaRegla == "RegC2")
                            {
                                textoMensaje.text = "¡" + nombreJugador + " a activado la REGLA CAMILO!\nA la cuenta de 3\nEl último jugador en tocar la mesa con la frente debe beber.";

                            }
                            else if (cartaRegla == "RegJ0" || cartaRegla == "RegJ1" || cartaRegla == "RegJ2")
                            {
                                textoMensaje.text = "¡" + nombreJugador + " a activadp la REGLA JAVIER!\nEl ultimo jugador en enviar regalar trago deberá lamerle la mejilla a otro de los jugadores\n" +
                                                    "de no cumplirlo deberá beber 3 tragos grandes\n" +
                                                    "¡Equivalentes a media cerveza!\n";

                            }
                            else if (cartaRegla == "RegK0" || cartaRegla == "RegK1" || cartaRegla == "RegK2")
                            {
                                textoMensaje.text = "¡" + nombreJugador + " a utilizado el comodin KARMA!\nEsto devuelve cualquier acción impuesta por otro jugador.\nSolo aplica para quien utilizó el comodin.";

                            }
                            else if (cartaRegla == "RegK0" || cartaRegla == "RegK1" || cartaRegla == "RegK2")
                            {
                                textoMensaje.text = "¡" + nombreJugador + " a utilizado el comodin KARMA!\nEsto devuelve cualquier acción impuesta por otro jugador.\nSolo aplica para quien utilizó el comodin.";

                            }
                            else if (cartaRegla == "RegM0" || cartaRegla == "RegM1" || cartaRegla == "RegM2")
                            {
                                textoMensaje.text = "¡" + nombreJugador + " a activado la REGLA MALU!\nCada oración que se vaya a decir debe comenzar con POLA y terminar con MANCHA. Si un jugador olvida decir esas palabras, debe beber\n" +
                                                    "¡Finaliza al momento de que alguien se equivoque!\n";

                            }
                            else if (cartaRegla == "RegN0" || cartaRegla == "RegN1" || cartaRegla == "RegN2")
                            {
                                textoMensaje.text = "¡" + nombreJugador + " a activado el juego YO NUNCA!\nSe hace un ronda donde cada jugador dice YO NUNCA HE + una actividad\nLos jugadores que hayan realizado dicha actividad deberan beber";

                            }
                            else if (cartaRegla == "RegP0" || cartaRegla == "RegP1" || cartaRegla == "RegP2")
                            {
                                textoMensaje.text = "¡" + nombreJugador + " a activado el juego QUE PROBABILIDAD HAY DE QUE!\nQuien activo el juego puede escoger otro jugador y realizar este juego." +
                                                    "\nDebera decir 'QUE PROBABILIDAD HAY DE QUE' + una acción." +
                                                    "\nA la cuenta de 3 los participantes del juegon diran un numero entre el 1 y el 3." +
                                                    "\nSi los jugadores coinciden en numero el jugador retado debera cumplir la accíon de lo contrario se salva";

                            }
                            else if (cartaRegla == "RegR0" || cartaRegla == "RegR1" || cartaRegla == "RegR2")
                            {
                                int numero = Random.Range(1, Reto.Count);
                                int numeroR = Random.Range(1, DatosGlobales.CantidadJugadores);
                                textoMensaje.text = "¡" + nombreJugador + " a activado el juego RETOS!\nLos jugadores deberan decir un entre la cantidad de jugadores, quien diga el siguiente numero: " + numero + "debera cumplir el siguiente reto\n" +
                                                    Reto[numeroR].ToString();

                            }
                            else if (cartaRegla == "RegU0" || cartaRegla == "RegU1" || cartaRegla == "RegU2")
                            {
                                textoMensaje.text = "¡" + nombreJugador + " a activado el juego UNA NOCHE!\nlos jugadores deberan referinces entre si por el nombre de una persona con la que hayan estado sexualmente.\n" +
                                                    "Finaliza cuando un jugador se equivoque.";

                            }
                            else if (cartaRegla == "RegV0" || cartaRegla == "RegV1" || cartaRegla == "RegV2")
                            {
                                int numero = Random.Range(1, Verdad.Count);
                                int numeroR = Random.Range(1, DatosGlobales.CantidadJugadores);
                                textoMensaje.text = "¡" + nombreJugador + " a activado el juego VERDADES!\nLos jugadores deberan decir un entre la cantidad de jugadores, quien diga el siguiente numero: " + numero + "debera responder la siguiente pregunta\n" +
                                                    Verdad[numeroR].ToString();

                            }

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
