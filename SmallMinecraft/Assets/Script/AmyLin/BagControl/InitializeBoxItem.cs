using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InitializeBoxItem : MonoBehaviour {

    public GameObject BoxItem;
	// Use this for initialization
	void Awake () {
        BoxItem.GetComponent<BoxItem>().AddComponment(5);
        BoxItem.GetComponent<BoxItem>().setCubeTotal(10);
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
