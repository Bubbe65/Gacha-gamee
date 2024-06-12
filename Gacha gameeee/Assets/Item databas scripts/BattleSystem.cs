using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public enum BattleState { START, PLAYERTURN, ENEMYTURN, WON, LOST} // Detta är olika tillstånd på striden, som ja Starten Lost, won.
public class BattleSystem : MonoBehaviour
{
    public GameObject playerPrefab;
    public GameObject enemyPrefab;

    public Transform playerBattleStation; // Position där spelaren placeras i striden
    public Transform enemyBattleStation; // Position där fienden placeras i striden

    public BattleHUD playerHUD;  // HUD för att visa spelarens status
    public BattleHUD enemyHUD; // HUD för att visa fiendens status

    public BattleState state; // Aktuellt tillstånd i striden

    FatUnit playerUnit; 
    FatUnit enemyUnit;

    public Text dialogueText;  // Dialouge ruta som visar text under striden
    private void Start()
    {
        state = BattleState.START; // Starttillstndet på striden
        StartCoroutine(SetupBattle()); // Funktion IEnumerator SetupBattle används, coroutine deklarerar IEnumerator, används för att använda kod över långre tid.
    }

    IEnumerator SetupBattle() 
    {
        GameObject playerGo = Instantiate(playerPrefab, playerBattleStation); // Använder positionen av player
        playerUnit = playerGo.GetComponent<FatUnit>();
        
        GameObject enemyGo = Instantiate(enemyPrefab, enemyBattleStation); // Användre postioenen på enemy
        enemyUnit = enemyGo.GetComponent<FatUnit>();

        dialogueText.text = "A wild " + enemyUnit.FatName + " approaches. . ."; // text i sialouge rutan

        playerHUD.SetHUD(playerUnit); // stats  för player
        enemyHUD.SetHUD(enemyUnit); // Stats för enemy

        yield return new WaitForSeconds(2F); // Väntar äinnan man köra göra något

        state = BattleState.PLAYERTURN; // sedan börjar din tur PlayerTurn tillstånd i striden där det är din tur att köra.
        PlayerTurn(); // Player turn funktion skriven nedan vilket bara är text i dialogue rutan.
    }


    IEnumerator PlayerAttack() // Tillsånd för din attack under striden.
    {
        bool isDead = enemyUnit.TakeDamage(playerUnit.damage); // kollar om enemy är död eller ej


        dialogueText.text = "The attack is succesful!"; // Text när man trycker på attack knappen

     
        if (isDead) // bool = true, så använder den enum tillståndet Battle State Won, när du vinner, Om currentHp = 0 End battle().
        {
            state = BattleState.WON;
            enemyHUD.SetHp(enemyUnit.currentHp = 0);
            EndBattle();
        }
        else // Annars Så är det enemies turn, Visar hur mycket damage enemyn gör. Och sedan väntar 2 frames sedan startar StartCoroutine med funktioenn Enemy turn skriven nedan.,
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
        yield return new WaitForSeconds(1F); // Vätar 1 frame innna man kan gör något

        bool isDead = playerUnit.TakeDamage(enemyUnit.damage); // kollar om player är dödd eller ej

        playerHUD.SetHp(playerUnit.currentHp); 

        yield return new WaitForSeconds(1F);

        if (isDead) // Om isDead = true, använder 
        {
            // Tillstånd du förlorat 
            state = BattleState.LOST;
            EndBattle();
        }
        else
        {
            // Tillstånd tillabaka till player turn
            state = BattleState.PLAYERTURN;
            PlayerTurn();
        }
    }

    void EndBattle()
    {
        // När slutet av striden är uppnådd
        if(state == BattleState.WON)
        {
            
            GameObject player = GameObject.FindGameObjectWithTag("player"); 
            dialogueText.text = "Yoy won the battle!"; // dialogue text när man vinner 
            SceneManager.LoadScene("Gacha"); // Loadar in scenen igen Försker fixa just nu
        }
        else if (state == BattleState.LOST) // Dilagoue r´text när man förlorar
        {
            dialogueText.text = "You were defeated.";
        }
    }

    void PlayerTurn() // Dialgoufe text när det är din tur
    {
        dialogueText.text = "Choose an action:";

    }

    IEnumerator PlayerHeal() // när du ska heala
    { 
        playerUnit.Heal(5); // du healar för 5
        
        state = BattleState.ENEMYTURN; // Enemy turn

        playerHUD.SetHp(playerUnit.currentHp);
        dialogueText.text = "Yoe feel renewed strength!"; // dialgue när du healar

        yield return new WaitForSeconds(2F);

       
        StartCoroutine(EnemyTurn()); //sedan byter till enemy turn
    }


    public void OnAttackButton() // Kollar om det är spelarens turn, knappen
    {
        if (state != BattleState.PLAYERTURN)
            return;

        StartCoroutine(PlayerAttack());
    }
   
    
    public void OnHealButton() // knppen för Heal. Kolar om det är splarens tur.
    {
        if (state != BattleState.PLAYERTURN)
            return;

        StartCoroutine(PlayerHeal());
    }

}
