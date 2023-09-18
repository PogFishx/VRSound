using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMOD.Studio;

public class PlayerFootsteps : MonoBehaviour
{
    CharacterController controller;

    private EventInstance playerFootsteps;

    private void Start()
    {
        controller = GetComponent<CharacterController>();
        playerFootsteps = AudioManager.instance.CreateInstance(FMODEvents.instance.playerFootsteps);
    }

    private void FixedUpdate()
    {
        UpdateSound();
    }

    private void UpdateSound()
    {
        if (controller.velocity.x != 0 || controller.velocity.z != 0)
        { 
            PLAYBACK_STATE playbackState;
            playerFootsteps.getPlaybackState(out playbackState);
            if (playbackState.Equals(PLAYBACK_STATE.STOPPED))
            {
                playerFootsteps.start();
            }
        }
        else
        {
            playerFootsteps.stop(STOP_MODE.ALLOWFADEOUT);
        }
    }
}
