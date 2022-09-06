using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gold : MonoBehaviour
{

    
    private void OnTriggerEnter(Collider other)
    {

        if (other.CompareTag("Player"))
        {
            StarterAssets.StarterAssetsInputs input = other.GetComponent<StarterAssets.StarterAssetsInputs>();
            if (input.Farm)
            {
                input.Farm = false;
                gameObject.transform.parent = other.transform;
            }

        }
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            StarterAssets.StarterAssetsInputs input = other.GetComponent<StarterAssets.StarterAssetsInputs>();
            if (!input.Farm)
            {
                if (input.attack)
                {
                    Debug.Log("soltar");
                }
            }
        }
    }
}
