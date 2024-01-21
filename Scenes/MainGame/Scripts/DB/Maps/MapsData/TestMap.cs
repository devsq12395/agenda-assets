using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestMap : MonoBehaviour {

    public static TestMap I;
	public void Awake(){ I = this; }

    public GameObject goMap;

    public DB_Maps.mapDetails get_map_details (DB_Maps.mapDetails _new){
        _new.size = new Vector2 (50, 50);

        _new.pointList.Add ("dummyPoint", new Vector2 (0, 0));

        _new.mapObj = GameObject.Instantiate (goMap, new Vector3(0, 0, 0), Quaternion.Euler(new Vector3(0, 0, 0))) as GameObject;

        ContMap.I.create_map_objs = create_map_objs;

        return _new;
    }

    public void create_map_objs (){
        ObjArea area1 = ContArea.I.get_area ("sampArea1"),
                area2 = ContArea.I.get_area ("sampArea2");

        ContArea.I.connect (area1, area2);
    }

}