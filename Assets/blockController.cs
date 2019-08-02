using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class blockController : MonoBehaviour
{
   // public GameObject block;
    public GameObject line;

    // Start is called before the first frame update
    void Start()
    {
        //this.block = GameObject.Find("block");
        this.line = GameObject.Find("LinePrefab");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
