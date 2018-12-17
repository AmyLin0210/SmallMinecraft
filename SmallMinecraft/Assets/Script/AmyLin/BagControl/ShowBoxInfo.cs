using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class ShowBoxInfo : MonoBehaviour, IPointerClickHandler
{

    public Image  boxImage;
    public Text   boxNumber;
    public Button PutOrCancel;
    public GameObject Box;

    public void OnPointerClick(PointerEventData e)
    {
        if (this.GetComponent<BoxItem>().GetCubeNumber() != -1)
        {
            boxImage.sprite = this.GetComponent<Image>().sprite;
            boxNumber.text = this.GetComponent<BoxItem>().GetCubeTotal().ToString();
        }
        int cubeNum;
        bool inBox = false;
        for (int i = 0; i < 5; ++i)
        {
            cubeNum = Box.GetComponentsInChildren<toolBox>()[i].GetCubeNumber();
            if (int.Parse(boxNumber.text) == cubeNum)
            {
                inBox = true;
                break;
            }
        }

        if (inBox)
            PutOrCancel.GetComponentInChildren<Text>().text = "cancel";
        else
        {
            PutOrCancel.GetComponentInChildren<Text>().text = "put";
            PutOrCancel.GetComponent<BagPutToBox>().setCubeNumber( GetComponent<BoxItem>().GetCubeNumber() );
            PutOrCancel.GetComponent<BagPutToBox>().setBagNumber(GetComponent<BoxItem>().getBagNum());
        }


    }
}
