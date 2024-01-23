using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContPlayers : MonoBehaviour {

    public static ContPlayers I;
	public void Awake(){ I = this; }

    public struct Player {
        public string name;
        public int id;
        public ObjArea cBase;

        public Player (string _n, int _id){
            name = _n;
            id = _id;
            cBase = null;
        }
    };

    public List<Player> players;

    public void setup (){
        players = new List<Player> ();
        players.Add (create_player ("p1", 1));
        players.Add (create_player ("p2", 2)); 
    }

    public Player create_player (string _n, int _id){
        Player _new = new Player (_n, _id);
        players.Add (_new);
        Debug.Log ($"base{_id}");
        _new.cBase = ContArea.I.get_areas_with_tag ($"base{_id}")[0];
        ContArea.I.add_relations (_new);

        return _new;
    }

    // GETs
    public Player get_player_from_id (int _id){
        return players.Find(player => player.id == _id);
    }
}