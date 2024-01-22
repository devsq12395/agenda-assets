using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContChars : MonoBehaviour {

    public static ContChars I;
	public void Awake(){ I = this; }

    public void setup (){
        
    }

    // Create
    public void create_char (string _name, int _owner){
        ObjArea _spawnArea = ContArea.I.get_areas_with_tag ($"base{_owner}")[0];
        if (!_spawnArea){
            Debug.Log ("Base for this char does not exist. Aborting spawn...");
            return;
        }

        ObjChar _new = new ObjChar ();
    }

    // Action
    public void assign_task (ObjChar _c, string _t, ObjArea _area) {
        DB_Tasks.TaskData _data = DB_Tasks.I.get_task_data (_t);

        _c.task = _t;
        _c.tsk_curAreaID = _area.id;
        _c.tsk_turns = _data.turns;
        ContArea.I.assign_task_to_char (_area, _c, _t);
    }

    public void on_end_turn (ObjChar _c){
        on_end_turn_task (_c);
    }

    private void on_end_turn_task (ObjChar _c){
        if (_c.task != "idle") {
            _c.tsk_turns--;

            if (_c.tsk_turns <= 0) {
                DB_Tasks.I.on_task_done (_c);
            }
        }
    }

    
}