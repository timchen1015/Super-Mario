using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MarioMovement : MonoBehaviour
{
    [SerializeField] private float moveSpeed;
    [SerializeField] private float runSpeed;

    private Vector3 moveDirection;
    private Vector3 velocity;

    public bool isGrounded;
    [SerializeField] private float groundCheckDistance;
    [SerializeField] private LayerMask groundMask;
    [SerializeField] private float gravity;

    public float jumpHeight;

    private CharacterController controller;
    private Animator anim;

    [SerializeField] float BigTime;
    public float StartToBeBigTime;
    public bool change;

    [SerializeField] private GameObject pipeone;
    [SerializeField] private GameObject pipetwo;

    public Button button;

    GameObject pause;
    public bool isPaused = false;
    public bool isDead = false;


    AudioSource jump;
    private void Start()
    {
        jump = GetComponent<AudioSource>();
        Button btn = button.GetComponent<Button>();
        pause = GameObject.FindGameObjectWithTag("Stop");
        anim = GetComponent<Animator>();
        controller = GetComponent<CharacterController>();
        change = false;
        pause.SetActive(false);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && !isPaused)
        {
            pause.SetActive(true);
            Time.timeScale = 0f;
            isPaused = true;
        }
        else if (Input.GetKeyDown(KeyCode.Escape) && isPaused)
        {
            pause.SetActive(false);
            Time.timeScale = 1f;
            isPaused = false;
        }
        Move();
        TimesUp();
        /* if (Input.GetKeyDown(KeyCode.Escape) && !isPaused)
        {
            pause.SetActive(true);
            Time.timeScale = 0f;
            isPaused = true;
        }
       else if (Input.GetKeyDown(KeyCode.Escape) && isPaused)
        {
            pause.SetActive(false);
            Time.timeScale = 1f;
            isPaused = false;
        }
        */
    }

    private void Move()
    {
       
        isGrounded = Physics.CheckSphere(transform.position, groundCheckDistance, groundMask);

        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        float moveZ = Input.GetAxis("Vertical");
        float moveX = Input.GetAxis("Horizontal");

        moveDirection = new Vector3(moveX, 0, moveZ);
        moveDirection = transform.TransformDirection(moveDirection);
    
        if (moveDirection != Vector3.zero)
        {
            Run();
        }
        else if (moveDirection == Vector3.zero)
        {
            Idle();
        }

        moveDirection *= moveSpeed;
        controller.Move(moveDirection * Time.deltaTime);

        if (isGrounded)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                Jump();
            }
        }

        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
    }

    private void Idle()
    {
        anim.SetFloat("Speed", 0, 0.1f, Time.deltaTime);
    }

    private void Run()
    {
        moveSpeed = runSpeed;
        anim.SetFloat("Speed", 1f, 0.1f, Time.deltaTime);
    }

    private void Jump()
    {
        velocity.y = Mathf.Sqrt(jumpHeight * -2 * gravity);
        anim.SetTrigger("Jump");
        jump.Play();
    }

    private void TimesUp()
    {
        if (change)
        {
            if (Time.time - StartToBeBigTime >= BigTime)
            {
                Vector3 temp = new Vector3(1.5f, 1.5f, 1.5f);
                transform.localScale -= temp;
                change = false;
            }
        }
    }

    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.tag == "PipeOne")
        {
            if (!isGrounded)
            {
                if (Input.GetKeyDown(KeyCode.X))
                {
                    anim.SetTrigger("InPipe");
                    transform.position = new Vector3(pipetwo.transform.position.x, pipetwo.transform.position.y + 2, pipetwo.transform.position.z);
                    anim.SetTrigger("OutPipe");
                }
            }
        }
        else if (collision.gameObject.tag == "PipeTwo")
        {
            if (!isGrounded)
            {
                if (Input.GetKeyDown(KeyCode.X))
                {
                    anim.SetTrigger("InPipe");
                    transform.position = new Vector3(pipeone.transform.position.x, pipeone.transform.position.y + 2, pipeone.transform.position.z);
                    anim.SetTrigger("OutPipe");
                }
            }
        }
    }
}
