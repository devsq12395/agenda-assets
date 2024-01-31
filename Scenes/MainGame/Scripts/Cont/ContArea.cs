using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class ContArea : MonoBehaviour {

    public static ContArea I;
	public void Awake(){ I = this; }

    public Material road; // Set in Editor

    public List<ObjArea> areas;

    public void setup (){
        GameObject[] _areasGO = GameObject.FindGameObjectsWithTag ("area");
        foreach (GameObject _a in _areasGO) {
            ObjArea[] _areaComps = _a.GetComponents<ObjArea>();
            _areaComps [0].setup ();
            areas.Add (_areaComps [0]);
        }
    }

    // Actions
    public void select_area (ObjArea _a){
        UI_AreaChk.I.show (_a);
    }

    // GET Functions
    public ObjArea get_area (string _name){
        return areas.Find(area => area.name == _name);
    }

    public ObjArea get_area_from_id (int _id){
        return areas.Find(area => area.id == _id);
    }

    public List<ObjArea> get_areas_with_tag (string _tag){
        return areas.Where(area => area.tags.Contains (_tag)).ToList ();
    }

    public string get_relation (ObjArea _a, int _p) {
        Player _pO = ContPlayers.I.get_player_from_id (_p);

        
    }

    // Area to Player control
    public void add_relations (ContPlayers.Player _p){
        foreach (ObjArea _a in areas) {
            _a.relation.Add (_p.name, "neutral");
        }
    }

    // Area to Char control
    public void assign_task_to_char (ObjArea _area, ObjChar _c, string _t){
        DB_Tasks.TaskData _data = DB_Tasks.I.get_task_data (_t);

        _c.task = _t;
        _c.tsk_curAreaID = _area.id;
        _c.tsk_dur = _data.dur;
        
        _c.transform.position = _area.transform.position;
    }

    // Area to Area control
    public void connect (ObjArea _a1, ObjArea _a2){
        float _width = 0.1f;

        Vector2 _pos1 = _a1.go.transform.position,
                _pos2 = _a2.go.transform.position;

        _a1.connections.Add (_a2.id);
        _a2.connections.Add (_a1.id);

        // Roads
        LineRenderer _lineRend = _a1.go.AddComponent<LineRenderer>();
        _lineRend.material = road;
        _lineRend.startWidth = _width;
        _lineRend.endWidth = _width;
        Vector3[] _linePos = new Vector3[] {
            new Vector3 (_pos1.x, _pos1.y, -1),
            new Vector3 (_pos2.x, _pos2.y, -1)
        };
        _lineRend.positionCount = _linePos.Length;
        _lineRend.SetPositions(_linePos);
    }
}