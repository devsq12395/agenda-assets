using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DB_News : MonoBehaviour {

    public static DB_News I;
	public void Awake(){ I = this; }

    public UI_News.News get_news_details (string _name, Dictionary<string, string> _details){
        UI_News.News _ret = new UI_News.News ();
        switch (_name) {

            case "test":
                _ret.title = "TEstingg";
                _ret.desc = _details["char1"] + " is testing";
                break;
        }

        return _ret;
    }
}
