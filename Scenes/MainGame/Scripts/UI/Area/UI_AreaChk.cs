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

    public TextMeshProUGUI t_chName;

    public bool isShow;

    public ObjArea selArea;
    public List<GameObject> options;
    public List<TextMeshProUGUI> t_options;

    public void setup (){
        go.SetActive (true);

        

        go.SetActive (false);
    }

    public void show (ObjArea _a){
        if (isShow) return;

        go.SetActive (true);
        isShow = true;

        selArea = _a;
        t_area.text = _a.nameUI;   

        ObjChar _c = MG.I.selChar;
        t_chName.text = _c.nameUI;

        setup_options (_a);
    }

    public void hide (){
        if (!isShow) return;

        go.SetActive (false);
        isShow = false;
    }

    private void setup_options (ObjArea _a){
        List<string> _optStr = _a.options [ContArea.I.get_relation (_a, localPlayerID)];

        for (int i = 0; i < options.Count; i++) {
            if (i < _optStr.Count) {
                options [i].SetActive (true);
                DB_AreasOptions.I.set_values ();
                t_options [i].text = DB_AreasOptions.I.title;
            } else {
                options [i].SetActive (false);
            }
        }
    }
}
