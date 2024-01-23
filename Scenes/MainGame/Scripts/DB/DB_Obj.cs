using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DB_Obj : MonoBehaviour {

    public static DB_Obj I;
	public void Awake(){ I = this; }

    public GameObject dummy;

    // Chars
    public GameObject testchar;

    void Start() {
        
    }

    void Update() {
        
    }

    public GameObject get_game_obj (string _name) {
        GameObject _refObj = GameObject.Instantiate(dummy, new Vector3(0, 0, -1), Quaternion.Euler(new Vector3(0, 0, 0))) as GameObject;
        Destroy (_refObj);
        
        switch (_name) {
            // Chars
            case "testchar":                    _refObj = testchar; break;

            default: _refObj = dummy; break;
        }

        GameObject _retVal = GameObject.Instantiate(_refObj, new Vector3(0, 0, -1), Quaternion.Euler(new Vector3(0, 0, 0))) as GameObject; 
        return _retVal;
    }
}
