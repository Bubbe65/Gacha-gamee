using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageTester: MonoBehaviour
{
    public AttributeManager playerAtm;
    public AttributeManager enemyAtm;
    // Update is called once per frame
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F11))
        {
            playerAtm.DealDamage(enemyAtm.gameObject);
        }

        if (Input.GetKeyDown(KeyCode.F12))
        {
            enemyAtm.DealDamage(playerAtm.gameObject);
        }
    }
}
