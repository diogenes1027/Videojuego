using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoldenObj : MonoBehaviour
{
    public GameObject chicken;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Collision");
            Destroy(gameObject);
            Instantiate(chicken, new Vector3(other.transform.position.x, other.transform.position.y + 2, other.transform.position.z), other.transform.rotation, other.transform);
        }
    }

}
