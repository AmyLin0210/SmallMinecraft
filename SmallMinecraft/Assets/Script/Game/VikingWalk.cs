using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Text.RegularExpressions;

public class VikingWalk : MonoBehaviour {

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
        yaw += Input.GetAxis("Mouse X") * speedV;
        transform.eulerAngles += new Vector3(0.0f, yaw, 0.0f);

    }

    void OnCollisionEnter(Collision collision)
    {
        if (Regex.IsMatch(collision.gameObject.name, "cube*"))
            jump = false;
    }

    public void gethit()
    {
        Life--;
        Debug.Log(Life);
    }


    //moving angal
    public float speedV = 0.0000000001f;
    public float yaw = 0.0f;

    public int jumpforce = 10;

    private bool jump = false;
    private int Life = 10;

    public float moving_speed = 10f;
}
