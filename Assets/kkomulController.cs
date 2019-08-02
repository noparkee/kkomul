using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class kkomulController : MonoBehaviour
{
    int state = 0;
    int direction;

    float span = 3.0f;
    float delta = 0;

    //GameObject block;

    // Start is called before the first frame update
    void Start()
    {
        //this.block = GameObject.Find("block");
        direction = Random.Range(0, 4);
    }

    // Update is called once per frame
    void Update()
    {
        this.delta += Time.deltaTime;
        if (this.delta > this.span)
        {
            this.delta = 0;
            direction = Random.Range(0, 4);
        }

        Debug.Log(direction);

        switch (direction)
        {
            case 0:     //오른쪽
                transform.Translate(0.03f, 0, 0);
                break;
            case 1:     //왼쪽
                transform.Translate(-0.03f, 0, 0);
                break;
            case 2:     //아래쪽
                transform.Translate(0, -0.03f, 0);
                break;
            case 3:     //위쪽
                transform.Translate(0, 0.03f, 0);
                break;
            default:
                break;
        }

        //블록과 충돌하면 direction 의 random 값을 다시 설정

        Vector3 pos = Camera.main.WorldToViewportPoint(transform.position);
        if (pos.x < 0.1f)
        {
            pos.x = 0.1f;
            direction = Random.Range(0, 4);
        }
        if (pos.x > 0.9f)
        {
            pos.x = 0.9f;
            direction = Random.Range(0, 4);
        }
        if (pos.y < 0.1f)
        {
            pos.y = 0.1f;
            direction = Random.Range(0, 4);
        }
        if (pos.y > 0.9f)
        {
            pos.y = 0.9f;
            direction = Random.Range(0, 4);
        }
        transform.position = Camera.main.ViewportToWorldPoint(pos);
    }

    void OnTriggerEnter2D(Collider2D other)
    //rigidBody가 무언가와 충돌할때 호출되는 함수 입니다.
    //Collider2D other로 부딪힌 객체를 받아옵니다.
    {
        if (other.gameObject.tag.Equals("line"))
         {
            state = 1;      
         }
    }
}
