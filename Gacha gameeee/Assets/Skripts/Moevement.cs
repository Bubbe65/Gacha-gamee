using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{


    Rigidbody2D rigidbody2d;
    public float speed;

    private Animator animator;

    int currentHealth;
    public int maxHealth;



  
    // Start is called before the first frame update
    void Start()
    {


        animator = GetComponent<Animator>();

        rigidbody2d = GetComponent<Rigidbody2D>();
        currentHealth = maxHealth;


        rigidbody2d = GetComponent<Rigidbody2D>();
        currentHealth = maxHealth;

    }

    // Update is called once per frame
    void Update()
    {
        float horizontalinput = Input.GetAxis("Horizontal");
        float verticalinput = Input.GetAxis("Vertical");

        Vector3 direction = new(horizontalinput, verticalinput, 0);

        transform.Translate(direction * speed * Time.deltaTime);

        animator.SetFloat("Horizontal", horizontalinput);
        animator.SetFloat("Vertical", verticalinput);

    }


    void ChangeHealth(int amount)
    {
        currentHealth = Mathf.Clamp(currentHealth + amount, 0, maxHealth);
        Debug.Log(currentHealth + "/" + maxHealth);
    }



}
