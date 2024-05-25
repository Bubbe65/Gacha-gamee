using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

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
        bool isDead = enemyUnit.TakeDamage(playerUnit.damage);


        dialogueText.text = "The attack is succesful!";

     
        if (isDead)
        {
            state = BattleState.WON;
            enemyHUD.SetHp(enemyUnit.currentHp = 0);
            EndBattle();
        }
        else
        {
            state = BattleState.ENEMYTURN;
            enemyHUD.SetHp(enemyUnit.currentHp);
            dialogueText.text = "You deal " + playerUnit.damage + " damage...";
            yield return new WaitForSeconds(2F);

            StartCoroutine(EnemyTurn());
        }
    }

    IEnumerator EnemyTurn()
    {
        dialogueText.text = enemyUnit.FatName + " attacks!";
        yield return new WaitForSeconds(1F);

        bool isDead = playerUnit.TakeDamage(enemyUnit.damage);

        playerHUD.SetHp(playerUnit.currentHp);

        yield return new WaitForSeconds(1F);

        if (isDead)
        {
            state = BattleState.LOST;
            EndBattle();
        }
        else
        {
            state = BattleState.PLAYERTURN;
            PlayerTurn();
        }
    }

    void EndBattle()
    {
        if(state == BattleState.WON)
        {
            dialogueText.text = "Yoy won the battle!";
            SceneManager.LoadScene("SampleScene");
            
        }else if (state == BattleState.LOST)
        {
            dialogueText.text = "You were defeated.";
        }
    }

    void PlayerTurn()
    {
        dialogueText.text = "Choose an action:";

    }

    IEnumerator PlayerHeal()
    {
        playerUnit.Heal(5);
        
        state = BattleState.ENEMYTURN;

        playerHUD.SetHp(playerUnit.currentHp);
        dialogueText.text = "Yoe feel renewed strength!";

        yield return new WaitForSeconds(2F);

       
        StartCoroutine(EnemyTurn());
    }


    public void OnAttackButton()
    {
        if (state != BattleState.PLAYERTURN)
            return;

        StartCoroutine(PlayerAttack());
    }
   
    
    public void OnHealButton()
    {
        if (state != BattleState.PLAYERTURN)
            return;

        StartCoroutine(PlayerHeal());
    }

}
