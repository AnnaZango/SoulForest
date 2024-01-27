using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundsAnimations : MonoBehaviour
{
    [SerializeField] AudioSource eatSound;
    [SerializeField] AudioSource jumpSound;
    [SerializeField] AudioSource hurtSound;

    
    public void PlayEatSound()
    {
        eatSound.Play();
    }

    public void JumpSound()
    {
        jumpSound.Play();
    }

    public void HurtSound()
    {
        hurtSound.Play();
    }
}
