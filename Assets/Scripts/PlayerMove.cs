using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using LockingPolicy = Thalmic.Myo.LockingPolicy;
using Pose = Thalmic.Myo.Pose;
using UnlockType = Thalmic.Myo.UnlockType;
using VibrationType = Thalmic.Myo.VibrationType;

public class PlayerMove : MonoBehaviour {

    public GameObject myo = null;

    public GameObject spell_1;
    public GameObject spell_2;
    public GameObject spell_3;

    private double endTime;
    private GameObject mainCamera;

    // Use this for initialization
    void Start () {
        endTime = DateTime.Now.TimeOfDay.TotalSeconds;
        mainCamera = GameObject.FindGameObjectWithTag("MainCamera");
    }
	
	// Update is called once per frame
	void Update () {
        ThalmicMyo thalmicMyo = myo.GetComponent<ThalmicMyo>();

        if (Input.GetKeyDown("z") && endTime < DateTime.Now.TimeOfDay.TotalSeconds) {
            GameObject spell = Instantiate((GameObject)spell_1, mainCamera.transform.position + new Vector3(0, 0, 7), transform.rotation) as GameObject;
            spell.gameObject.GetComponent<BoulderSpell>().x_direction = transform.forward.x;
            spell.gameObject.GetComponent<BoulderSpell>().z_direction = transform.forward.z;
            endTime = DateTime.Now.TimeOfDay.TotalSeconds + 2;
            ExtendUnlockAndNotifyUserAction(thalmicMyo);
        }

        if (Input.GetKeyDown("x") && endTime < DateTime.Now.TimeOfDay.TotalSeconds) {
            GameObject spell = Instantiate((GameObject)spell_2, mainCamera.transform.position + new Vector3(0, 17, 0), transform.rotation) as GameObject;
            spell.gameObject.GetComponent<MeteorScript>().x_direction = 0;
            spell.gameObject.GetComponent<MeteorScript>().y_direction = -0.5f;
            spell.gameObject.GetComponent<MeteorScript>().z_direction = 1;
            endTime = DateTime.Now.TimeOfDay.TotalSeconds + 2;
        }

        if (Input.GetKeyDown("c") && endTime < DateTime.Now.TimeOfDay.TotalSeconds) {
            GameObject spell = Instantiate((GameObject)spell_3, new Vector3(0, 0, 0), transform.rotation) as GameObject;
            spell.gameObject.GetComponent<DigitalRuby.LightningBolt.LightningBoltScript>().StartPosition = mainCamera.transform.position + new Vector3(0, -0.5f, 2);
            spell.gameObject.GetComponent<DigitalRuby.LightningBolt.LightningBoltScript>().EndPosition = mainCamera.transform.position + new Vector3(0, 0, 60);
            endTime = DateTime.Now.TimeOfDay.TotalSeconds + 2;
        }
    }

    void ExtendUnlockAndNotifyUserAction(ThalmicMyo myo)
    {
        ThalmicHub hub = ThalmicHub.instance;

        if (hub.lockingPolicy == LockingPolicy.Standard)
        {
            myo.Unlock(UnlockType.Timed);
        }

        myo.NotifyUserAction();
    }
}
