using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinObject : MonoBehaviour
{
    Rigidbody rb;
    public bool flag = false;
    AnimMovement animMovement;
    private bool winCond;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        flag = false;
        animMovement = GetComponent<AnimMovement>();
        if (transform.name == "WinObject")
        {
            winCond = true;
        }
    }
    private void FixedUpdate()
    {
        if (flag)
        {
            animMovement.DisableHitObject(false);
            animMovement.Throw();
            flag = false;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        
        if (other.CompareTag("Score"))
        {
            Destroy(gameObject);
            Debug.Log("SCORE");
            if (winCond)
            {
                Time.timeScale = 0;
                Debug.Log("WIN");
            }
            
        }
        
    }

    
    

}
