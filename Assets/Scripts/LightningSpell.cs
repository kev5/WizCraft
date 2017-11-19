using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightningSpell : MonoBehaviour {

    private double endTime;

    // Use this for initialization
    void Start()
    {
        endTime = DateTime.Now.TimeOfDay.TotalSeconds + 1;
    }

    // Update is called once per frame
    void Update()
    {
        if (endTime < DateTime.Now.TimeOfDay.TotalSeconds)
        {
            Destroy(gameObject);
        }
    }
}
