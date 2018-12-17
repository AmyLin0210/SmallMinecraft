using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class tutorial : MonoBehaviour, IPointerClickHandler
{
    public Canvas subCanvas;

    public void OnPointerClick(PointerEventData e)
    {
        subCanvas.enabled = true;
    }
}
