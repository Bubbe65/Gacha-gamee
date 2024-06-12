using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NextDialogue : MonoBehaviour
{
    int index = 2;
    private void Update()
    {
        //Denna rad av kod g�r att n�r man klickar p� musen s� g�r man �ver till n�sta dialogruta
        if(Input.GetMouseButtonDown(0) && transform.childCount > 1)
        {
            if(Testingmovement.dialogue)
            {
                transform.GetChild(index).gameObject.SetActive(true);
                index += 1;
                if(transform.childCount == index)
                {
                    index = 2;
                    Testingmovement.dialogue = false;

                }

            }
            else
            {
                gameObject.SetActive(false);
            }



        }
    }
}
