using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeatCircle : MonoBehaviour
{
    public float timeToScroll;
    public RectTransform hitButtonPos;
    private Vector3 startPos;
    private float startTime;
    private float timer;

    void Start()
    {
        startPos = transform.position;
        startTime = (float)AudioSettings.dspTime;
    }


    void Update()
    {
        //transform.position += new Vector3(speed * bpm * (float)AudioSettings.dspTime, 0, 0);

        if (Vector3.Distance(transform.position, hitButtonPos.position) > 0.01f)
        {
            float step = timer / timeToScroll;
            transform.position = Vector3.Lerp(startPos, hitButtonPos.position, step);
        }
        else
        {
            Destroy(gameObject, 0.1f);
        }
        timer = (float)AudioSettings.dspTime - startTime;
    }

}
