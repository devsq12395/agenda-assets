using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContPlayers : MonoBehaviour {

    public static ContPlayers I;
	public void Awake(){ I = this; }

    public struct Player {
        public string name;
        public int id;

        public Player (string _n, int _id){
            name = _n;
            id = _id;
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
        ContArea.I.add_relations (_new);

        return _new;
    }
}