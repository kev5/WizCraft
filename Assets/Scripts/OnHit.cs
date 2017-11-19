using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnHit : MonoBehaviour {

	void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.CompareTag("Meteor")) { Destroy(gameObject); }
    }
}
