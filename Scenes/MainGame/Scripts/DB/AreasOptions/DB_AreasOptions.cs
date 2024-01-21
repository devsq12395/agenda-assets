using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DB_AreasOptions : MonoBehaviour {

    public static DB_AreasOptions I;
	public void Awake(){ I = this; }

    public string title, desc;

    public void set_values (string _str){
        switch (_str) {
            case "connect": 
                title = "Establish Connections";
                desc = "Make friends with the people of this area, improving your connection status.";

                break;
            
            default: 
                title = "";
                desc = "";

                break;
        }
    }
}
