using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Text.RegularExpressions;

public class Monster : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        transform.position = transform.position + (player.position - transform.position) * Time.deltaTime * followSpeed;
        transform.LookAt(player);
        if (transform.position.y < 1)
            transform.position = new Vector3(transform.position.x, 3, transform.position.z);

    }
    void OnCollisionEnter(Collision collision)
    {
        if (Regex.IsMatch(collision.gameObject.name, player.name))
        {
            player.GetComponent<VikingWalk>().gethit();
        }
            
    }

    public Transform player;
    private float followSpeed = 0.2f;
}
