using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public AudioClip coin, enemy3Attack, knifeAttack, jump, dead, enemy1Attack, throwKnife, throwKnifeAtive;

    public AudioSource audioSource;
    // Start is called before the first frame update
    void Start()
    {
        coin = Resources.Load<AudioClip>("coin2");
        enemy3Attack = Resources.Load<AudioClip>("monstar_attack3");
        enemy1Attack = Resources.Load<AudioClip>("birdAttack");
        // Âm thanh Player attack 1
        knifeAttack = Resources.Load<AudioClip>("knife-attack");
        jump = Resources.Load<AudioClip>("jumpMan");
        dead = Resources.Load<AudioClip>("dead");
        throwKnife = Resources.Load<AudioClip>("throw_knife");
        throwKnifeAtive = Resources.Load<AudioClip>("throw_knife_effect");
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
            case "coin":
                audioSource.PlayOneShot(coin);
                break;

            case "enemy3Attack":
                audioSource.PlayOneShot(enemy3Attack, 0.5f);
                break;

            case "knifeAttack":   
                audioSource.PlayOneShot(knifeAttack, 0.5f);
                break;

            case "jump":           
                audioSource.PlayOneShot(jump);
                break;

            case "dead":
                audioSource.PlayOneShot(dead);
                break;

            case "enemy1Attack":
                audioSource.PlayOneShot(enemy1Attack);
                break;

            case "throwKnife":
                audioSource.PlayOneShot(throwKnife);
                break;

            case "throwKnifeAtive":
                audioSource.PlayOneShot(throwKnifeAtive);
                break;
        }
    }
}
