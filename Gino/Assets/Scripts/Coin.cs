using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    private GameMaster gm;
    [SerializeField] private int changeScore;
    // Start is called before the first frame update
    void Start()
    {
        gm = GameObject.FindGameObjectWithTag("GameMaster").GetComponent<GameMaster>();
    }
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.isTrigger==false && col.CompareTag("Player"))
        {
            FindObjectOfType<SoundManager>().Play("Coin");
            gm.score += changeScore;
            Destroy(gameObject);
        }
    }
}
