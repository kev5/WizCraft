using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour {

    private GameObject player;
    private Vector3 cameraOffset;

	// Use this for initialization
	void Start () {
        player = GameObject.FindGameObjectWithTag("Player");
        transform.position = player.transform.position + new Vector3(0, 0.7f, -1.3f);
        transform.parent = player.transform;
    }
	
	// Update is called once per frame
	void Update () {
        
    }
}
