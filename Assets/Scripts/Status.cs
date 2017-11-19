using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Status : MonoBehaviour {

    private GameObject mainCamera;

    void Start()
    {
        mainCamera = GameObject.FindGameObjectWithTag("MainCamera");
    }

    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.CompareTag("Boulder") || col.gameObject.CompareTag("Lightning")) {
            Destroy(gameObject);
            mainCamera.gameObject.GetComponent<Score>().score++;
        }
    }
}
