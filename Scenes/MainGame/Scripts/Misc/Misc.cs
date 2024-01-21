using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Misc : MonoBehaviour {

    public static Misc I;
	public void Awake(){ I = this; }

    public int generate_id (){
        string _cL = "0123456789";
    
        int length = 8;
        System.Text.StringBuilder idBuilder = new System.Text.StringBuilder();

        System.Random random = new System.Random();

        for (int i = 0; i < length; i++) {
            int randomIndex = random.Next(0, _cL.Length);
            char randomChar = _cL[randomIndex];
            idBuilder.Append(randomChar);
        }

        return int.Parse(idBuilder.ToString());
    }
}
