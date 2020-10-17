using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextEspera : MonoBehaviour
{
    public GameObject UserName;
    public GameObject btnjoin;
    public GameObject UserNamee;
    public GameObject idpartida;
    public GameObject inpuidpart;
    public Text texto_cuadro;
    public GameObject cuadro;

    public void Showtext()
    {
        cuadro.SetActive(true);
        UserName.SetActive(false);
        UserNamee.SetActive(false);
        idpartida.SetActive(false);
        inpuidpart.SetActive(false);
    }
}
