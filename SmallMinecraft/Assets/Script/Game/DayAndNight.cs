using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DayAndNight : MonoBehaviour {

    bool isMonsterAppear;
    float timer;
    public GameObject MonsterBlood;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        transform.Rotate(Vector3.right * Time.deltaTime);

        if(transform.eulerAngles.x < 180 && transform.eulerAngles.x > 0)
        {
            isMonsterAppear = false;
            monster.position = new Vector3(100, 300, 0);
        }

        if (transform.eulerAngles.x > 180 && transform.eulerAngles.x < 181 && !isMonsterAppear)
        {
            isMonsterAppear = true;
            monster.position = new Vector3(0, 4f, 0);
            /*
            for (int i = 0; i < 3; ++i)
            {
                Image t = Instantiate(MonsterHeart);
                t.transform.parent = MonsterBlood.transform;
                t.transform.position = new Vector3( -460 + 50*i, 350, 0);
            }
            */
        }

        if (transform.eulerAngles.x > 350)
        {
            isMonsterAppear = false;
            monster.position = new Vector3(0, 0, 30);
        }

    }

    public Transform monster;
}
    