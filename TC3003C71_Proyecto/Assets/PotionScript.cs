using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PotionScript : MonoBehaviour
{
    [SerializeField] private float newValue;
    [SerializeField] private float valueLvl1;
    [SerializeField] private float valueLvl2;
    [SerializeField] private float valueLvl3;

    [SerializeField] private float effectTime;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            StarterAssets.ThirdPersonController tpc = other.GetComponent<StarterAssets.ThirdPersonController>();

            StartCoroutine(tpc.CallEffectTime(gameObject, 5, 75));
        }
    }
}
