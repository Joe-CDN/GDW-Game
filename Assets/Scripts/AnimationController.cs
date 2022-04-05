using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationController : MonoBehaviour
{
    private Animator mAnimator;
    // Start is called before the first frame update
    void Start()
    {
        mAnimator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(mAnimator != null)
        {
            if (Input.GetAxisRaw("Horizontal") != 0 || Input.GetAxisRaw("Vertical") != 0)
            {
                //mAnimator.SetTrigger("TrWalk");
                mAnimator.SetBool("isMoving", true);
            }
            else
            {
                //mAnimator.SetTrigger("TrIdle");
                mAnimator.SetBool("isMoving", false);
            }

            if(OnlineMove.isGrabbing)
            {
                //mAnimator.SetTrigger("TrGrab");
                mAnimator.SetBool("isGrabbing", true);
            }
            else
            {
                //mAnimator.SetTrigger("TrLetGo");
                mAnimator.SetBool("isGrabbing", false);
            }
        }
    }
}
