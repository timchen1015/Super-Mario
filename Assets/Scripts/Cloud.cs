using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cloud : MonoBehaviour
{
    Transform cloud;
    [SerializeField] float ColdTime;
    float GotoTime = 0;
    [SerializeField] bool change;
    [SerializeField] float upbound;
    [SerializeField] float downbound;
    // Start is called before the first frame update
    void Start()
    {
        cloud = transform.GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        move();
    }
    private void move()
    {
        if (Time.time - GotoTime >= ColdTime)
        {
            if (change)
            {
                down();
            }
            else up();
        }
    }
    private void up()
    {
        Vector3 temp = new Vector3(0, +0.05f, 0);
        cloud.position += temp;
        GotoTime = Time.time;
        if (cloud.position.y > upbound) change = true;
    }
    private void down()
    {
        Vector3 temp = new Vector3(0, -0.05f, 0);
        cloud.position += temp;
        if (cloud.position.y < downbound) change = false;
        GotoTime = Time.time;
    }
}