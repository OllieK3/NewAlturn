using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class interactable : MonoBehaviour
{
    public Animator anim;
    public bool opendoor;
    // Start is called before the first frame update
    void Start()
    {
        anim = gameObject.GetComponent<Animator>();
    }
    public void Interact()
    {
        Debug.Log("pee");
        if (opendoor == true)
        {
            anim.SetTrigger("open");
        }
    }
}
