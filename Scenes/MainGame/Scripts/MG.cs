using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MG : MonoBehaviour {
    public static MG I;
	public void Awake(){ I = this; }

    void Start() {
        // TEST
        PlayerPrefs.SetString ("map", "testMap");

        ContMap.I.setup_map ();
        ContPlayers.I.setup ();
        ContChars.I.setup ();

        UI_CharPane.I.setup ();
        UI_AreaChk.I.setup ();
    }

    void Update() {
        ContChars.I.game_update ();
    }

    public void change_scene (string _scene){
        
    }
}
