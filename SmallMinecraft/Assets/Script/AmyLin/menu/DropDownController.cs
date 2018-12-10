using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class DropDownController : MonoBehaviour {
    public Dropdown dropdown;

    public void Dropdown_IndexChange( int index)
    {
        switch( index)
        {
            // go back to game menu
            case 1:
                SceneManager.LoadScene(0);
                break;

            // reset
            case 2:

            // exit the game
            case 3:
                Application.Quit();
                break;
        }
    }

    void start()
    {

    }
}
