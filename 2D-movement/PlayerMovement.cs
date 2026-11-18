using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    PlayerControls controls; // Se llama a la clase PlayerControls para el ImputSystem
    float direction = 0;
    bool isFacingRight = true;

    public float jumpForce = 5f;
    bool isGrounded;
    public Transform groundCheck;
    int numberOfJumps = 0;
    public LayerMask groundLayer;

    public float speed = 400f; // Velocidad del jugador

    public RigidBody2D playerRB;
    public Animator animator;

    private void Awake() // Función que se llama antes del Start
    {
        controls = new PlayerControls(); // Se instancia la clase PlayerControls
        controls.Enable(); // Se habilita el InputSystem

        controls.Land.Move.performed += ctx =>
        {
            // La acción se ejecutará cuando se reciba el comando de Move en Land

            direction = ctx.ReadValue<float>(); // Se obtiene el valor del comando de Move y 
            // se asigna a la variable direction
        };

        controls.Land.Jump.performed += ctx => Jump();
        
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, 0.1f, groundLayer);
        // Se verifica si el jugador está tocando el suelo mediante 
        // un círculo de colisión en la posición de groundCheck

        animator.SetBool("isGrounded", isGrounded); // Se asigna el valor de isGrounded 
        // a la variable isGrounded del Animator

        playerRb.velocity = new Vector2(direction * speed * Time.fixedDeltaTime, playerRB.velocity.y); 
        // Se asigna la velocidad del jugador en el eje X según la dirección y la velocidad, 
        // y se mantiene la velocidad en el eje Y
        animator.SetFloat("speed", Mathf.Abs(direction)); // Se asigna el valor absoluto 
        // de la dirección a la variable speed del Animator

        if (isFacingRight && direction < 0 || !isFacingRight && direction > 0) 
        {
            // Si el jugador está mirando a la derecha y 
            // se mueve a la izquierda, o si está mirando a la izquierda y 
            // se mueve a la derecha
            Flip();
        }

    }

    void Flip()
    {
        isFacingRight = !isFacingRight; // Se invierte el valor de isFacingRight
        transform.localScale = new Vector2(transform.localScale.x * -1, transform.localScale.y);
        // Se invierte la escala del jugador en el eje X para que mire hacia la dirección opuesta
    }

    void Jump()
    {
        if (isGrounded)
        {
            numberOfJumps = 0; // Se reinicia el número de saltos realizados
            playerRB.velocity = new Vector2(playerRB.velocity.x, jumpForce);
            // Se asigna la velocidad del jugador en el eje Y según la fuerza de salto

            numberOfJumps ++; // Se incrementa el número de saltos realizados
        }
        else
        {
            if (numberOfJumps == 1)
            {
                playerRB.velocity = new Vector2(playerRB.velocity.x, jumpForce);
                numberOfJumps ++;
            }
        }
    }
}
