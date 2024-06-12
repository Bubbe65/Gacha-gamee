using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public enum BattleState { START, PLAYERTURN, ENEMYTURN, WON, LOST} // Detta �r olika tillst�nd p� striden, som ja Starten Lost, won.
public class BattleSystem : MonoBehaviour
{
    public GameObject playerPrefab;
    public GameObject enemyPrefab;

    public Transform playerBattleStation; // Position d�r spelaren placeras i striden
    public Transform enemyBattleStation; // Position d�r fienden placeras i striden

    public BattleHUD playerHUD;  // HUD f�r att visa spelarens status
    public BattleHUD enemyHUD; // HUD f�r att visa fiendens status

    public BattleState state; // Aktuellt tillst�nd i striden

    FatUnit playerUnit; 
    FatUnit enemyUnit;

    public Text dialogueText;  // Dialouge ruta som visar text under striden
    private void Start()
    {
        state = BattleState.START; // Starttillstndet p� striden
        StartCoroutine(SetupBattle()); // Funktion IEnumerator SetupBattle anv�nds, coroutine deklarerar IEnumerator, anv�nds f�r att anv�nda kod �ver l�ngre tid.
    }

    IEnumerator SetupBattle() 
    {
        GameObject playerGo = Instantiate(playerPrefab, playerBattleStation); // Anv�nder positionen av player
        playerUnit = playerGo.GetComponent<FatUnit>();
        
        GameObject enemyGo = Instantiate(enemyPrefab, enemyBattleStation); // Anv�ndre postioenen p� enemy
        enemyUnit = enemyGo.GetComponent<FatUnit>();

        dialogueText.text = "A wild " + enemyUnit.FatName + " approaches. . ."; // text i sialouge rutan

        playerHUD.SetHUD(playerUnit); // stats  f�r player
        enemyHUD.SetHUD(enemyUnit); // Stats f�r enemy

        yield return new WaitForSeconds(2F); // V�ntar �innan man k�ra g�ra n�got

        state = BattleState.PLAYERTURN; // sedan b�rjar din tur PlayerTurn tillst�nd i striden d�r det �r din tur att k�ra.
        PlayerTurn(); // Player turn funktion skriven nedan vilket bara �r text i dialogue rutan.
    }


    IEnumerator PlayerAttack() // Tills�nd f�r din attack under striden.
    {
        bool isDead = enemyUnit.TakeDamage(playerUnit.damage); // kollar om enemy �r d�d eller ej


        dialogueText.text = "The attack is succesful!"; // Text n�r man trycker p� attack knappen

     
        if (isDead) // bool = true, s� anv�nder den enum tillst�ndet Battle State Won, n�r du vinner, Om currentHp = 0 End battle().
        {
            state = BattleState.WON;
            enemyHUD.SetHp(enemyUnit.currentHp = 0);
            EndBattle();
        }
        else // Annars S� �r det enemies turn, Visar hur mycket damage enemyn g�r. Och sedan v�ntar 2 frames sedan startar StartCoroutine med funktioenn Enemy turn skriven nedan.,
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
        // Enemy attackerar 
        dialogueText.text = enemyUnit.FatName + " attacks!";
        yield return new WaitForSeconds(1F); // V�tar 1 frame innna man kan g�r n�got

        bool isDead = playerUnit.TakeDamage(enemyUnit.damage); // kollar om player �r d�dd eller ej

        playerHUD.SetHp(playerUnit.currentHp); 

        yield return new WaitForSeconds(1F);

        if (isDead) // Om isDead = true, anv�nder 
        {
            // Tillst�nd du f�rlorat 
            state = BattleState.LOST;
            EndBattle();
        }
        else
        {
            // Tillst�nd tillabaka till player turn
            state = BattleState.PLAYERTURN;
            PlayerTurn();
        }
    }

    void EndBattle()
    {
        // N�r slutet av striden �r uppn�dd
        if(state == BattleState.WON)
        {
            
            GameObject player = GameObject.FindGameObjectWithTag("player"); 
            dialogueText.text = "Yoy won the battle!"; // dialogue text n�r man vinner 
            SceneManager.LoadScene("Gacha"); // Loadar in scenen igen F�rsker fixa just nu
        }
        else if (state == BattleState.LOST) // Dilagoue r�text n�r man f�rlorar
        {
            dialogueText.text = "You were defeated.";
        }
    }

    void PlayerTurn() // Dialgoufe text n�r det �r din tur
    {
        dialogueText.text = "Choose an action:";

    }

    IEnumerator PlayerHeal() // n�r du ska heala
    { 
        playerUnit.Heal(5); // du healar f�r 5
        
        state = BattleState.ENEMYTURN; // Enemy turn

        playerHUD.SetHp(playerUnit.currentHp);
        dialogueText.text = "Yoe feel renewed strength!"; // dialgue n�r du healar

        yield return new WaitForSeconds(2F);

       
        StartCoroutine(EnemyTurn()); //sedan byter till enemy turn
    }


    public void OnAttackButton() // Kollar om det �r spelarens turn, knappen
    {
        if (state != BattleState.PLAYERTURN)
            return;

        StartCoroutine(PlayerAttack());
    }
   
    
    public void OnHealButton() // knppen f�r Heal. Kolar om det �r splarens tur.
    {
        if (state != BattleState.PLAYERTURN)
            return;

        StartCoroutine(PlayerHeal());
    }

}
