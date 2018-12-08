using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class toolBox : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void pickUp()
    {
        Button number = gameObject.GetComponentInChildren<Button>();
        string num = number.GetComponentInChildren<Text>().text;

        number.GetComponentInChildren<Text>().text = (int.Parse(num) + 1).ToString();
    }

    public void takeOut()
    {
        Button number = gameObject.GetComponentInChildren<Button>();
        string num = number.GetComponentInChildren<Text>().text;

        number.GetComponentInChildren<Text>().text = (int.Parse(num) - 1).ToString();
    }

    public bool isEmpty()
    {
        Button number = gameObject.GetComponentInChildren<Button>();
        string num = number.GetComponentInChildren<Text>().text;
        if (num == "0")
            return true;
        else
            return false;
    }
}
