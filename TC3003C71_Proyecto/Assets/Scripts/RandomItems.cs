using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class RandomItems : MonoBehaviour
{
    public Transform[] pos;

    public GameObject[] objectivesSummon;



    public GameObject goldenObject;
    public GameObject farmingObject;
    public GameObject speedObject;
    public GameObject damageObject;
    public GameObject shieldObject;



    Collider m_Collider;
    Vector3 m_Center;
    Vector3 m_Size, m_Min, m_Max;


    // Start is called before the first frame update
    void Start()
    {
        //Fetch the Collider from the GameObject
        m_Collider = GetComponent<Collider>();
        //Fetch the center of the Collider volume
        m_Center = m_Collider.bounds.center;
        //Fetch the size of the Collider volume
        m_Size = m_Collider.bounds.size;
        //Fetch the minimum and maximum bounds of the Collider volume
        m_Min = m_Collider.bounds.min;
        m_Max = m_Collider.bounds.max;
        //Output this data into the console
        OutputData();

        //SummonObjective();
    }

    void OutputData()
    {
        //Output to the console the center and size of the Collider volume
        Debug.Log("Collider Center : " + m_Center);
        Debug.Log("Collider Size : " + m_Size);
        Debug.Log("Collider bound Minimum : " + m_Min);
        Debug.Log("Collider bound Maximum : " + m_Max);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void SummonObjective()
    {
        List<Transform> tmppos = pos.ToList();
        for(int i = 0; i <3; i++)
        {
            int k = Random.Range(0,tmppos.Count-1);
            int n = Random.Range(0, objectivesSummon.Length);
            Instantiate(objectivesSummon[n], tmppos[k].position, objectivesSummon[n].transform.rotation);
            tmppos.Remove(tmppos[k]);
        }

    }


    private void SummonFarm()
    {
        int n = Random.Range(0, objectivesSummon.Length-1);


        Instantiate(objectivesSummon[n], pos[n].transform.position, objectivesSummon[n].transform.rotation);

    }
}