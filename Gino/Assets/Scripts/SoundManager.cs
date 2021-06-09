using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public AudioClip coin, enemy3Attack, knifeAttack, jump, dead, enemy1Attack;

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
                audioSource.clip = coin;
                audioSource.PlayOneShot(coin);
                break;

            case "enemy3Attack":
                audioSource.clip = coin;
                audioSource.PlayOneShot(enemy3Attack, 0.5f);
                break;

            case "knifeAttack":
                audioSource.clip = coin;
                audioSource.PlayOneShot(knifeAttack, 0.5f);
                break;

            case "jump":
                audioSource.clip = coin;
                audioSource.PlayOneShot(jump);
                break;

            case "dead":
                audioSource.clip = coin;
                audioSource.PlayOneShot(dead);
                break;

            case "enemy1Attack":
                audioSource.clip = coin;
                audioSource.PlayOneShot(enemy1Attack);
                break;
        }
    }
}
