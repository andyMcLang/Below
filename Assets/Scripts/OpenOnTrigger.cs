using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenOnTrigger : MonoBehaviour
{
    private Animator anim;
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            anim.SetBool("Open", true);
        }

        if (other.tag == "Enemy")
        {
            anim.SetBool("Open", true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            anim.SetBool("Open", false);
        }

        if (other.tag == "Enemy")
        {
            anim.SetBool("Open", false);
        }
    }

}
