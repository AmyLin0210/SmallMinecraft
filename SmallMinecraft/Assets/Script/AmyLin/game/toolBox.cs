using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class toolBox : MonoBehaviour {

    public GameObject cubeInformation;
    public GameObject bag;

    int BagNumber = -1;
    int CubeNumber = -1;

    // when we put the first cube in the box
    public void AddComponment( int cubeNum, int bagNum )
    {
        Button image = gameObject.GetComponentsInChildren<Button>()[0];
        Image boxImage = image.GetComponentInChildren<Image>();

        CubeNumber = cubeNum;
        BagNumber = bagNum;

        boxImage.sprite = cubeInformation.GetComponent<CubeInformation>().GetCubeSprite(cubeNum);

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
        bag.GetComponentsInChildren<BoxItem>()[BagNumber].takeOut();

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
        boxImage.sprite = null;

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

    public void setCubeTotal(string num)
    {
        Button buttonCubeNumber = gameObject.GetComponentsInChildren<Button>()[1];
        buttonCubeNumber.GetComponentInChildren<Text>().text = num;
    }
}
