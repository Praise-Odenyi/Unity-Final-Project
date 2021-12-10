using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class animatorStateController : MonoBehaviour
{
    Animator animator;
    int isWalkingHash;
    int isRunningHash;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        // 
        isWalkingHash = Animator.StringToHash("isWalking");
        isRunningHash = Animator.StringToHash("isRunning");

    }

    // Update is called once per frame
    void Update()
    {
        bool isrunning = animator.GetBool(isRunningHash);
        bool isWalking = animator.GetBool(isWalkingHash);
        bool forwardPressed = Input.GetKey("w");
        bool runPressed = Input.GetKey("left shift");

        // if player presses w
        if (!isWalking && forwardPressed)
        {
            // walking is true
            animator.SetBool(isWalkingHash, true);
        }

        // if player isn't pressing w
        if (isWalking && !forwardPressed)
        {
            // walking is false
            animator.SetBool(isWalkingHash, false);
        }

        // if the player is walking and presses shift
        if (!isrunning && (forwardPressed && runPressed))
        {
            // set it to be true
            animator.SetBool(isRunningHash, true);
        }

        // if player stops running or stops  walking
        if (isrunning && (!forwardPressed || !runPressed))
        {
            // set false
            animator.SetBool(isRunningHash, false);
        }
    }
}
