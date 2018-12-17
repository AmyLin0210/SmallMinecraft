using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class DropDownController : MonoBehaviour {
    public Dropdown dropdown;
    public Canvas subCanvas;
    public Canvas tutorial;
    public GameObject player;
    public Transform sun;

    const int GameMenu = 1;
    const int Exit = 3;
    const int ToolBox = 2;
    const int Night = 4;
    const int Tutorial = 5;

    public void Start()
    {
        hideSubCanvas();
    }

    public void Dropdown_IndexChange( int index)
    {
        switch( index)
        {
            // go back to game menu
            case GameMenu:
                SceneManager.LoadScene(0);
                break;

            // exit the game
            case Exit:
                Application.Quit();
                break;
            case ToolBox:
                showSubCanvas();
                player.GetComponent<CubePickUp>().toolBoxStatusChange();
                break;
            case Night:
                sun.eulerAngles = new Vector3 ( 180, 0, 0 );
                break;
            case Tutorial:
                tutorial.enabled = true;
                break;
        }
    }

    void ShowToolBox()
    {

    }


    void hideSubCanvas()
    {
        subCanvas.enabled = false;
        tutorial.enabled = false;
    }

    void showSubCanvas()
    {
        subCanvas.enabled = true;
    }
}
