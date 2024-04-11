using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomEncounts : MonoBehaviour
{
    public GameObject objectToSpawn;
    public Vector2 spawn = new Vector2(-0.58f, -0.11f);
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        








    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("You encountered a slajm");

            Vector2 spawnposition = (Vector2)transform.position + new Vector2(spawn.x, spawn.y);

            Instantiate(objectToSpawn, spawnposition, Quaternion.identity);
        }
    }





}
