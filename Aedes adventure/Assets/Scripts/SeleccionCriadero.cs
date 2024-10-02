using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SeleccionCriadero : MonoBehaviour
{
    private int contadorCriaderos = 0;
    public Text contadorTexto;

    public ParticleSystem efectoDestello;
   
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            SeleccionCriadero1(Input.mousePosition);
        }
        if(Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            SeleccionCriadero1(touch.position);
        }
    }
    void SeleccionCriadero1(Vector2 posicion)
    {
        Ray ray = Camera.main.ScreenPointToRay(posicion);
        RaycastHit hit;

        if(Physics.Raycast(ray,out hit))
        {
            if(hit.collider != null && hit.collider.CompareTag("Criadero1"))
            {
                StartCoroutine(marcarYDestruir(hit.collider.gameObject));

            }
        }
    }
    IEnumerator marcarYDestruir (GameObject criadero)
    {
        Renderer renderer = criadero.GetComponent<Renderer>();
        if(renderer != null)
        {
            renderer.material.color = Color.green;
        }

        ParticleSystem destello = Instantiate(efectoDestello, criadero.transform.position, Quaternion.identity);
        destello.Play();
        yield return new WaitForSeconds(0.5f);
        Destroy(criadero);

        contadorCriaderos++;

        ActualizarTextoContador();
    }
    void ActualizarTextoContador()
    {
        if (contadorTexto != null)
        {
            contadorTexto.text = "Criaderos eliminados:"+ contadorCriaderos;
        }
    }
}
