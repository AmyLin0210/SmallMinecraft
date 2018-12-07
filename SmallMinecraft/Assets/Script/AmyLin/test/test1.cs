using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test1 : MonoBehaviour {


    bool isKeyDown;
	// Use this for initialization
	void Start () {
        isKeyDown = false;
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.P) && !isKeyDown)
        {
            Transform c = Instantiate(soil);

            c.parent = transform;
            c.localPosition = new Vector3(1,3,3);

            //isKeyDown = true;
        }

	}

    public Transform soil;
}
