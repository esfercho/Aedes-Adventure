using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CriaderoController : MonoBehaviour
{
   
    void Update()
    {
        if (Input.GetMouseButtonDown(0)) // Detecta clic izquierdo
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                if (hit.collider != null && hit.collider.CompareTag("Criadero"))
                {
                    Destroy(hit.collider.gameObject);
                }
            }
        }
        if(Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            Ray ray = Camera.main.ScreenPointToRay(touch.position);
            RaycastHit hit;
            
            if (Physics.Raycast(ray,out hit))
            {
                if(hit.collider != null && hit.collider.CompareTag("Criadero"))
                {
                    Destroy(hit.collider.gameObject);
                    Handheld.Vibrate();
                }
            }
        }
    }
}
