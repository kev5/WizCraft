using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MeteorScript : MonoBehaviour {

    public float x_direction;
    public float y_direction;
    public float z_direction;

    public GameObject player;

    // Use this for initialization
    void Start () {
		player = GameObject.FindGameObjectWithTag("Player");
    }
	
	// Update is called once per frame
	void Update () {
        transform.position += new Vector3(x_direction, y_direction, z_direction) * Time.deltaTime * 25;

        if(transform.position.x + 6 >= player.transform.position.x && transform.position.x - 6 <= player.transform.position.x &&
            transform.position.y + 6 >= player.transform.position.y && transform.position.y - 6 <= player.transform.position.y &&
            transform.position.z + 6 >= player.transform.position.z && transform.position.z - 6 <= player.transform.position.z) { 
            Destroy(player);
            SceneManager.LoadScene("LoseScreen");
        }

        if (transform.position.y + 6 <= 0)  {
            Destroy(gameObject);
        }
    }
}
