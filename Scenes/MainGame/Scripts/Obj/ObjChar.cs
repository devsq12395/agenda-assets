using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ObjChar : MonoBehaviour {  

    public GameObject go, goSelUI;

    public string name, nameUI;
    public int hp, hpMax;
    public int bs_CBT;

    public int owner;

    public string task = "idle";
    public int tsk_curAreaID;
    public float tsk_dur;

    public void select (){
        ContChars.I.select_char (this);
    }
}