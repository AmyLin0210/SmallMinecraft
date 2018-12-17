using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMoving : MonoBehaviour {


    public Transform player;
    public Vector3 initialize;

    //moving camera with mouse
    public float speedH = 2.0f;
    public float speedV = 2.0f;

    private float yaw = 0.0f;
    private float pitch = 0.0f;
    bool canCameraRotate = false;


    // Use this for initialization
    void Start () {
        Cursor.lockState = CursorLockMode.Locked;
    }
	
	// Update is called once per frame
	void Update () {
        transform.position = player.position + initialize + player.forward;

        if ( canCameraRotate )
        {

            yaw = player.eulerAngles.y;
            pitch -= Input.GetAxis("Mouse Y");

            transform.eulerAngles = new Vector3(pitch, yaw, 0.0f);
        }

        if (Input.GetMouseButtonDown(0))
            canCameraRotate = true;
        if (Input.GetMouseButtonUp(0))
            canCameraRotate = false;

    }
}
