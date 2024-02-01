using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UI_AreaChk : MonoBehaviour {
    
    public static UI_AreaChk I;
	public void Awake(){ I = this; }

    public GameObject go, goOptBtn;
    public Image btnPanel;

    public TextMeshProUGUI t_area;

    public TextMeshProUGUI t_chName;

    public bool isShow;

    public ObjArea selArea;
    public List<GameObject> options;
    public List<TextMeshProUGUI> t_options;

    public void setup (){
        go.SetActive (true);

        create_opt_btns ();

        go.SetActive (false);
    }

    public void create_opt_btns (){
        int _btnsInCol = 4;
        int _total = 8;

        float _btnWidth = btnPanel.GetComponent<RectTransform>().rect.width / 2f;
        float _btnHeight = btnPanel.GetComponent<RectTransform>().rect.height / _btnsInCol;

        for (int i = 0; i < _total; i++) {
            float _x = (i % 2 == 0) ? 0 : _btnWidth;
            float _y = -((i % _btnsInCol) * _btnHeight);

            GameObject _new = Instantiate(goOptBtn, new Vector3 (_x, _y, 0f), Quaternion.identity);
            _new.transform.SetParent(btnPanel.transform, false);

            TextMeshProUGUI _btnTxt = _new.GetComponentInChildren<TextMeshProUGUI>();
            _btnTxt.text = " ";

            options.Add(_new);
            t_options.Add (_btnTxt);
        }
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
        List<string> _optStr = _a.options [ContArea.I.get_relation (_a, ContPlayers.I.localPlayerID)];

        for (int i = 0; i < options.Count; i++) {
            if (i < _optStr.Count) {
                options [i].SetActive (true);
                DB_AreasOptions.I.set_values (_a.name);
                t_options [i].text = DB_AreasOptions.I.title;
            } else {
                options [i].SetActive (false);
            }
        }
    }
}
