using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PosicionBotones : MonoBehaviour
{
   public GameObject boton;
   public int x,y;

    void Start()
    {
        Instantiate(boton, new Vector2(x,y), transform.rotation); 
    }

}
