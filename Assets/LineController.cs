using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineController : MonoBehaviour
{
    public GameObject LinePrefab;
    float span = 0.5f;
    float delta = 0;
    void Update()
    {
        this.delta += Time.deltaTime;
        if (this.delta > this.span)
        {
            Destroy(LinePrefab);
            this.delta = 0;
        }
    }
}
