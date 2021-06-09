using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knife : MonoBehaviour
{
    private GameMaster gm;
    private SoundManager sound;
    // Start is called before the first frame update
    void Start()
    {
        sound = GameObject.FindGameObjectWithTag("Sound").GetComponent<SoundManager>();
        gm = GameObject.FindGameObjectWithTag("GameMaster").GetComponent<GameMaster>();
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnTriggerStay2D(Collider2D col)
    {
        if (gm.amountKnife < 3)
        {
            if (col.isTrigger == false && col.CompareTag("Player"))
            {
                sound.PlaySound("coin");
                gm.amountKnife += 1;
                Destroy(gameObject);
            }
        }
    }
}
