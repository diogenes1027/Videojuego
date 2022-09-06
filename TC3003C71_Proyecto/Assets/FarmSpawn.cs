using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FarmSpawn : MonoBehaviour
{
    [SerializeField] private GameObject gold;
    private void OnTriggerEnter(Collider other)
    {

        if (other.CompareTag("Player"))
        {
            transform.position = transform.position * (transform.position.y * -2f);
            
            Instantiate(gold, transform.parent.position  - new Vector3(0,1,0), Quaternion.identity, transform.parent);
        }
    }
}
