using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenOnInteract : MonoBehaviour, Iinteractable
{
    private Animator anim;
    private bool open = false;

    void Start()
    {
        anim = GetComponentInParent<Animator>();
    }

    public void Interact()
    {
        open = !open;
        anim.SetBool("Open", open);
    }
}
