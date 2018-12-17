using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DayAndNight : MonoBehaviour {
    float timer;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        transform.Rotate(Vector3.right * Time.deltaTime);

        if(transform.eulerAngles.x < 180)
        {
            monster.position = new Vector3(100, 300, 0);

        }

        if (transform.eulerAngles.x > 180 && transform.eulerAngles.x < 182)
            monster.position = new Vector3(0,0,0);

            if (transform.eulerAngles.x > 350)
        {
            monster.position = new Vector3(0, 0, 30);
        }

    }

    public Transform monster;
}
    