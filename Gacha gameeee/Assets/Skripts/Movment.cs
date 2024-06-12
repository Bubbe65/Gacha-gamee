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
        // Använder animator vid starten av spelet.
        animator = GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {
        // Vanlig script för rörelse 

        float horizontalinput = Input.GetAxis("Horizontal"); // Input för horizontal input
        float verticalinput = Input.GetAxis("Vertical"); // Input för Vertical input

        Vector3 direction = new(horizontalinput, verticalinput, 0);
        transform.Translate(direction * speed * Time.deltaTime);

        animator.SetFloat("Horizontal", horizontalinput); // aktiverar animator när man använder input spefikt för Horizontal 
        animator.SetFloat("Vertical", verticalinput); // aktiverar animator när man använder input spefikt för Horizontal 



    }
    private void OnCollisionEnter2D(Collision2D collision) // Kollar om ett objeckt collidar med ett annat objekt så kollar den under i funktionen.
    {

        if (collision.gameObject.tag == "Enemy") // Om man kollider med ett objekt med en tag "Enemy" så kommer den loadar en battle scene
        {
            GameData.Instance.SetPlayerPosition(transform.position);
            // public string Scene = SceneManager.GetSceneByName("Battle encounter").name;
            SceneManager.LoadSceneAsync("Battle encounter") ;
            DontDestroyOnLoad(gameObject);
            Debug.Log("Suck my toe");
        }
        
   

    }



}
