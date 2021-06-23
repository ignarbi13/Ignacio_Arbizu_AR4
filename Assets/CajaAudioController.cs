using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CajaAudioController : MonoBehaviour  
{

    AudioSource source; // Declaramos la �nica fuente de audio que tenemos. 

    // Start is called before the first frame update
    void Start()
    {
        source = GetComponent<AudioSource>();

        Renderer rend = GetComponent<Renderer>();
        Bounds bounds = rend.bounds;

        source.pitch = 1.5f / bounds.size.x; // Esta funcion declara que el pitch de la colisi�n, ser� m�s agudo o m�s grave en funci�n del tama�o del bloque. Cuanto m�s grande m�s grave y cuanto m�s peque�o m�s agudo. 
    }

    // Update is called once per frame
    void Update()
    {

    }

       
    void OnCollisionEnter(Collision collision) // Declaramos que habr� una colisi�n con esta funci�n OnCollisionEnter, y los siguientes pasos actuar�n en funci�n de esta matriz.
    {
        source.Play(); // Cuando ocurra esta colisi�n, sonar� el sonido del coque contra un bloque. 
    }
}
