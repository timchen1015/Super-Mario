using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBricks : MonoBehaviour
{
    [SerializeField] float ColdTime;
    float GotoTime = 0;
    public bool change;
    Transform movebricks;
    [SerializeField] float upbound;
    [SerializeField] float downbound;

    // Start is called before the first frame update
    void Start()
    {
        movebricks = transform.GetComponent<Transform>();

        //change = false;
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
                left();
            }
            else if (!change) right();
        }
    }
    private void left()
    {
        Vector3 temp = new Vector3(0, -0.05f, 0);
        movebricks.position += temp;
        GotoTime = Time.time;
        if (movebricks.position.y < downbound)
        {
            change = false;
        }
    }
    private void right()
    {
        Vector3 temp = new Vector3(0, 0.05f, 0);
        movebricks.position += temp;
        if (movebricks.position.y > upbound)
        {
            change = true;
        }
        GotoTime = Time.time;
    }
}