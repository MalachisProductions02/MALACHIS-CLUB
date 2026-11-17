using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    PlayerControls controls; // Se llama a la clase PlayerControls para el ImputSystem
    float direction = 0;

    public float speed = 400f; // Velocidad del jugador

    public RigidBody2D playerRB;

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
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        playerRb.velocity = new Vector2(direction * speed * Time.deltaTime, playerRB.velocity.y); 
        // Se asigna la velocidad del jugador en el eje X según la dirección y la velocidad, 
        // y se mantiene la velocidad en el eje Y


    }
}
