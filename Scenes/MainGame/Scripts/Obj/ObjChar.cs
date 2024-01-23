using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ObjChar : MonoBehaviour {  

    public GameObject go;

    public string name, nameUI;
    public int hp, hpMax;
    public int bs_CBT;

    public int owner;

    public string task = "idle";
    public int tsk_curAreaID;
    public float tsk_dur;

    void Start (){
        
    }
}