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
    private GameObject player;

    // Use this for initialization
    void Start () {
        endTime = DateTime.Now.TimeOfDay.TotalSeconds;
        mainCamera = GameObject.FindGameObjectWithTag("MainCamera");
        player = GameObject.FindGameObjectWithTag("Player");
    }
	
	// Update is called once per frame
	void Update () {
        ThalmicMyo thalmicMyo = myo.GetComponent<ThalmicMyo>();

        if ((Input.GetKeyDown("z") || thalmicMyo.pose == Pose.Fist) && endTime < DateTime.Now.TimeOfDay.TotalSeconds) {
            GameObject spell = Instantiate((GameObject)spell_1, mainCamera.transform.position + new Vector3(7 * (float) Math.Sin(player.gameObject.transform.rotation.eulerAngles.y * Math.PI / 180), 0, 7 * (float)Math.Cos(player.gameObject.transform.rotation.eulerAngles.y * Math.PI / 180)), transform.rotation) as GameObject;
            spell.gameObject.GetComponent<BoulderSpell>().x_direction = (float) Math.Sin(player.gameObject.transform.rotation.eulerAngles.y * Math.PI / 180);
            spell.gameObject.GetComponent<BoulderSpell>().z_direction = (float) Math.Cos(player.gameObject.transform.rotation.eulerAngles.y * Math.PI / 180);
            endTime = DateTime.Now.TimeOfDay.TotalSeconds + 0.5f;
            ExtendUnlockAndNotifyUserAction(thalmicMyo);
        }

        if (Input.GetKeyDown("x") && endTime < DateTime.Now.TimeOfDay.TotalSeconds) {
            GameObject spell = Instantiate((GameObject)spell_2, mainCamera.transform.position + new Vector3(0, 17, 0), transform.rotation) as GameObject;
            spell.gameObject.GetComponent<MeteorScript>().x_direction = 0;
            spell.gameObject.GetComponent<MeteorScript>().y_direction = -0.5f;
            spell.gameObject.GetComponent<MeteorScript>().z_direction = 1;
            endTime = DateTime.Now.TimeOfDay.TotalSeconds + 2;
        }

        if ((Input.GetKey("c") || thalmicMyo.pose == Pose.FingersSpread) && endTime < DateTime.Now.TimeOfDay.TotalSeconds) {
            GameObject spell = Instantiate((GameObject)spell_3, mainCamera.transform.position + new Vector3(5 * (float)Math.Sin(player.gameObject.transform.rotation.eulerAngles.y * Math.PI / 180), 0, 5 * (float)Math.Cos(player.gameObject.transform.rotation.eulerAngles.y * Math.PI / 180)), transform.rotation) as GameObject;
            spell.gameObject.GetComponent<DigitalRuby.LightningBolt.LightningBoltScript>().StartPosition = mainCamera.transform.position + new Vector3(2 * (float)Math.Sin(player.gameObject.transform.rotation.eulerAngles.y * Math.PI / 180), 0, 2 * (float)Math.Cos(player.gameObject.transform.rotation.eulerAngles.y * Math.PI / 180));
            spell.gameObject.GetComponent<DigitalRuby.LightningBolt.LightningBoltScript>().EndPosition = mainCamera.transform.position + new Vector3(60 * (float)Math.Sin(player.gameObject.transform.rotation.eulerAngles.y * Math.PI / 180), 0, 60 * (float)Math.Cos(player.gameObject.transform.rotation.eulerAngles.y * Math.PI / 180));
            spell.gameObject.GetComponent<BoxCollider>().size = new Vector3(58 * (float)Math.Sin(player.gameObject.transform.rotation.eulerAngles.y * Math.PI / 180), 3f, 58 * (float)Math.Cos(player.gameObject.transform.rotation.eulerAngles.y * Math.PI / 180));
            endTime = DateTime.Now.TimeOfDay.TotalSeconds + 0.1f;
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
