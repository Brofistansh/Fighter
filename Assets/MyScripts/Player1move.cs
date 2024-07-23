// using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player1move : MonoBehaviour
{
    private Animator Anim;
    public float WalkSpeed = 0.01f;
    private AnimatorStateInfo Player1Layer0;

    // Start is called before the first frame update
    void Start()
    {
        Anim = GetComponentInChildren<Animator>();
        Player1Layer0 = Anim.GetCurrentAnimatorStateInfo(0); // Initialize AnimatorStateInfo here if needed
    }

    // Update is called once per frame
    void Update()
    {
        if (Anim == null)
        {
            Debug.LogError("Animator component not found!");
            return;
        }

        Player1Layer0 = Anim.GetCurrentAnimatorStateInfo(0);

        //walking left and right 
        if (Player1Layer0.IsTag("Motion"))
        {
            if (Input.GetAxis("Horizontal") > 0)
            {
                Anim.SetBool("Forward", true);
                transform.Translate(WalkSpeed, 0, 0);
            }
            if (Input.GetAxis("Horizontal") < 0)
            {
                Anim.SetBool("Backward", true);
                transform.Translate(-WalkSpeed, 0, 0);
            }
        }
        if (Input.GetAxis("Horizontal") == 0)
        {
            Anim.SetBool("Forward", false);
            Anim.SetBool("Backward", false);
        }

        //jumping and crouching
        if (Input.GetAxis("Vertical") > 0)
        {
            Anim.SetTrigger("Jump");
        }
        if (Input.GetAxis("Vertical") < 0)
        {
            Anim.SetBool("Crouch", true);
        }
        if (Input.GetAxis("Vertical") == 0)
        {
            Anim.SetBool("Crouch", false);
        }
    }
}
