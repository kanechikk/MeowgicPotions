using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RatingSpawner : MonoBehaviour
{
    public GameObject[] prefabs = new GameObject[2];
    public GameObject Spawn(int type)
    {
        if (type == 0)
        return Instantiate(prefabs[0], transform);
        if (type == 1)
        return Instantiate(prefabs[1], transform);
        else
        return Instantiate(prefabs[2], transform);
    }


}
