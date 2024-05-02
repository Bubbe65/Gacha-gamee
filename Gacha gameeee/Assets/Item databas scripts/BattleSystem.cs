using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum BattleState { START, PLAYERTURN, ENEMYTURN, WON, LOST}
public class BattleSystem : MonoBehaviour
{
    public GameObject playerPrefab;
    public GameObject enemyPrefab;

    public Transform playerBattleStation;
    public Transform enemyBattleStation;

    public BattleHUD playerHUD;
    public BattleHUD enemyHUD;

    public BattleState state;

    FatUnit playerUnit;
    FatUnit enemyUnit;

    public Text dialogueText;
    private void Start()
    {
        state = BattleState.START;
        StartCoroutine(SetupBattle());
    }

    IEnumerator SetupBattle()
    {
        GameObject playerGo = Instantiate(playerPrefab, playerBattleStation);
        playerUnit = playerGo.GetComponent<FatUnit>();
        
        GameObject enemyGo = Instantiate(enemyPrefab, enemyBattleStation);
        enemyUnit = enemyGo.GetComponent<FatUnit>();

        dialogueText.text = "A wild " + enemyUnit.FatName + " approaches. . .";

        playerHUD.SetHUD(playerUnit);
        enemyHUD.SetHUD(enemyUnit);

        yield return new WaitForSeconds(2F);

        state = BattleState.PLAYERTURN;
        PlayerTurn();
    }


    IEnumerator PlayerAttack()
    {

        yield return new WaitForSeconds(2F);
    }

    void PlayerTurn()
    {
        dialogueText.text = "Choose an action:";

    }

    public void OnAttackButton()
    {
        if (state != BattleState.PLAYERTURN)
            return;

        StartCoroutine(PlayerAttack());
    }

}
