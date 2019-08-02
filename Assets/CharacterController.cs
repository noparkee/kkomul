using UnityEngine;

public class CharacterController : MonoBehaviour
{
    int state = 0;
        //캐릭터의 상태 0: 평소 / 1: 가둠 / 2: 사망
    int act1 = 1, act2 = 1, act3 = 2;
        // 1: 물방울설치, 2: 물줄기길이, 3: 이동속도
    float slow = 1; 
        //캐릭터의 상태에 따른 둔화율
    int score = 0;
    //float span = 1.0f, delta = 0;
    // 시간간격 체크

    public GameObject Character;
    public GameObject BombPrefab;

    void Start()
    {
        this.Character = GameObject.Find("Character");
        //랜덤 위치 소환 -> 함수 사용: 타일 구현후 작성
    }

    void Update()
    {
        //캐릭터 상태
        if (state == 0)
        {
            slow = 1f;
            if (Input.GetKeyDown(KeyCode.Space))
            {
                MakeBomb();
                //폭탄 생성
            }

        }
        if (state == 1)
        {
            slow = 0.1f;
            //3초 후 state=0
        }
        if (state == 2)
        {
            slow = 0f;
            //destroy, 3초 후 부활, start와 같은 함수
        }

        //캐릭터 이동: 이동속도 비례
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Translate(-0.1f*slow*act3, 0, 0);
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.Translate(0.1f*slow*act3, 0, 0);
        }
        if (Input.GetKey(KeyCode.UpArrow))
        {
            transform.Translate(0, 0.1f*slow*act3, 0);
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            transform.Translate(0, -0.1f*slow*act3, 0);
        }
    }

    void MakeBomb()
    {
        {
            Vector2 p1 = this.Character.transform.position;
            float checkX = transform.position.x - 0.5f;
            float checkY = transform.position.y - 0.5f;
            float X = Mathf.Round(checkX) + 0.5f;
            float Y = Mathf.Round(checkY) + 0.5f;
            GameObject Bomb = Instantiate(BombPrefab) as GameObject;
            Bomb.transform.position = new Vector3(X, Y, 0);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    //rigidBody가 무언가와 충돌할때 호출되는 함수 입니다.
    //Collider2D other로 부딪힌 객체를 받아옵니다.
    {
        if (other.gameObject.tag.Equals("bigkkomule"))
        //부딪힌 객체의 태그를 비교해서 적인지 판단합니다.
        {
            //적을 파괴합니다.
            Destroy(this.gameObject);
            //자신을 파괴합니다.
        }

        if (other.gameObject.tag.Equals("line")) {
            state = 1;

        }

        /*if (other.gameObject.tag.Equals("block")) {
            //더이상 이동 x
        }*/
    }
}