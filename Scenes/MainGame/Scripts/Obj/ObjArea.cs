using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ObjArea : MonoBehaviour {  

    [Header("------ UNITY EDITOR EDITABLE PARTS ------")]
    public string name;
    public string nameUI;
    public List<string> tags, optEnemies, optNeutral, optFriends;

    [Header("------ NON-EDITABLE PARTS ------")]
    public GameObject go;
    public int id;
    public RectTransform rect;
    public Dictionary <string, List<string>> options;
    public List<int> connections;
    public Dictionary <string, string> relation;
    public Dictionary <string, int> relationNumVal;

    public void setup (){
        go = gameObject;
        options = new Dictionary <string, List<string>> ();
        relation = new Dictionary <string, string> ();
        id = Misc.I.generate_id ();

        options.Add ("enemies", new List<string>(optEnemies));
        options.Add ("neutral", new List<string>(optNeutral));
        options.Add ("friends", new List<string>(optFriends));
    }

    public void select (){
        ContChars.I.select_area (this);
    }
}