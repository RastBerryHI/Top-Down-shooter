using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementAnimator : MonoBehaviour
{
    [SerializeField]
    Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    void BlendBaseMoving() 
    {
        animator.SetFloat("Velocity", Input.GetAxis("Vertical"));
        int horizontal = Mathf.RoundToInt(Input.GetAxisRaw("Horizontal"));
        animator.SetInteger("Strafe", horizontal);
    }

    void Update()
    {
        BlendBaseMoving();
        
        if(Input.GetAxisRaw("Horizontal") == 0f && Input.GetAxisRaw("Vertical") == 0f) 
        {
            animator.SetBool("isIdle", true);
        }
        else 
        {
            animator.SetBool("isIdle", false);
        }

        float mouseX = Input.GetAxisRaw("Mouse X");
        animator.SetFloat("Turning", mouseX);
        Debug.Log(mouseX);
    }
}
