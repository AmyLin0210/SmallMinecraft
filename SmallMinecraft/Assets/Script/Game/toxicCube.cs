using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class toxicCube : MonoBehaviour
{
    public GameObject user;

    void OnTriggerEnter(Collider c)
    {
        if (c.transform.name == "User")
        {
            user.GetComponent<VikingWalk>().gethit();
            Destroy(this.gameObject);
        }
        
    }

    void OnTriggerExit(Collider c)
    {
        Debug.Log("fuck");
    }
}
