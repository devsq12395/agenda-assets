using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContChars : MonoBehaviour {

    public static ContChars I;
	public void Awake(){ I = this; }

    public List<ObjChar> chars;

    public void setup (){
        chars = new List<ObjChar> ();
    }

    public void game_update (){
        foreach (ObjChar _c in chars) {
            update_task_dur (_c);
        }
    }

    // Create
    public void create_char (string _name, int _owner){
        ObjArea _spawnArea = ContArea.I.get_areas_with_tag ($"base{_owner}")[0];
        if (!_spawnArea){
            Debug.Log ("Base for this char does not exist. Aborting spawn...");
            return;
        }

        ContPlayers.Player _p = ContPlayers.I.get_player_from_id (_owner);

        GameObject _newObj = DB_Obj.I.get_game_obj ("testchar");
        ObjChar _new = _newObj.GetComponent<ObjChar>();
        _new.owner = _owner;
        _new.go = _newObj;
        chars.Add (_new);
        assign_task (_new, "idle", _p.cBase);
    }

    // Action
    public void assign_task (ObjChar _c, string _t, ObjArea _area) {
        DB_Tasks.TaskData _data = DB_Tasks.I.get_task_data (_t);

        _c.task = _t;
        _c.tsk_curAreaID = _area.id;
        _c.tsk_dur = _data.dur;
        ContArea.I.assign_task_to_char (_area, _c, _t);
    }

    private void update_task_dur (ObjChar _c){
        if (_c.task != "idle") {
            _c.tsk_dur -= Time.deltaTime;

            if (_c.tsk_dur <= 0) {
                ContPlayers.Player _p = ContPlayers.I.get_player_from_id (_c.owner);
                assign_task (_c, "idle", _p.cBase);
            }
        }
    }
}