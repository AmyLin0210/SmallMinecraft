using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BoxItem : MonoBehaviour {

    public GameObject cubeInformation;

    int CubeNumber = -1;
    int CubeTotal = 0;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void AddComponment(int cubeNum)
    {
        CubeNumber = cubeNum;
        CubeTotal = 1;
        // set picture
        this.GetComponent<Image>().sprite = cubeInformation.GetComponent<CubeInformation>().GetCubeSprite(CubeNumber);

    }
    public int GetCubeNumber()
    {
        return CubeNumber;
    }

    public int GetCubeTotal()
    {
        return CubeTotal;
    }

    public void pickUp()
    {
        ++CubeTotal;
    }

    // the cube number reduce
    public void takeOut()
    {
        --CubeTotal;

        if ( CubeTotal == 0)
            clearBox();
    }

    // make the toolBox empty
    public void clearBox()
    {
        this.GetComponent<Image>().sprite = null;
        CubeTotal = 0;
        CubeNumber = -1;
    }
}
