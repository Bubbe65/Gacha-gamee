using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movment : MonoBehaviour
{
    // Start is called before the first frame update
    Rigidbody2D rigidbody2d;
    public float speed;
    private Animator animator;
    void Start()
    {
        animator = GetComponent<Animator>();
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
}
