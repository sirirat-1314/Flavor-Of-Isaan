using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Mr : MonoBehaviour
{
    private Animator anim;

    void Start()
    {
        anim = GetComponent<Animator>();   
    }

    private void Update()
    {
        
    }

    public void Smash()
    {
        anim.SetBool("smash", true);
    }
}
