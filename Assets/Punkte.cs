using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Punkte : MonoBehaviour {

    public Text punkte;
    public float pps;
    int punkt = 0;
    public float verz;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        if (Time.time > pps)
        {
            punkt++;
            punkte.text = punkt.ToString();
            pps = Time.time + verz;
        }
    }
}
