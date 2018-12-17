using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class DropDownController : MonoBehaviour {
    public Dropdown dropdown;
    public Canvas subCanvas;
    public GameObject player;
    public Transform sun;

    const int GameMenu = 1;
    const int Exit = 3;
    const int ToolBox = 2;
    const int Night = 4;

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
        }
    }

    void ShowToolBox()
    {

    }

    void Start()
    {
        hideSubCanvas();
    }

    void hideSubCanvas()
    {
        subCanvas.enabled = false;
    }

    void showSubCanvas()
    {
        subCanvas.enabled = true;
    }
}
