using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomEnemies : MonoBehaviour {

    public GameObject enemy;

    private double endTime;

    void Start() {
        endTime = DateTime.Now.TimeOfDay.TotalSeconds + 5;
    }

	// Update is called once per frame
	void Update () {
        if(endTime < DateTime.Now.TimeOfDay.TotalSeconds) {
            System.Random rnd = new System.Random();
            Instantiate((GameObject) enemy, new Vector3(rnd.Next(-80, 80), 0, rnd.Next(-80, 80)), transform.rotation);
            endTime = DateTime.Now.TimeOfDay.TotalSeconds + 5;
        }
            
    }
}
