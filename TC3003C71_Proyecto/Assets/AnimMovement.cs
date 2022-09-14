using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimMovement : MonoBehaviour
{
    private Animator _animator;
    private Rigidbody rb;
    private AnimMovement animMovement;

    [SerializeField] private float movementSpeed;
    [SerializeField] private float rotationSpeed;

    [SerializeField] private bool isWandering = false;
    [SerializeField] private bool isRotationRight = false;
    [SerializeField] private bool isRotationLeft = false;
    [SerializeField] private bool isWalking = false;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
        animMovement = GetComponent<AnimMovement>();
        _animator.SetBool("Running", false);
    }
    

    // Update is called once per frame
    void Update()
    {
        if (!isWandering)
        {
            StartCoroutine(Wander());
        }
        if (isRotationRight)
        {
            transform.Rotate(rotationSpeed * Time.deltaTime * transform.up);
        }
        if (isRotationLeft)
        {
            transform.Rotate(-rotationSpeed * Time.deltaTime * transform.up);
        }
        if (isWalking)
        {
            rb.AddForce(transform.forward * movementSpeed,ForceMode.Acceleration);
        }

        
        


    }
    private IEnumerator Wander()
    {
        float rotationTime = Random.Range(.1f, .5f);
        float rotateWait = Random.Range(.5f, 1f);
        int rotateDirection = Random.Range(1, 2);
        float walkWait = Random.Range(.5f, 1);
        float walkTime = Random.Range(1, 3);

        isWandering = true;
        _animator.SetBool("Running", false);
        yield return new WaitForSeconds(walkWait);
        
        isWalking = true;
        _animator.SetBool("Running", true);
        yield return new WaitForSeconds(walkTime);

        isWalking = false;
        _animator.SetBool("Running", false);
        yield return new WaitForSeconds(rotateWait);

        if (rotateDirection == 1)
        {
            isRotationLeft = true;
            yield return new WaitForSeconds(rotationTime);
            isRotationLeft = false;
        }
        if (rotateDirection == 2)
        {
            isRotationRight = true;
            yield return new WaitForSeconds(rotationTime);
            isRotationRight = false;
        }

        isWandering = false;
    }

    public void DisableHitObject(bool kinematic, bool fail)
    {
        _animator.enabled = false;
        animMovement.enabled = false;
        rb.isKinematic = kinematic;
        if (fail)
        {
            StartCoroutine(EnableAnimAgain());
        }
    }
    public void EnableHitObject(bool kinematic)
    {
        _animator.enabled = true;
        animMovement.enabled = true;
        rb.isKinematic = kinematic;
    }
    public void Throw(Vector3 playerFront)
    {
        rb.AddForce((playerFront + Vector3.up) * 100, ForceMode.Impulse);
        StartCoroutine(EnableAnimAgain());
    }
    private IEnumerator EnableAnimAgain()
    {
        yield return new WaitForSeconds(5);
        EnableHitObject(false);
    }

}
