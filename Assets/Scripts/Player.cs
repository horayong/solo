using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public bool isTouchTop, isTouchBottom, isTouchRight, isTouchLeft;
    Animator anim;
    GameManager GM;

    void Awake()
    {
        GM = GameManager.instance;
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        //플레이어 이동
        float h = 0f;
        float v = 0f;

        if (Input.GetKey(KeyCode.A))
            h = -1f;
        else if (Input.GetKey(KeyCode.D))
            h = 1f;

        if (Input.GetKey(KeyCode.W))
            v = 1f;
        else if (Input.GetKey(KeyCode.S))
            v = -1f;

        if ((isTouchRight && h == 1) || (isTouchLeft && h == -1))
            h = 0;

        if ((isTouchTop && v == 1) || (isTouchBottom && v == -1))
            v = 0;

        Vector3 curPos = transform.position;
        Vector3 nextPos = new Vector3(h, v, 0) * GM.playerData.moveSpeed * Time.deltaTime;

        transform.position = curPos + nextPos;

        //플레이어 애니메이션
        if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.D) || Input.GetKeyUp(KeyCode.A) || Input.GetKeyUp(KeyCode.D) ||
            Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.S) || Input.GetKeyUp(KeyCode.W) || Input.GetKeyUp(KeyCode.S))
        {
            anim.SetInteger("Input", (int)h);
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Border")
        {
            switch (collision.gameObject.name)
            {
                case "Top":
                    isTouchTop = true;
                    break;
                case "Bottom":
                    isTouchBottom = true;
                    break;
                case "Right":
                    isTouchRight = true;
                    break;
                case "Left":
                    isTouchLeft = true;
                    break;
            }
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Border")
        {
            switch (collision.gameObject.name)
            {
                case "Top":
                    isTouchTop = false;
                    break;
                case "Bottom":
                    isTouchBottom = false;
                    break;
                case "Right":
                    isTouchRight = false;
                    break;
                case "Left":
                    isTouchLeft = false;
                    break;
            }
        }
    }
}
