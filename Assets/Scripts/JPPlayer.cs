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
    ArrayList jugadores = new ArrayList();
    public GameObject BUsu_1, BUsu_2, BUsu_3, BUsu_4, BUsu_5, BUsu_6, BUsu_7, BUsu_8, BUsu_9, BUsu_10, BUsu_11, BUsu_12, BUsu_13, BUsu_14;
    public Text TUsu_1, TUsu_2, TUsu_3, TUsu_4, TUsu_5, TUsu_6, TUsu_7, TUsu_8, TUsu_9, TUsu_10, TUsu_11, TUsu_12, TUsu_13, TSUsu_14;
    private int cJugadores;
    //public Text nombre;
    //public int i;
    void Start()
    {
        try
        {
            string DataConecction = "Server=beerorstain20.mysql.database.azure.com; Port=3306; Database=bosdb; Uid=adminbos@beerorstain20; Pwd=*camaja20*; SslMode=Preferred;";
            string Query = "SELECT * FROM bosdb.jugador WHERE idJugador!= "+DatosGlobales.IdJugador+" AND idPartida = "+DatosGlobales.IdPartida+" ;";

            conexion = new MySqlConnection(DataConecction);
            consola = new MySqlCommand(Query, conexion);

            conexion.Open();
            MySqlDataReader reader = consola.ExecuteReader();
            while (reader.Read())
            {
                jugadores.Add(reader["nombre"]);
            }
            conexion.Close();
        }
        catch (MySqlException ex)
        {
            Debug.LogError("Error: " + ex);
        }
        cJugadores = jugadores.Count;

        if (cJugadores == 1)
        {
            TUsu_1.text = jugadores[0].ToString();
            BUsu_2.SetActive(false); BUsu_3.SetActive(false); BUsu_4.SetActive(false); BUsu_5.SetActive(false); BUsu_6.SetActive(false);
            BUsu_7.SetActive(false); BUsu_8.SetActive(false); BUsu_9.SetActive(false); BUsu_10.SetActive(false); BUsu_11.SetActive(false);
            BUsu_12.SetActive(false); BUsu_13.SetActive(false); BUsu_14.SetActive(false); 

        }else if(cJugadores == 2){
            TUsu_1.text = jugadores[0].ToString();
            TUsu_2.text = jugadores[1].ToString();
            BUsu_3.SetActive(false); BUsu_4.SetActive(false); BUsu_5.SetActive(false); BUsu_6.SetActive(false);
            BUsu_7.SetActive(false); BUsu_8.SetActive(false); BUsu_9.SetActive(false); BUsu_10.SetActive(false); BUsu_11.SetActive(false);
            BUsu_12.SetActive(false); BUsu_13.SetActive(false); BUsu_14.SetActive(false); 
        }else if(cJugadores == 3){
            TUsu_1.text = jugadores[0].ToString();
            TUsu_2.text = jugadores[1].ToString();
            TUsu_3.text = jugadores[2].ToString();
            BUsu_4.SetActive(false); BUsu_5.SetActive(false); BUsu_6.SetActive(false);
            BUsu_7.SetActive(false); BUsu_8.SetActive(false); BUsu_9.SetActive(false); BUsu_10.SetActive(false); BUsu_11.SetActive(false);
            BUsu_12.SetActive(false); BUsu_13.SetActive(false); BUsu_14.SetActive(false); 
        }else if(cJugadores == 4){
            TUsu_1.text = jugadores[0].ToString();  TUsu_4.text = jugadores[3].ToString();
            TUsu_2.text = jugadores[1].ToString();
            TUsu_3.text = jugadores[2].ToString();
            BUsu_5.SetActive(false); BUsu_6.SetActive(false);
            BUsu_7.SetActive(false); BUsu_8.SetActive(false); BUsu_9.SetActive(false); BUsu_10.SetActive(false); BUsu_11.SetActive(false);
            BUsu_12.SetActive(false); BUsu_13.SetActive(false); BUsu_14.SetActive(false); 
        }else if(cJugadores == 5){
            TUsu_1.text = jugadores[0].ToString();  TUsu_4.text = jugadores[3].ToString();
            TUsu_2.text = jugadores[1].ToString();  TUsu_5.text = jugadores[4].ToString();
            TUsu_3.text = jugadores[2].ToString();
            BUsu_6.SetActive(false);
            BUsu_7.SetActive(false); BUsu_8.SetActive(false); BUsu_9.SetActive(false); BUsu_10.SetActive(false); BUsu_11.SetActive(false);
            BUsu_12.SetActive(false); BUsu_13.SetActive(false); BUsu_14.SetActive(false); 
        }else if(cJugadores == 6){
            TUsu_1.text = jugadores[0].ToString();  TUsu_4.text = jugadores[3].ToString();
            TUsu_2.text = jugadores[1].ToString();  TUsu_5.text = jugadores[4].ToString();
            TUsu_3.text = jugadores[2].ToString();  TUsu_6.text = jugadores[5].ToString();
            BUsu_7.SetActive(false); BUsu_8.SetActive(false); BUsu_9.SetActive(false); BUsu_10.SetActive(false); BUsu_11.SetActive(false);
            BUsu_12.SetActive(false); BUsu_13.SetActive(false); BUsu_14.SetActive(false); 
        }else if(cJugadores == 7){
            TUsu_1.text = jugadores[0].ToString();  TUsu_4.text = jugadores[3].ToString();  TUsu_7.text = jugadores[6].ToString();
            TUsu_2.text = jugadores[1].ToString();  TUsu_5.text = jugadores[4].ToString();  
            TUsu_3.text = jugadores[2].ToString();  TUsu_6.text = jugadores[5].ToString();  
            BUsu_8.SetActive(false); BUsu_9.SetActive(false); BUsu_10.SetActive(false); BUsu_11.SetActive(false);
            BUsu_12.SetActive(false); BUsu_13.SetActive(false); BUsu_14.SetActive(false); 
        }else if(cJugadores == 8){
            TUsu_1.text = jugadores[0].ToString();  TUsu_4.text = jugadores[3].ToString();  TUsu_7.text = jugadores[6].ToString();
            TUsu_2.text = jugadores[1].ToString();  TUsu_5.text = jugadores[4].ToString();  TUsu_8.text = jugadores[7].ToString();
            TUsu_3.text = jugadores[2].ToString();  TUsu_6.text = jugadores[5].ToString();  
            BUsu_9.SetActive(false); BUsu_10.SetActive(false); BUsu_11.SetActive(false);
            BUsu_12.SetActive(false); BUsu_13.SetActive(false); BUsu_14.SetActive(false); 
        }else if(cJugadores == 9){
            TUsu_1.text = jugadores[0].ToString();  TUsu_4.text = jugadores[3].ToString();  TUsu_7.text = jugadores[6].ToString();
            TUsu_2.text = jugadores[1].ToString();  TUsu_5.text = jugadores[4].ToString();  TUsu_8.text = jugadores[7].ToString();
            TUsu_3.text = jugadores[2].ToString();  TUsu_6.text = jugadores[5].ToString();  TUsu_9.text = jugadores[8].ToString();
            BUsu_10.SetActive(false); BUsu_11.SetActive(false);
            BUsu_12.SetActive(false); BUsu_13.SetActive(false); BUsu_14.SetActive(false); 
        }else if(cJugadores == 10){
            TUsu_1.text = jugadores[0].ToString();  TUsu_4.text = jugadores[3].ToString();  TUsu_7.text = jugadores[6].ToString();  TUsu_10.text = jugadores[9].ToString();
            TUsu_2.text = jugadores[1].ToString();  TUsu_5.text = jugadores[4].ToString();  TUsu_8.text = jugadores[7].ToString();
            TUsu_3.text = jugadores[2].ToString();  TUsu_6.text = jugadores[5].ToString();  TUsu_9.text = jugadores[8].ToString();
            BUsu_11.SetActive(false);
            BUsu_12.SetActive(false); BUsu_13.SetActive(false); BUsu_14.SetActive(false); 
        }else if(cJugadores == 11){
            //TUsu_1.text = jugadores[i].ToString();  //TUsu_4.text = jugadores[i].ToString();  //TUsu_7.text = jugadores[i].ToString();  //TUsu_10.text = jugadores[i].ToString();
            //TUsu_2.text = jugadores[i].ToString();  //TUsu_5.text = jugadores[i].ToString();  //TUsu_8.text = jugadores[i].ToString();   //TUsu_11.text = jugadores[i].ToString();
            //TUsu_3.text = jugadores[i].ToString();  //TUsu_6.text = jugadores[i].ToString();  //TUsu_9.text = jugadores[i].ToString();
            BUsu_12.SetActive(false); BUsu_13.SetActive(false); BUsu_14.SetActive(false); 
        }else if(cJugadores == 12){
            //TUsu_1.text = jugadores[i].ToString();  //TUsu_4.text = jugadores[i].ToString();  //TUsu_7.text = jugadores[i].ToString();  //TUsu_10.text = jugadores[i].ToString();
            //TUsu_2.text = jugadores[i].ToString();  //TUsu_5.text = jugadores[i].ToString();  //TUsu_8.text = jugadores[i].ToString();  //TUsu_11.text = jugadores[i].ToString();
            //TUsu_3.text = jugadores[i].ToString();  //TUsu_6.text = jugadores[i].ToString();  //TUsu_9.text = jugadores[i].ToString();  //TUsu_12.text = jugadores[i].ToString();
            BUsu_13.SetActive(false); BUsu_14.SetActive(false); 
        }else if(cJugadores == 13){
            //TUsu_1.text = jugadores[i].ToString();  //TUsu_4.text = jugadores[i].ToString();  //TUsu_7.text = jugadores[i].ToString();  //TUsu_10.text = jugadores[i].ToString();
            //TUsu_2.text = jugadores[i].ToString();  //TUsu_5.text = jugadores[i].ToString();  //TUsu_8.text = jugadores[i].ToString();  //TUsu_11.text = jugadores[i].ToString();
            //TUsu_3.text = jugadores[i].ToString();  //TUsu_6.text = jugadores[i].ToString();  //TUsu_9.text = jugadores[i].ToString();  //TUsu_12.text = jugadores[i].ToString();
            //TUsu_13.text = jugadores[i].ToString();
            BUsu_14.SetActive(false); 
        }else if(cJugadores == 13){
            //TUsu_1.text = jugadores[i].ToString();  //TUsu_4.text = jugadores[i].ToString();  //TUsu_7.text = jugadores[i].ToString();  //TUsu_10.text = jugadores[i].ToString();
            //TUsu_2.text = jugadores[i].ToString();  //TUsu_5.text = jugadores[i].ToString();  //TUsu_8.text = jugadores[i].ToString();  //TUsu_11.text = jugadores[i].ToString();
            //TUsu_3.text = jugadores[i].ToString();  //TUsu_6.text = jugadores[i].ToString();  //TUsu_9.text = jugadores[i].ToString();  //TUsu_12.text = jugadores[i].ToString();
            //TUsu_13.text = jugadores[i].ToString(); //TUsu_14.text = jugadores[i].ToString();
            
        }


    }

}
