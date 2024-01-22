using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UI_CharPane : MonoBehaviour {
    
    public static UI_CharPane I;
	public void Awake(){ I = this; }

    public GameObject go;

    public List<UI_CharPaneObj> charList;

    public void setup (){
        go.SetActive (true);

        charList = new List<UI_CharPaneObj>();
    }

    public void create_char (string _name){

    }
}
