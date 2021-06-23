using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pelota2AudioController : MonoBehaviour
{

    // THIS IS AN ARRAY !
    AudioSource[] sources; //Declaramos los audios que queremos llamar.
    Rigidbody rb; 
    float speed = 0.0f;
    bool isPlaying = false;
    //Definimos la velocidad de la pelota

    // Start is called before the first frame update
    void Start()
    {
        sources = GetComponents<AudioSource>();
        rb = GetComponent<Rigidbody>();
        sources[1].pitch = 1.0f / rb.mass; //Aqui declaramos el AudioSource[1], que es el sonido de la colisi�n con la pelota1 y hacemos que, el pitch de este sonido sea diferente en cada colisi�n. 
    }

    // Update is called once per frame
    void Update()
    {
        speed = rb.velocity.magnitude;

        if (speed > 0.1f && !isPlaying)
        {
            isPlaying = true;
            sources[0].Play();
            // Si la Pelota2 esta en movimiento, sonar� el Audiosource[0], que es el sonido del movimiento. Sabr� cuando esta en movimiento cuando la velocidad de la Pelota2 sea superior a 0.1f. 
        }
        else if (speed < 0.1f)
        {
            isPlaying = false;
            sources[0].Stop();
            // Si la Pelota2 esta NO en movimiento, el Audiosource[0] parar� de sonar. Sabr� cuando no esta en movimiento cuando la velocidad de la Pelota2 sea inferior a 0.1f. 

        }

        sources[0].pitch = speed / rb.mass; //Aqui declaramos el AudioSource[0], que es el sonido del movimiento de la pelota y hacemos que, el pitch de este sonido suba o baje en funci�n de la velocidad en la que vaya. 
    }
      
    void OnCollisionEnter(Collision collision) // Declaramos que habr� una colisi�n con esta funci�n OnCollisionEnter, y los siguientes pasos actuar�n en funci�n de esta matriz. 
    {
   
        sources[1].Play(); // Cuando haya una colisi�n, llamaremos al sonido que hemos declarado como el de choque entre pelotas. 
    }

}
