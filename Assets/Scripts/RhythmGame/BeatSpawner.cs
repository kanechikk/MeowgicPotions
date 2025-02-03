using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeatSpawner : MonoBehaviour
{
    public RectTransform hitButtonPos;
    public float timeToScroll;
    [SerializeField] GameObject m_prefab;

    public GameObject Spawn()
    {
        GameObject beat = Instantiate(m_prefab, transform);
        BeatCircle script = beat.GetComponent<BeatCircle>();
        script.timeToScroll = timeToScroll;
        script.hitButtonPos = hitButtonPos;
        return beat;
        //unsure if this is the best way to give parameters upon spawn but its the only solution I can think of rn
    }
    
}
