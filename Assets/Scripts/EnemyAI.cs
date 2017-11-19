using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour {

    public GameObject meteor;

    private GameObject player;
    private double endTime;

    // Use this for initialization
    void Start () {
        player = GameObject.FindGameObjectWithTag("Player");
        endTime = DateTime.Now.TimeOfDay.TotalSeconds;
    }
	
	// Update is called once per frame
	void Update () {
        transform.LookAt(player.transform);

        if (Vector3.Distance(transform.position, player.transform.position) >= 10)
        {
            transform.position += new Vector3(transform.forward.x, 0, transform.forward.z) * 5 * Time.deltaTime;
        }

        if (Vector3.Distance(transform.position, player.transform.position) <= 100 && endTime < DateTime.Now.TimeOfDay.TotalSeconds)
        {
            GameObject spell = Instantiate((GameObject) meteor, transform.position + new Vector3(0, 17, 0), transform.rotation) as GameObject;
            float z_mag = Math.Abs(player.transform.position.z - transform.position.z);
            spell.gameObject.GetComponent<MeteorScript>().x_direction = (player.transform.position.x - transform.position.x) / z_mag;
            spell.gameObject.GetComponent<MeteorScript>().y_direction = -20f / z_mag;
            spell.gameObject.GetComponent<MeteorScript>().z_direction = (player.transform.position.z - transform.position.z) / z_mag;
            endTime = DateTime.Now.TimeOfDay.TotalSeconds + 2;
        }
    }
}
