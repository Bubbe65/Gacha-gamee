using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ash : MonoBehaviour
{
    private void Start()
    {
        Rigidbody2D rigidbody2d;
    }

    public float speed;

    private Animator animator;
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
