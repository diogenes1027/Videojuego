using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimMovement : MonoBehaviour
{
    private Animator _animator;
    private CharacterController characterController;

    void Start()
    {
        _animator = GetComponent<Animator>();
        characterController = GetComponent<CharacterController>();
        _animator.SetBool("Running", true);
    }

    // Update is called once per frame
    void Update()
    {
        //characterController.Move(Vector3.forward * .01f);
        


    }
}
