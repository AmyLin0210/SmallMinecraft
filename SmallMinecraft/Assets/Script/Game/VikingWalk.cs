using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VikingWalk : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKey(KeyCode.W))
            transform.localPosition += moving_speed * Time.deltaTime * Vector3.forward;
        if (Input.GetKey(KeyCode.S))
            transform.localPosition += moving_speed * Time.deltaTime * Vector3.back;
        if (Input.GetKey(KeyCode.A))
            transform.localPosition += moving_speed * Time.deltaTime * Vector3.left;
        if (Input.GetKey(KeyCode.D))
            transform.localPosition += moving_speed * Time.deltaTime * Vector3.right;
    }

    public Vector3 right, left;
    public Vector3 forward, back;
    public float moving_speed = 10f;
}
