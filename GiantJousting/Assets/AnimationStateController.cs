using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationStateController : MonoBehaviour
{
    Animator animator;
    //store is walking string as the simpler data type hash
    int isWalkingHash;
    int isWalkingBackHash;
    int isBlockingHash;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        isWalkingHash = Animator.StringToHash("isWalking");
        isWalkingBackHash = Animator.StringToHash("isWalkingBack");
        isBlockingHash = Animator.StringToHash("Great Sword Blocking");
    }

    // Update is called once per frame
    void Update()
    {
        bool isWalking = animator.GetBool(isWalkingHash);
        bool isWalkingBack = animator.GetBool(isWalkingBackHash);
        bool forwardPressed = Input.GetKey("w");
        bool backwardPressed = Input.GetKey("s");

        if (!isWalking && forwardPressed)
        {
            animator.SetBool("isWalking", true);
        }
        if (isWalking && !forwardPressed)
        {
            animator.SetBool("isWalking", false);
        }

        if (!isWalkingBack && backwardPressed)
        {
            animator.SetBool("isWalkingBack", true);
        }
        if (isWalkingBack && !backwardPressed)
        {
            animator.SetBool("isWalkingBack", false);
        }

        if (Input.GetButtonDown("Fire1"))
        {
            animator.Play("Great Sword Slash");
        }

        if (Input.GetMouseButtonDown(2))
        {
            animator.SetTrigger("Block");
        }

        if (Input.GetMouseButtonDown(2))
        {
            animator.ResetTrigger("Block");
        }

    }
}
