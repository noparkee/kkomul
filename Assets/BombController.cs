using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombController : MonoBehaviour
{
    public GameObject Character;
    public GameObject BombPrefab;
    public GameObject LinePrefab;
    float span = 2.5f;
    float delta = 0;

    void Update()
    {
        this.delta += Time.deltaTime;
        if (this.delta > this.span)
        {
            /*for(int i = 0; i < Character.act2; i++)
            { act2 어카지..
            }*/
            MakeLine();
            this.delta = 0;
        }
    }

    void MakeLine()
    {   
        Vector2 p = this.BombPrefab.transform.position;
        Destroy(BombPrefab);
        GameObject LineCenter = Instantiate(LinePrefab) as GameObject;
        LineCenter.transform.position = new Vector3(p.x, p.y, 0);
        GameObject LineUp = Instantiate(LinePrefab) as GameObject;
        LineUp.transform.position = new Vector3(p.x, p.y + 1, 0);
        GameObject LineLeft = Instantiate(LinePrefab) as GameObject;
        LineLeft.transform.position = new Vector3(p.x - 1, p.y, 0);
        GameObject LineRight = Instantiate(LinePrefab) as GameObject;
        LineRight.transform.position = new Vector3(p.x + 1, p.y, 0);
        GameObject LineDown = Instantiate(LinePrefab) as GameObject;
        LineDown.transform.position = new Vector3(p.x, p.y - 1, 0);
    }

}
