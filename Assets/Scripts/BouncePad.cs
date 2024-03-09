using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BouncePad : MonoBehaviour
{

    MarioMovement mm;
    Animator anim;
    void Start()
    {
        mm = GameObject.FindGameObjectWithTag("Player").GetComponent<MarioMovement>();
        anim = GetComponent<Animator>();
    }


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.name == "Mario")
        {
            mm.jumpHeight = 20;
            anim.SetTrigger("Bounce");
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.transform.name == "Mario")
        {
            mm.jumpHeight = 2;
        }
    }
}