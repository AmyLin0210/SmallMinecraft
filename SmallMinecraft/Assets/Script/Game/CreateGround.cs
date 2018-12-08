using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateGround : MonoBehaviour {

    // Use this for initialization
    void Start()
    {
        ground();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void ground()
    {
        UnityEngine.Random.Range(0, 1);
        MAX_Z = 30;
        MAX_X = 30;
        for (int z = 0; z < 2; ++z)
        {
            for (float i = -MAX_X; i <= MAX_X; ++i)
            {
                for (float j = -MAX_Z; j <= MAX_Z; ++j)
                {
                    Transform temp = Dirt;
                    int num = UnityEngine.Random.Range(0, 2);
                    switch (num)
                    {
                        case 0:
                            temp = Dirt;
                            break;
                        case 1:
                            temp = Stone;
                            break;
                    }
                    Transform t = Instantiate(temp);
                    t.parent = transform;
                    t.localPosition = new Vector3(i, z, j);
                }
            }
        }
        for (int z = 2; z < 3; ++z)
        {
            for (float i = -MAX_X; i <= MAX_X; ++i)
            {
                for (float j = -MAX_Z; j <= MAX_Z; ++j)
                {
                    Transform temp = Grass;
                    if ((i <= -5 && j <= -5) || (i >= 5 && j >= 5))
                        temp = Dirt;
                    Transform t = Instantiate(temp);
                    t.parent = transform;
                    t.localPosition = new Vector3(i, z, j);

                    if (i % 8 == 0 && j % 8 == 0 && temp == Grass)
                    {
                        if (UnityEngine.Random.Range(0, 5) == 1)
                        {
                            trees(new Vector3(i, z + 1, j));
                        }
                        else if (UnityEngine.Random.Range(0, 5) == 1)
                        {
                            trees(new Vector3(-i, z + 1, -j));
                        }
                    }
                }
            }
        }
        for (int z = 3, z2 = 0; z < 7; ++z, ++z2)
        {
            for (float i = 5 + z + z2 - 3; i <= MAX_X; ++i)
            {
                for (float j = 5 + z + z2 - 3; j <= MAX_Z; ++j)
                {
                    Transform temp = Dirt;
                    int num = UnityEngine.Random.Range(0, 2);
                    switch (num)
                    {
                        case 0:
                            temp = Dirt;
                            break;
                        case 1:
                            temp = Stone;
                            break;
                    }
                    if (i == 5 + z + z2 - 3 || j == 5 + z + z2 - 3 || i == 5 + z + z2 - 2 || j == 5 + z + z2 - 2)
                        temp = Grass;
                    Transform t = Instantiate(temp);
                    t.parent = transform;
                    t.localPosition = new Vector3(i, z, j);

                    t = Instantiate(temp);
                    t.parent = transform;
                    t.localPosition = new Vector3(-i, z, -j);

                    if (i % 8 == 0 && j % 8 == 0 && temp == Grass)
                    {
                        if (UnityEngine.Random.Range(0, 5) == 1)
                        {
                            trees(new Vector3(i, z + 1 , j));
                        }
                        else if (UnityEngine.Random.Range(0, 5) == 1)
                        {
                            trees(new Vector3(-i, z + 1 , -j));
                        }
                    }

                    //top of the hill
                    if (z == 6 && temp != Grass)
                    {
                        t = Instantiate(Grass);
                        t.parent = transform;
                        t.localPosition = new Vector3(i, z + 1, j);

                        t = Instantiate(Grass);
                        t.parent = transform;
                        t.localPosition = new Vector3(-i, z + 1, -j);

                        if ( i % 8 == 0 && j % 8 == 0)
                        {
                            if(UnityEngine.Random.Range(0, 5) == 1)
                            {
                                trees(new Vector3(i, z + 1 + 1, j));
                            }
                            else if(UnityEngine.Random.Range(0, 5) == 1)
                            {
                                trees(new Vector3(-i, z + 1 + 1, -j));
                            }
                        }
                    }
                }
            }
        }
    }

    void trees(Vector3 position)
    {
        int leaves = UnityEngine.Random.Range(2, 5);

        for(int i = 0; i < 3; ++i)
        {
            Transform t = Instantiate(Wood);
            t.parent = transform;
            t.localPosition = position + new Vector3(0, i, 0);
        }

        for(int i = 3, j = leaves; i < 3 + leaves; ++i, --j)
        {
            for (int x = -j; x <= j; ++x)
            {
                for (int z = -j; z <= j; ++z)
                {                        
                    Transform t = Instantiate(Leave);
                    if (x == 0 && z == 0)
                        t = Instantiate(Wood);
                    t.parent = transform;
                    t.localPosition = position + new Vector3(x, i, z);
                }
            }

        }

    }
    public Transform Dirt;
    public Transform Grass;
    public Transform Leave;
    public Transform Stone;
    public Transform Wood;
    public static int MAX_X, MAX_Z;
}
