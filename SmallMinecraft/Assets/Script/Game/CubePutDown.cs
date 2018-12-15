using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CubePutDown : MonoBehaviour {

    public AudioSource PutDownSound;
    public GameObject[] toolBox = new GameObject[5];
    public Transform viking_sword, cubeParent;
    public GameObject cubeInformation;
    public Vector3 cubeInitialPosition;
    GameObject tempCube = null;
    int CubeNumber = -1;
    int BoxNumber = -1;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (tempCube != null)
            tempCube.transform.localPosition = viking_sword.localPosition + cubeInitialPosition;

        if (Input.GetKeyDown(KeyCode.Alpha1) && toolBox[0].GetComponent<toolBox>().GetCubeNumber() != -1)
            HoldOnCube(0);
        else if (Input.GetKeyDown(KeyCode.Alpha2) && toolBox[1].GetComponent<toolBox>().GetCubeNumber() != -1)
            HoldOnCube(1);
        else if (Input.GetKeyDown(KeyCode.Alpha3) && toolBox[2].GetComponent<toolBox>().GetCubeNumber() != -1)
            HoldOnCube(2);
        else if (Input.GetKeyDown(KeyCode.Alpha4) && toolBox[3].GetComponent<toolBox>().GetCubeNumber() != -1)
            HoldOnCube(3);
        else if (Input.GetKeyDown(KeyCode.Alpha5) && toolBox[4].GetComponent<toolBox>().GetCubeNumber() != -1)
            HoldOnCube(4);

        if (Input.GetMouseButtonDown(1) && tempCube != null)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            RaycastHit ray_cast_hit;

            if (Physics.Raycast(ray, out ray_cast_hit))
                PutDownCube(new Vector3(ray_cast_hit.point.x, ray_cast_hit.point.y+0.5f, ray_cast_hit.point.z));
        }
    }

    public bool GetIsHoldOnCube()
    {
        if (CubeNumber == -1)
            return false;
        else
            return true;
    }

    void HoldOnCube( int inputNum )
    {
        Destroy(tempCube);
        viking_sword.localScale = new Vector3(0, 0, 0);
        CubeNumber = toolBox[inputNum].GetComponent<toolBox>().GetCubeNumber();
        BoxNumber = inputNum;
        tempCube = Instantiate(cubeInformation.GetComponent<CubeInformation>().GetCube(CubeNumber));
        tempCube.transform.parent = this.transform;
        tempCube.transform.localScale = new Vector3(0.2f, 0.2f, 0.2f);
        tempCube.transform.localPosition = viking_sword.localPosition + cubeInitialPosition;
    }

    void PutDownCube( Vector3 rayPosition)
    {
        Destroy(tempCube);
        Transform t = Instantiate(cubeInformation.GetComponent<CubeInformation>().GetCube(CubeNumber).transform);
        t.parent = cubeParent;
        t.position = rayPosition;
        CubeNumber = -1;
        toolBox[BoxNumber].GetComponent<toolBox>().takeOut();
        PutDownSound.Play();
    }
}
