using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public AudioClip coin, enemy3Attack, enemy1Attack, throwKnifeAtive, enemy2Attack;

    public AudioSource audioSource;
    // Start is called before the first frame update
    void Start()
    {
        coin = Resources.Load<AudioClip>("coin2");
        enemy3Attack = Resources.Load<AudioClip>("monstar_attack3");
        enemy1Attack = Resources.Load<AudioClip>("birdAttack");
        // Âm thanh Player attack 1
        throwKnifeAtive = Resources.Load<AudioClip>("throw_knife_effect");
        enemy2Attack = Resources.Load<AudioClip>("enemy2_attack");
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

            case "enemy1Attack":
                audioSource.PlayOneShot(enemy1Attack);
                break;

            case "throwKnifeAtive":
                audioSource.PlayOneShot(throwKnifeAtive);
                break;

            case "enemy2Attack":
                audioSource.PlayOneShot(enemy2Attack);
                break;
        }
    }
}
