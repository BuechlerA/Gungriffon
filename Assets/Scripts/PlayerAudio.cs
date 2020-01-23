using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAudio : MonoBehaviour
{
    private AudioSource playerAudio;
    private CharacterController characterController;

    public AudioClip boostSound;
    public AudioClip walkSound;

    void Start()
    {
        characterController = GetComponent<CharacterController>();
        playerAudio = GetComponent<AudioSource>();
    }
 
    void Update()
    {
        if (characterController.GetComponent<PlayerController>().movementState == MovementModes.boost && playerAudio.isPlaying == false)
        {
            playerAudio.clip = boostSound;
            playerAudio.loop = true;
            playerAudio.volume = 0.2f;
            playerAudio.pitch = 1.5f;
            playerAudio.Play();
        }
        if (characterController.GetComponent<PlayerController>().movementState == MovementModes.walk && playerAudio.isPlaying == false)
        {            
            playerAudio.clip = walkSound;
            playerAudio.pitch = 0.8f;
            playerAudio.Play();
        }
        if (characterController.velocity.magnitude < 0.1f)
        {
            playerAudio.Stop();
        }
    }
}
