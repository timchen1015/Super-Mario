using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mushroom : MonoBehaviour
{
    private AudioSource getMushroomSound;
    public Animator anim;
    public Transform tf;
    MarioMovement mm;

    void Start()
    {
        anim = GameObject.FindGameObjectWithTag("Player").GetComponent<Animator>();
        tf = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        mm = GameObject.FindGameObjectWithTag("Player").GetComponent<MarioMovement>();
        getMushroomSound = GetComponentInParent<AudioSource>();
    }

    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.name == "Mario")
        {
            anim.SetTrigger("Big");
            mm.StartToBeBigTime = Time.time;
            mm.change = true;
            Vector3 temp = new Vector3(1.5f, 1.5f, 1.5f);
            tf.localScale += temp;
            getMushroomSound.Play();
            Destroy(transform.gameObject);
        }
    }

}
