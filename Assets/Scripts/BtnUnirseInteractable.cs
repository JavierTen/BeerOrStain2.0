using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BtnUnirseInteractable : MonoBehaviour
{
    public void Deshabilitar(){
        GetComponent<Button>().interactable = false;
    }
}
