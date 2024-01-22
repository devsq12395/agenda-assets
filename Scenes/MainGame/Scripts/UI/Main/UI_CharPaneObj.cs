using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UI_CharPaneObj : MonoBehaviour {
    public GameObject go;

    public TextMeshProUGUI t_area;

    public int ID;

    public void setup (){
        go.SetActive (true);

        

        go.SetActive (false);
    }

    public void show (ObjArea _a){
        t_area.text = _a.nameUI;
    }
}
