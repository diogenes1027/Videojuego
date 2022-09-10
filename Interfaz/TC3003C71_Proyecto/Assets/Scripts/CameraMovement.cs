using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    // Vector to store the mouse input
    Vector2 turn;

    // Sensitivity of the mouse
    [SerializeField] float sensitivity = 1;
    // Start is called before the first frame update
    void Start()
    {
        // Cursor is hidden
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        // Get the mouse input
        turn.x += Input.GetAxis("Mouse X") * sensitivity;
        turn.y += Input.GetAxis("Mouse Y") * sensitivity;
        // Rotate the camera using the input
        transform.localRotation = Quaternion.Euler(-turn.y, turn.x, 0);
    }
}
