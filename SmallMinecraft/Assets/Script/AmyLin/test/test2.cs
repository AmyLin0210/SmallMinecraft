using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class test2 : MonoBehaviour, IPointerClickHandler
{
    public Transform player;

    public void OnPointerClick(PointerEventData e)
    {
        player.position = new Vector3(1, 1, 1);
    }
}
