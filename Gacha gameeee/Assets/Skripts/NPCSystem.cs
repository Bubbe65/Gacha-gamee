using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using TMPro;

public class NPCSystem : MonoBehaviour
{

    bool player_detection = false;
    public GameObject d_template;
    public GameObject canva;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Detta startar dialogen med vilkoret att spelaren befinner sig inom räckvidd till NPC:n
        //Samtidigt att tangenten F trycks
        //När villkoren uppfylls så startar dialogen med en textruta som dyker fram
        if(player_detection && Input.GetKeyDown(KeyCode.F) && !Testingmovement.dialogue)
        {
            canva.SetActive(true);
            print("Dialogue Started!");
            Testingmovement.dialogue = true;
            NewDialogue("Hi");
            NewDialogue("I am Schlimey");
            canva.transform.GetChild(1).gameObject.SetActive(true);

        }
    }

    //Detta skapar metoden NewDialogue() och innehåller så att textrutan kan dyka upp
    void NewDialogue(string text)
    {
        GameObject template_clone = Instantiate(d_template, d_template.transform);
        template_clone.transform.parent = canva.transform;
        template_clone.transform.GetChild(1).GetComponent<TextMeshProUGUI>().text = text;


    }

    //Detta ser till att om spelaren är nära NPC:n så blir boolen player_detection true
    //Denna kod är viktig eftersom det är en av villkoren till IF-satsen
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.name == "character_0")
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
