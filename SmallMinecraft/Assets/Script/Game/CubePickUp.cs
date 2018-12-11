using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CubePickUp : MonoBehaviour {

    const int soil   = 0;
    const int stone  = 1;
    const int wood   = 2;
    const int grass  = 3;
    const int leaves = 4;

    bool isToolBoxOpen = false;

    public GameObject toolBoxItem, pickUpItem;
    public GameObject[] toolBox = new GameObject[5];

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {

        if (Input.GetMouseButtonDown(0) && !isToolBoxOpen)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            RaycastHit ray_cast_hit;

            if (Physics.Raycast(ray, out ray_cast_hit))
            {
                GameObject cube = ray_cast_hit.collider.gameObject;
                Vector3 cubeLocation = cube.transform.position;

                // which cube has been clicked
                if( cube.name.IndexOf( "cube_soil" ) != -1)
                {
                    pickUpItem.GetComponent<CreatePickUpItem>().isHit(soil, cubeLocation);
                    Destroy(cube);
                }
                else if (cube.name.IndexOf("cube_stone") != -1)
                {
                    pickUpItem.GetComponent<CreatePickUpItem>().isHit(stone, cubeLocation);
                    Destroy(cube);
                }
                else if (cube.name.IndexOf("cube_wood") != -1)
                {
                    pickUpItem.GetComponent<CreatePickUpItem>().isHit(wood, cubeLocation);
                    Destroy(cube);
                }
                else if (cube.name.IndexOf("cube_grass") != -1)
                {
                    pickUpItem.GetComponent<CreatePickUpItem>().isHit(grass, cubeLocation);
                    Destroy(cube);
                }
                else if (cube.name.IndexOf("cube_leaves") != -1)
                {
                    pickUpItem.GetComponent<CreatePickUpItem>().isHit(leaves, cubeLocation);
                    Destroy(cube);
                }

                // which cube has been clicked
                if (cube.name.IndexOf("small_soil") != -1)
                {
                    PutInToBox(soil);
                    Destroy(cube);
                }
                if (cube.name.IndexOf("small_stone") != -1)
                {
                    PutInToBox(stone);
                    Destroy(cube);
                }
                if (cube.name.IndexOf("small_wood") != -1)
                {
                    PutInToBox(wood);
                    Destroy(cube);
                }
                if (cube.name.IndexOf("small_grass") != -1)
                {
                    PutInToBox(grass);
                    Destroy(cube);
                }
                if (cube.name.IndexOf("small_leaves") != -1)
                {
                    PutInToBox(leaves);
                    Destroy(cube);
                }
            }
        }
    }

    public void toolBoxStatusChange()
    {
        isToolBoxOpen = !isToolBoxOpen;
    }

    // change the image in tool box
    void PutInToBox( int cube )
    {
        bool isEmpty = true;

        // there is a same cube in the box
        for( int i = 0; i < 5 && isEmpty; ++i)
        {
            if( toolBox[i].GetComponent<toolBox>().GetCubeNumber() == cube)
            {
                isEmpty = false;
                toolBox[i].GetComponent<toolBox>().pickUp();
            }
        }

        // there is no same cube in the cube
        // but there is a empty toolbox
        for( int i = 0; i < 5 && isEmpty; ++i)
        {
            if( toolBox[i].GetComponent<toolBox>().GetCubeNumber() == -1)
            {
                isEmpty = false;
                toolBox[i].GetComponent<toolBox>().AddComponment(cube);
            }
        }

        isEmpty = true;
        Button toolItem;

        // there is a same cube in the box
        for (int i = 0; i < 12 && isEmpty; ++i)
        {
            toolItem = toolBoxItem.GetComponentsInChildren < Button >()[i];
            if (toolItem.GetComponent<BoxItem>().GetCubeNumber() == cube)
            {
                isEmpty = false;
                toolItem.GetComponent<BoxItem>().pickUp();
            }
        }
        // there is no same cube in the cube
        // but there is a empty toolbox
        for (int i = 0; i < 12 && isEmpty; ++i)
        {
            toolItem = toolBoxItem.GetComponentsInChildren<Button>()[i];
            if (toolItem.GetComponent<BoxItem>().GetCubeNumber() == -1)
            {
                isEmpty = false;
                toolItem.GetComponent<BoxItem>().AddComponment(cube);
            }
        }
    }
}
