using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Movment : MonoBehaviour
{
    // Start is called before the first frame update
    Rigidbody2D rigidbody2d;
    public float speed;
    private Animator animator;
    public LayerMask grassLayer;
    
    void Start()
    {
        // Anv�nder animator vid starten av spelet.
        animator = GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {
        // Vanlig script f�r r�relse 

        float horizontalinput = Input.GetAxis("Horizontal"); // Input f�r horizontal input
        float verticalinput = Input.GetAxis("Vertical"); // Input f�r Vertical input

        Vector3 direction = new(horizontalinput, verticalinput, 0);
        transform.Translate(direction * speed * Time.deltaTime);

        animator.SetFloat("Horizontal", horizontalinput); // aktiverar animator n�r man anv�nder input spefikt f�r Horizontal 
        animator.SetFloat("Vertical", verticalinput); // aktiverar animator n�r man anv�nder input spefikt f�r Horizontal 



    }
    private void OnCollisionEnter2D(Collision2D collision) // Kollar om ett objeckt collidar med ett annat objekt s� kollar den under i funktionen.
    {

        if (collision.gameObject.tag == "Enemy") // Om man kollider med ett objekt med en tag "Enemy" s� kommer den loadar en battle scene
        {
            GameData.Instance.SetPlayerPosition(transform.position);
            // public string Scene = SceneManager.GetSceneByName("Battle encounter").name;
            SceneManager.LoadSceneAsync("Battle encounter") ;
            DontDestroyOnLoad(gameObject);
            Debug.Log("Suck my toe");
        }
        
   

    }



}
