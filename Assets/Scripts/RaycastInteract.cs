using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaycastInteract : MonoBehaviour
{
    public float fireRate = 0.25f;
    public float interactRange = 5f;

    public GameObject interactText;
    public bool showing = false;

    private Camera fpsCam;
    private float nextFire;

    void Start()
    {
        fpsCam = GetComponentInParent<Camera>();
    }

   
    void Update()
    {
        /* RaycastHit hit;

        Vector3 rayOrigin = fpsCam.ViewportToWorldPoint(new Vector3(0.5f, 0.5f, 0));

        if (Physics.Raycast(rayOrigin, fpsCam.transform.forward, out hit, interactRange, ~LayerMask.GetMask("Player", "Ignore Raycast")))
        {
            if(hit.collider.GetComponent<Iinteractable>() != null)
            {
                interactText.SetActive(true);
                showing = true;
            }
            else if (showing)
            {
                interactText.SetActive(false);
                showing = false;
            }
        }
        else if (showing)
        {
            interactText.SetActive(false);
            showing = false;
        } 

         if (Input.GetButtonDown("Interact") && Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;

            

            if (Physics.Raycast(rayOrigin, fpsCam.transform.forward, out hit, interactRange, ~LayerMask.GetMask("Player", "Ignore Raycast")))
            {
                Iinteractable interactScript = hit.collider.GetComponent<Iinteractable>();

                if(interactScript != null)
                {
                    interactScript.Interact();
                }
            }
        } */
    }
}
