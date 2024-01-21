using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DB_Strings : MonoBehaviour {

    public static DB_Strings I;
	public void Awake(){ I = this; }

    public string get_str (string _str){
        switch (_str) {

            // Area Options titles are set at DB_AreasOptions.cs

            // Area Names
            case "sampArea1": return "Sample Area 1";
            case "sampArea2": return "Sample Area 2";

            // Relations
            case "neutral": return "Neutral";
            
            default: return "";
        }
    }
}
