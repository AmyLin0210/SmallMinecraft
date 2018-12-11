using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreatePickUpItem : MonoBehaviour {

    public GameObject Soil, Stone, Wood, Grass, Leaves;

    const int soil = 0;
    const int stone = 1;
    const int wood = 2;
    const int grass = 3;
    const int leaves = 4;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void isHit( int cubeNumber, Vector3 cubeLocation )
    {
        GameObject temp = null;
        switch( cubeNumber)
        {
            case leaves:
                temp = Instantiate(Leaves);
                break;
            case stone:
                temp = Instantiate(Stone);
                break;
            case soil:
                temp = Instantiate(Soil);
                break;
            case grass:
                temp = Instantiate(Grass);
                break;
            case wood:
                temp = Instantiate(Wood);
                break;
        }
        temp.transform.parent = transform;
        temp.transform.position = cubeLocation;
    }
}
