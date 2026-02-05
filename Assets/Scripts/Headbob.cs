using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class Headbob : MonoBehaviour
{
    public Animator camAnim;
    public bool walking;

    void Update()
    {
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D))
        {
            camAnim.ResetTrigger("idle");
            walking = true;
           
            camAnim.SetTrigger("walk");
           
        }
        else
        {
         
            walking = false;
            camAnim.ResetTrigger("walk");
            camAnim.SetTrigger("idle");
        }
    }
}