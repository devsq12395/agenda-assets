using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UI_News : MonoBehaviour {
    
    public static UI_News I;
	public void Awake(){ I = this; }

    public struct News {
        public string name, title, desc;

        public News (string _n){
            name = _n;
            title = "";
            desc = "";
        }
    }

    public GameObject go;

    public TextMeshProUGUI t_title, t_desc;

    public List<News> newsList;

    public void setup (){
        newsList = new List<News> ();

        go.SetActive (true);

        

        go.SetActive (false);
    }

    public void show (bool _isShow, ObjArea _a){
        go.SetActive (_isShow);
        if (_isShow) {
            update_news ();
        }
    }

    public void add_news (string _name, Dictionary<string, string> _details){
        News _news = DB_News.I.get_news_details (_name, _details);
        newsList.Add (_news);
    }

    public void show_next_news (){
        
    }

    public void update_news (){
        News _news = newsList [0];
        t_title.text = _news.title;
        t_desc.text = _news.desc;
    }

    public void btn_next (){

    }
}
