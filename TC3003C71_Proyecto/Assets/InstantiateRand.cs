using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class InstantiateRand : MonoBehaviour
{
    public Transform[] pos;

    public GameObject[] objectivesSummon;



    // Start is called before the first frame update
    void Start()
    {


        SummonObjective();
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
