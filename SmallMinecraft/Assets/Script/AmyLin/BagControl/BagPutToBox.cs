using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class BagPutToBox : MonoBehaviour, IPointerClickHandler
{
    public GameObject Box;
    public Text CubeTotal;
    int CubeNumber, BagNumber;

    public void OnPointerClick(PointerEventData e)
    {
        int cubeNum;
        if( this.GetComponentInChildren<Text>().text == "put")
        {
            for (int i = 0; i < 5; ++i)
            {
                cubeNum = Box.GetComponentsInChildren<toolBox>()[i].GetCubeNumber();
                if ( cubeNum == -1 )
                {
                    Box.GetComponentsInChildren<toolBox>()[i].AddComponment(CubeNumber, BagNumber);
                    Box.GetComponentsInChildren<toolBox>()[i].setCubeTotal( CubeTotal.text );
                    break;
                }
            }
        }
        if (this.GetComponentInChildren<Text>().text == "cancel")
        {
            for (int i = 0; i < 5; ++i)
            {
                cubeNum = Box.GetComponentsInChildren<toolBox>()[i].GetCubeNumber();
                if ( CubeNumber == cubeNum)
                {
                    Box.GetComponentsInChildren<toolBox>()[i].clearBox();
                    break;
                }
            }
        }
    }

    public void setCubeNumber(int num)
    {
        CubeNumber = num;
    }
    public void setBagNumber(int num)
    {
        BagNumber = num;
    }
}
