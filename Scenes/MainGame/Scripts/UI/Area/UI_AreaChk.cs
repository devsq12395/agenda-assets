using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UI_AreaChk : MonoBehaviour {
    
    public static UI_AreaChk I;
	public void Awake(){ I = this; }

    public GameObject go;

    public TextMeshProUGUI t_area;

    public void setup (){
        go.SetActive (true);

        

        go.SetActive (false);
    }

    public void show (ObjArea _a){
        t_area.text = _a.nameUI;
    }
}
