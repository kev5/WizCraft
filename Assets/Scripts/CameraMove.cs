using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour {

    private GameObject player;
    private Vector3 cameraOffset;

	// Use this for initialization
	void Start () {
        player = GameObject.FindGameObjectWithTag("Player");
        cameraOffset = new Vector3(0, 0.7f, -1.3f);
	}
	
	// Update is called once per frame
	void Update () {
        transform.position = player.transform.position + cameraOffset;
	}
}
