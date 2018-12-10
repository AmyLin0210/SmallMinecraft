using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BoxItem : MonoBehaviour {

    public Sprite sprite_soil, sprite_leaves, sprite_wood, sprite_stone, sprite_grass;

    const int soil = 0;
    const int stone = 1;
    const int wood = 2;
    const int grass = 3;
    const int leaves = 4;

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
        switch (cubeNum)
        {
            case soil:
                this.GetComponent<Image>().sprite = sprite_soil;
                break;
            case stone:
                this.GetComponent<Image>().sprite = sprite_stone;
                break;
            case leaves:
                this.GetComponent<Image>().sprite = sprite_leaves;
                break;
            case wood:
                this.GetComponent<Image>().sprite = sprite_wood;
                break;
            case grass:
                this.GetComponent<Image>().sprite = sprite_grass;
                break;
        }
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
