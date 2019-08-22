using UnityEngine;

public class CharacterController : MonoBehaviour
{
    int state = 0;
        //캐릭터의 상태 0: 평소 / 1: 가둠 / 2: 사망
    public int act1 = 5, act2 = 1, act3 = 2;
    // 1: 물방울설치, 2: 물줄기길이, 3: 이동속도
    public int count = 0;
    float slow = 1; 
        //캐릭터의 상태에 따른 둔화율
    int score = 0;
    int setBomb = 1;

    float span = 3.0f, delta = 0;
    // 시간간격 체크

    float wtime = 0;    //물풍선 안에 있는 시간

    public GameObject Character;
    public GameObject BombPrefab;

    kkomulController kkomulstate;
    void Start()
    {
        this.Character = GameObject.Find("Character");
        kkomulstate = FindObjectOfType<kkomulController>();
        //랜덤 위치 소환 -> 함수 사용: 타일 구현후 작성
    }

    void Update()
    {
        //캐릭터 상태
        if (state == 0)
        {
            slow = 1f;
            setBomb = 1;
        }
        if (state == 1)
        {
            slow = 0.1f;
            setBomb = 0;

            this.wtime += Time.deltaTime;
            if (this.wtime > this.span)
            {
                state = 2;
                this.delta = 0;
            }
            //3초 후 state=2  //아이템을 쓰지 않는이상
        }
        if (state == 2)
        {
            Destroy(this.gameObject);
            setBomb = 0;

            //destroy, 3초 후 부활, start와 같은 함수
            /*this.delta += Time.deltaTime;
            if (this.delta > this.span)
            {
                
               this.delta = 0;
            }*/
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
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (setBomb == 1) {
            MakeBomb();
        }
            //폭탄 생성
        }
    }

    void MakeBomb()
    {
        {
            if (count < act1)
            {
                count++;
                Vector2 p1 = this.Character.transform.position;
                float checkX = transform.position.x - 0.5f;
                float checkY = transform.position.y - 0.5f;
                float X = Mathf.Round(checkX) + 0.5f;
                float Y = Mathf.Round(checkY) + 0.5f;
                if (true) //물풍선끼리 안겹칠떄
                {
                    GameObject bomb = Instantiate(BombPrefab) as GameObject;
                    bomb.transform.position = new Vector3(X, Y, 0);
                }
            }
        }
    }

    void OnTriggerEnter2D(Collider2D other) { 

        if (other.gameObject.tag.Equals("line")) {
            state = 1;
        }
    }

    int stop()//벽과 충돌판정
    {
        return 0;
    }
    void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.tag.Equals("Bomb"))
        {
            setBomb = 0;
        }
    }
    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag.Equals("Bomb"))
        {
            setBomb = 1;
        }
    }
}