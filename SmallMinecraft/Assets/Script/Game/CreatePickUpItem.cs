using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreatePickUpItem : MonoBehaviour {

    public GameObject CubeInformation;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void isHit( int cubeNumber, Vector3 cubeLocation )
    {
        GameObject temp = Instantiate(CubeInformation.GetComponent<CubeInformation>().GetSmallCube(cubeNumber));
        temp.transform.parent = transform;
        temp.transform.position = cubeLocation;
    }
}
