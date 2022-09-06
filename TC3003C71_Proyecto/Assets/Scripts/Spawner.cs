using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < 100; i++)
        {

            float px = Random.Range(0.0f, 10.0f);
            float py = 50f;
            float pz = Random.Range(0.0f, 10.0f);
            Vector3 p = new Vector3(px, py, pz);


            float cR = Random.Range(0.0f, 1.0f);
            float cG = Random.Range(0.0f, 1.0f);
            float cB = Random.Range(0.0f, 1.0f);
            Color c = new Color(cR, cG, cB);
            createSphere(p, c);


        }

    }

    GameObject createSphere(Vector3 position, Color color)
    {

        GameObject mySphere = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        mySphere.transform.localPosition = position;
        //mySphere.transform.localPosition = gameObject.transform.position;

        Renderer rend = mySphere.GetComponent<Renderer>();
        rend.material = new Material(Shader.Find("Standard"));
        rend.material.SetColor("_Color", color);


        Rigidbody rb = mySphere.AddComponent<Rigidbody>();
        rb.mass = 2;

        PhysicMaterial mat = new PhysicMaterial();
        mat.bounciness = 1.0f;
        Collider collider = mySphere.GetComponent<Collider>();
        collider.material = mat;

        return mySphere;

    }

    // Update is called once per frame
    void Update()
    {

    }
}

