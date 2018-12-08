using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CubePickUp : MonoBehaviour {

    public GameObject[] toolBox = new GameObject[5];
    public Image [] box    = new Image[5];
    public Button[] boxNum = new Button[5];
    public Sprite test;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {

        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            RaycastHit ray_cast_hit;

            if (Physics.Raycast(ray, out ray_cast_hit))
            {
                GameObject cube = ray_cast_hit.collider.gameObject;

                // which cube has been clicked
                if( cube.name.IndexOf( "cube_soil" ) != -1)
                {
                    PutInToBox("cube_soil");
                    Destroy(cube);
                }
                    
            }
        }
    }


    // change the image in tool box
    void PutInToBox( string cube )
    {
        cube = "haha";
        box[0].sprite = test;
        boxNum[0].GetComponentInChildren<Text>().text = "1";
        //toolBox[0].GetComponent<toolBox>().test();
    }
}
