using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class blockGenerator : MonoBehaviour
{
    public GameObject blockPrefab;
    // Start is called before the first frame update
    void Start()
    {
        GameObject block1 = Instantiate(blockPrefab) as GameObject;
        block1.transform.position = new Vector3(10.5f, 5.5f, 0);

        GameObject block2 = Instantiate(blockPrefab) as GameObject;
        block2.transform.position = new Vector3(-10.5f, 5.5f, 0);

        GameObject block3 = Instantiate(blockPrefab) as GameObject;
        block3.transform.position = new Vector3(10.5f, -5.5f, 0);

        GameObject block4 = Instantiate(blockPrefab) as GameObject;
        block4.transform.position = new Vector3(-10.5f, -5.5f, 0);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
