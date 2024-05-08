using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCSystem : MonoBehaviour
{

    bool player_detection = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(player_detection && Input.GetKeyDown(KeyCode.F) && !Testingmovement.dialogue)
        {
            print("Dialogue Started!");
            Testingmovement.dialogue = true;

        }
    }

    void NewDialogue(string text)
    {



    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.name == "Square")
        {
            player_detection = true;
        }


    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.name == "Square")
        {
            player_detection = false;
        }


    }
}
