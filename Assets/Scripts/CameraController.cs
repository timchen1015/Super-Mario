using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private float mouseSensitivity;

    [SerializeField] Transform mario;

    public MarioMovement mm;

    private void Start()
    {
        mm = GetComponentInParent<MarioMovement>();
    }

    private void Update()
    {
        Rotate();
    }

    private void Rotate()
    {
        if (mm.isPaused || mm.isDead)
        {
            Cursor.lockState = CursorLockMode.None;
        }
        else
        {
            float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity;
            float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity;

            mario.Rotate(Vector3.up, mouseX);
            transform.Rotate(Vector3.left, mouseY);
            Cursor.lockState = CursorLockMode.Locked;
        }
    }
}
