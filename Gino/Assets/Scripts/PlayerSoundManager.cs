using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSoundManager : MonoBehaviour
{
    public AudioClip knifeAttack, jump, dead, throwKnife;

    public AudioSource audioSource;
    // Start is called before the first frame update
    void Start()
    {
        // Âm thanh Player attack 1
        knifeAttack = Resources.Load<AudioClip>("knife-attack");
        jump = Resources.Load<AudioClip>("jumpMan");
        dead = Resources.Load<AudioClip>("dead");
        throwKnife = Resources.Load<AudioClip>("throw_knife");
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void PlaySound(string clip)
    {
        switch (clip)
        {
            case "knifeAttack":
                audioSource.PlayOneShot(knifeAttack, 0.5f);
                break;

            case "jump":
                audioSource.PlayOneShot(jump);
                break;

            case "dead":
                audioSource.PlayOneShot(dead);
                break;

            case "throwKnife":
                audioSource.PlayOneShot(throwKnife);
                break;

        }
    }
}
