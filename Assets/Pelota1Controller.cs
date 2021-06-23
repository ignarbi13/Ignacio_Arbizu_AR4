using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pelota1Controller : MonoBehaviour
{

    AudioSource[] sources; //Declaramos los audios que queremos llamar
    Rigidbody rb;
    float speed = 0.0f;
    bool isPlaying = false;
    //Definimos la velocidad de la pelota en cada momento

    // Start is called before the first frame update
    void Start()
    {
        sources = GetComponents<AudioSource>();
        rb = GetComponent<Rigidbody>();
        sources[1].pitch = 1.0f / rb.mass; //Aqui declaramos el AudioSource[1], que es el sonido de choque de la pelota, que lo baja de pitch cuando choca contra la Pelota2.
    }

    // Update is called once per frame
    void Update()
    {
        speed = rb.velocity.magnitude;

        if (speed > 0.1f && speed < 5.0f && !isPlaying)
        {
            isPlaying = true;
            sources[0].Play();
            // Aqui marcamos que cuando la pelota esté en movimiento, suene el AudioSource[0], que es el sonido del movimiento.
        }
        else if (speed < 0.1f)
        {
            isPlaying = false;
            sources[0].Stop(); // En cambio aqui, marcamos que cuando la pelota no esté en movimiento, el AudioSource[0] (sonido del movimimento de la pelota) no suene. 
        }


        sources[0].pitch = speed / rb.mass; // Declaramos que cuando la pelota se mueve, cambiara de pitch segun su velocidad. 

        print(speed);
    }
     
    void OnCollisionEnter(Collision collision) // Variable que declara un choque de un objeto contra otro. 
    {
        Rigidbody otherRb = collision.gameObject.GetComponent<Rigidbody>();

        if (otherRb)
        {
            if (otherRb.mass < rb.mass)
            {
                // cuando la Pelota rb.mass choca contra otro RigidBody, en este caso la pelota2, llamaremos a que suene el AudioSource[1], que es el sonido del choque de pelota. 
                sources[1].Play();
                print("we hit a lighter object"); // Es la frase que no aparecerá en el console. 
            }
            else
            {
                print("we hit a heavier object"); // Es la frase que no aparecerá en el console.
            }


        }
        else
        {

            print("we hit a lmassless object"); // La primera frase que nos va a aparecer porque es lo primero que va a ocurrir, la colisión con el suelo. 
            sources[1].Play(); // Llamamos al sonido de colisión de una pelota cuando entramos en el juego, que colisiona contra el suelo que es un "massless object". 
        }


    }

}
