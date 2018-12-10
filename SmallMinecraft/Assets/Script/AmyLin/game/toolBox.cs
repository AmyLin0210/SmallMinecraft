using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class toolBox : MonoBehaviour {

    public Sprite sprite_soil, sprite_leaves, sprite_wood, sprite_stone, sprite_grass;

    const int soil = 0;
    const int stone = 1;
    const int wood = 2;
    const int grass = 3;
    const int leaves = 4;

    int CubeNumber = -1;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    // when we put the first cube in the box
    public void AddComponment( int cubeNum)
    {
        Button image = gameObject.GetComponentsInChildren<Button>()[0];
        Image boxImage = image.GetComponentInChildren<Image>();

        CubeNumber = cubeNum;

        // set picture
        switch (cubeNum)
        {
            case soil:
                boxImage.sprite = sprite_soil;
                break;
            case stone:
                boxImage.sprite = sprite_stone;
                break;
            case leaves:
                boxImage.sprite = sprite_leaves;
                break;
            case wood:
                boxImage.sprite = sprite_wood;
                break;
            case grass:
                boxImage.sprite = sprite_grass;
                break;
        }

        // initialize cube number
        Button buttonCubeNumber = gameObject.GetComponentsInChildren<Button>()[1];
        buttonCubeNumber.GetComponentInChildren<Text>().text = "1";

    }

    public int GetCubeNumber()
    {
        return CubeNumber;
    }

    // the cube number enhance
    public void pickUp()
    {
        Button number = gameObject.GetComponentsInChildren<Button>()[1];
        string num = number.GetComponentInChildren<Text>().text;

        number.GetComponentInChildren<Text>().text = (int.Parse(num) + 1).ToString();
    }

    // the cube number reduce
    public void takeOut()
    {
        Button number = gameObject.GetComponentsInChildren<Button>()[1];
        string num = number.GetComponentInChildren<Text>().text;

        number.GetComponentInChildren<Text>().text = (int.Parse(num) - 1).ToString();

        if ((int.Parse(num) - 1) == 0)
            clearBox();
    }

    // make the toolBox empty
    public void clearBox()
    {
        Button number = gameObject.GetComponentsInChildren<Button>()[1];
        number.GetComponentInChildren<Text>().text = "";

        Button image = gameObject.GetComponentsInChildren<Button>()[0];
        Image boxImage = image.GetComponentInChildren<Image>();
        boxImage = null;

        CubeNumber = -1;
    }

    // judge is the cube Empty
    public bool isEmpty()
    {
        if (CubeNumber == -1)
            return true;
        else
            return false;
    }
}
