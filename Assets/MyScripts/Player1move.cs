using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player1move : MonoBehaviour
{
    private Animator Anim;
    // Start is called before the first frame update
    void Start()
    {
        Anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        //walking left and right 
        if(Input.GetAxis("Horizontal")>0)
        {
            Anim.SetBool("Forward",true);
        }
        if(Input.GetAxis("Horizontal")<0)
        {
            Anim.SetBool("Backward",true);
        }
        if(Input.GetAxis("Horizontal")==0)
        {
            Anim.SetBool("Forward",false);
            Anim.SetBool("Backward",false);
        }
        //jumping and crouching
        if(Input.GetAxis("Vertical")>0)
        {
            Anim.SetTrigger("Jump");
        }
        if(Input.GetAxis("Vertical")<0)
        {
            Anim.SetBool("Crouch",true);
        }
        if(Input.GetAxis("Vertical")==0)
        {
            Anim.SetBool("Crouch",false);
        }
    }
}
