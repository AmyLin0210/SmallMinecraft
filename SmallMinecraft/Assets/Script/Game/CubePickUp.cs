using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CubePickUp : MonoBehaviour {

    bool isToolBoxOpen = false;

    public GameObject cubeInformation;
    public GameObject toolBoxItem, pickUpItem;
    public GameObject[] toolBox = new GameObject[5];

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {

        if (Input.GetMouseButtonDown(0) && !isToolBoxOpen && !gameObject.GetComponent<CubePutDown>().GetIsHoldOnCube())
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            RaycastHit ray_cast_hit;

            if (Physics.Raycast(ray, out ray_cast_hit))
            {
                GameObject cube = ray_cast_hit.collider.gameObject;
                Vector3 cubeLocation = cube.transform.position;

                // which cube has been hit
                if( cube.name.IndexOf( "cube_soil" ) != -1)
                    hitCube(cube, "soil", cubeLocation);
                else if (cube.name.IndexOf("cube_stone") != -1)
                    hitCube(cube, "stone", cubeLocation);
                else if (cube.name.IndexOf("cube_wood") != -1)
                    hitCube(cube, "wood", cubeLocation);
                else if (cube.name.IndexOf("cube_grass") != -1)
                    hitCube(cube, "grass", cubeLocation);
                else if (cube.name.IndexOf("cube_leaves") != -1)
                    hitCube(cube, "leaves", cubeLocation);

                // which cube has been clicked
                if (cube.name.IndexOf("small_soil") != -1)
                    pickUpSmallCube(cube, "soil");
                else if (cube.name.IndexOf("small_stone") != -1)
                    pickUpSmallCube(cube, "stone");
                else if (cube.name.IndexOf("small_wood") != -1)
                    pickUpSmallCube(cube, "wood");
                else if (cube.name.IndexOf("small_grass") != -1)
                    pickUpSmallCube(cube, "grass");
                else if (cube.name.IndexOf("small_leaves") != -1)
                    pickUpSmallCube(cube, "leaves");
            }
        }
    }

    void hitCube( GameObject cube, string cubeName, Vector3 cubeLocation)
    {
        int cubeNumber = cubeInformation.GetComponent<CubeInformation>().GetCubeNumber(cubeName);
        pickUpItem.GetComponent<CreatePickUpItem>().isHit(cubeNumber, cubeLocation);
        Destroy(cube);
    }

    void pickUpSmallCube( GameObject cube, string cubeName)
    {
        int cubeNumber = cubeInformation.GetComponent<CubeInformation>().GetCubeNumber(cubeName);
        PutInToBox(cubeNumber);
        Destroy(cube);
    }

    public void toolBoxStatusChange()
    {
        isToolBoxOpen = !isToolBoxOpen;
    }

    // change the image in tool box
    void PutInToBox( int cube )
    {

        bool isEmpty = true;
        int bagNumber = -1;
        Button toolItem;

        // there is a same cube in the box
        for (int i = 0; i < 12 && isEmpty; ++i)
        {
            toolItem = toolBoxItem.GetComponentsInChildren<Button>()[i];
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
                bagNumber = i;
            }
        }


        isEmpty = true;

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
                toolBox[i].GetComponent<toolBox>().AddComponment(cube, bagNumber);
            }
        }
    }
}
