using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class blockController : MonoBehaviour
{
    public GameObject blockPrefab;
    public GameObject linePrefab;
    public GameObject medicine;
    public GameObject bombUp;
    public GameObject speed;
  
    int itemnum;

    // Start is called before the first frame update
    void Start()
    {
        this.linePrefab = GameObject.Find("LinePrefab");
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter2D(Collider2D other)
    //rigidBody가 무언가와 충돌할때 호출되는 함수 입니다.
    //Collider2D other로 부딪힌 객체를 받아옵니다.
    {
        Vector2 p = this.blockPrefab.transform.position;

        if (other.gameObject.tag.Equals("line"))
        {
            Destroy(this.gameObject);
            int randomnum = Random.Range(0, 4); //0부터 3까지 랜덤.

            switch (randomnum)
            {
                case 0:
                    GameObject item1 = Instantiate(medicine) as GameObject;
                    itemnum = 1;
                    item1.transform.position = new Vector3(p.x, p.y, 0);
                    break;
                case 1:
                    GameObject item2 = Instantiate(bombUp) as GameObject;
                    itemnum = 2;
                    item2.transform.position = new Vector3(p.x, p.y, 0);
                    break;
                case 2:
                    GameObject item3 = Instantiate(speed) as GameObject;
                    itemnum = 3;
                    item3.transform.position = new Vector3(p.x, p.y, 0);
                    break;
                case 3:
                    Destroy(this.gameObject);
                    break;
            }
        }
    }
}
