﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Text.RegularExpressions;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class VikingWalk : MonoBehaviour {

    bool canUserRotate = false;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        if (Input.GetKey(KeyCode.W))
            transform.localPosition += moving_speed * Time.deltaTime * transform.forward;
        if (Input.GetKey(KeyCode.S))
            transform.localPosition += moving_speed * Time.deltaTime * -transform.forward;
        if (Input.GetKey(KeyCode.A))
            transform.localPosition += moving_speed * Time.deltaTime * -transform.right;
        if (Input.GetKey(KeyCode.D))
            transform.localPosition += moving_speed * Time.deltaTime * transform.right;
        if (Input.GetKey(KeyCode.Space) && !jump)
        {
            GetComponent<Rigidbody>().AddForce(new Vector3(0, 20, 0) * jumpforce);
            jump = true;
        }
        if (Input.GetKey(KeyCode.L))
            Cursor.lockState = CursorLockMode.Locked;
        if (Input.GetMouseButtonDown(0))
        {
            canUserRotate = true;
            yaw = Input.GetAxis("Mouse X") * speedV;
        }
        if (Input.GetMouseButtonUp(0))
            canUserRotate = false;

        if (canUserRotate)
        {
            yaw += Input.GetAxis("Mouse X") * speedV;
            transform.eulerAngles += new Vector3(0.0f, yaw, 0.0f);
        }

        if ( !canBeHitted )
        {
            if (Time.time - hittedTime > 1)
                canBeHitted = true;
        }

    }

    void OnCollisionEnter(Collision collision)
    {
        if (Regex.IsMatch(collision.gameObject.name, "cube*"))
            jump = false;
    }

    public void gethit()
    {
        if (canBeHitted) { 
            Life--;
            canBeHitted = false;
            hittedTime = Time.time;
            if (Life > 0)
            {
                Image bloodImage = blood.GetComponentsInChildren<Image>()[Life];
                Destroy(bloodImage);
            }   
        }
        if(Life < 0)
            SceneManager.LoadScene(2);
    }


    //moving angal
    public float speedV = 0.0000000001f;
    public float yaw = 0.0f;

    public int jumpforce = 10;

    private bool jump = false;
    private int Life = 7;
    private float hittedTime = 5;
    private bool canBeHitted = true;

    public float moving_speed = 10f;
    public GameObject blood;
}
