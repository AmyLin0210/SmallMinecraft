using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class CloseToolBox : MonoBehaviour, IPointerClickHandler
{
    public Canvas subCanvas;
    public GameObject player;
    public Dropdown dropdown;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    public void OnPointerClick(PointerEventData e)
    {
        player.GetComponent<CubePickUp>().toolBoxStatusChange();
        subCanvas.enabled = false;
        dropdown.value = 0;
    }
}
