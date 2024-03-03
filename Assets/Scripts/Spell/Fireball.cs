using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fireball : MonoBehaviour
{
    public Animator anim;
    public float moveSpeed = 4.0f;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame

    public void HitEvent(){
        anim.SetBool("HitFlag", false);
        Destroy(gameObject);
    }
    void OnTriggerEnter2D(Collider2D collision) {
        if(collision.gameObject.tag == "BorderSpell"){
            Destroy(gameObject);
        }
        if(collision.gameObject.tag == "Enemy"){
            anim.SetBool("HitFlag", true);
        }
    }
}
