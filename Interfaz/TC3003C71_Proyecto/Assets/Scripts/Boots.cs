using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(SphereCollider))]
public class Boots : MonoBehaviour
{

    //Rigidbody rb;
    //SphereCollider bx;
    bool cont;
    [SerializeField]private int buffSpeed;
    [SerializeField]private int buffSpeedTime;
    

    private void Start()
    {
        //rb = transform.GetComponent<Rigidbody>();
        //bx = transform.GetComponent<SphereCollider>();
    }

    private void OnTriggerEnter(Collider other)
    {

        if (other.CompareTag("Player") && !cont)
        {
            /*CharacterController ch = other.GetComponent<CharacterController>();
            rb.AddForce( other.GetComponent<CharacterController>().velocity.normalized * 2f, ForceMode.Impulse);*/


            StarterAssets.ThirdPersonController vals = other.GetComponent<StarterAssets.ThirdPersonController>();
            StarterAssets.StarterAssetsInputs pVals = other.GetComponent<StarterAssets.StarterAssetsInputs>();
            if (!pVals.Item)
            {
                StartCoroutine(BuffSpeed(vals));
            }
        }
    }

    private IEnumerator BuffSpeed(StarterAssets.ThirdPersonController vals_)
    {
        vals_.Speed_ = buffSpeed;
        vals_.ItemB(true);
        Debug.Log("Speed S");
        yield return new WaitForSeconds(buffSpeedTime);
        vals_.Speed_ = 1f;
        vals_.ItemB(false);
        Debug.Log("Speed E");
    }
}
