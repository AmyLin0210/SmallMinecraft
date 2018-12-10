using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class DropDownController : MonoBehaviour {
    public Dropdown dropdown;
    public Canvas subCanvas;

    const int GameMenu = 0;
    const int Reset = 1;
    const int Exit = 2;
    const int ToolBox = 3;

    public void Dropdown_IndexChange( int index)
    {
        switch( index)
        {
            // go back to game menu
            case GameMenu:
                SceneManager.LoadScene(0);
                break;

            // reset
            case Reset:

            // exit the game
            case Exit:
                Application.Quit();
                break;
            case ToolBox:
                showSubCanvas();
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
