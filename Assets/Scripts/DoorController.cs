﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorController : MonoBehaviour
{
    private Animator animator;
    private bool isDoorOpen = false;
    public AudioClip openDoorClip;
    public AudioClip closeDoorClip;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    public void OnClickDoor()
    {
        if (isDoorOpen == false)
        {
            isDoorOpen = true;
            OpenDoor();
        }
        else
        {
            isDoorOpen = false;
            CloseDoor();
        }
    }

    private void OpenDoor()
    {
        AudioSource.PlayClipAtPoint(openDoorClip, transform.position);
        animator.SetBool("isPlayClose", false);
        animator.SetBool("isPlayOpen", true);
    }

    private void CloseDoor()
    {
        AudioSource.PlayClipAtPoint(closeDoorClip, transform.position);
        animator.SetBool("isPlayOpen", false);
        animator.SetBool("isPlayClose", true);
    }
}