using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CubePickUp : MonoBehaviour {

    public GameObject[] toolBox = new GameObject[5];

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {

        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            RaycastHit ray_cast_hit;

            if (Physics.Raycast(ray, out ray_cast_hit))
            {
                GameObject cube = ray_cast_hit.collider.gameObject;

                // which cube has been clicked
                if( cube.name.IndexOf( "cube_soil" ) != -1)
                {
                    PutInToBox( 0 );
                    Destroy(cube);
                }
                if (cube.name.IndexOf("cube_stone") != -1)
                {
                    PutInToBox( 1 );
                    Destroy(cube);
                }
                if (cube.name.IndexOf("cube_wood") != -1)
                {
                    PutInToBox( 2 );
                    Destroy(cube);
                }
            }
        }
    }


    // change the image in tool box
    void PutInToBox( int cube )
    {
        toolBox[cube].GetComponent<toolBox>().pickUp();
    }
}
