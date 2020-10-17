using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextInstHome : MonoBehaviour
{
    public GameObject BotonU;
    public GameObject Crear;
    public Text texto_cuadro;
    public GameObject cuadro;

    private int click = 0;

    // Start is called before the first frame update
    void Start()
    {
        cuadro.SetActive(false);
        BotonU.SetActive(true);
        Crear.SetActive(true);
    }

    // Update is called once per frame
    public void Showtext()
    {
        if (click == 0)
        {
            cuadro.SetActive(true);
            BotonU.SetActive(false);
            Crear.SetActive(false);
            click = +1;
        }
        else
        {
            cuadro.SetActive(false);
            BotonU.SetActive(true);
            Crear.SetActive(true);
            click = 0;
        }
    }
}
