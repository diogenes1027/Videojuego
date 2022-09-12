using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinObject : MonoBehaviour
{
    Rigidbody rb;
    public bool flag;
    private bool winCond;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        flag = false;
        if (transform.name == "WinObject")
        {
            winCond = true;
        }
    }
    private void FixedUpdate()
    {
        if (flag)
        {
            rb.AddForce((transform.forward + Vector3.up) * 100, ForceMode.Impulse);
            flag = false;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        
        if (other.CompareTag("Score"))
        {
            Destroy(gameObject);
            if (winCond)
            {
                Time.timeScale = 0;
                Debug.Log("WIN");
            }
            
        }
        
    }

    
    

}
