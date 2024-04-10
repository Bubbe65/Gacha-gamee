using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomEncounts : MonoBehaviour
{

    public LayerMask LongGrass;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        CheckForEncounters();








    }


    private void CheckForEncounters()
    {
        if (Physics2D.OverlapCircle(transform.position, 0.2f, LongGrass)!= null)
        {
            if(Random.Range(1, 101) <= 10)
            {
                Debug.Log("Encountered a nigguh");

            }


        }


    }

}
