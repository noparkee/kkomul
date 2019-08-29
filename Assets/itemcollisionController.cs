using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class itemcollisionController : MonoBehaviour
{
    GameObject character;
    // Start is called before the first frame update
    void Start()
    {
        this.character = GameObject.Find("Character");
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter2D(Collider2D other)
    {

        CharacterController CC = GameObject.Find("Character").GetComponent<CharacterController>();
        if (CC.state == 0)
        {
            if (other.gameObject.tag.Equals("Player"))
            {
                Destroy(this.gameObject);
            }
        }

    }
}
