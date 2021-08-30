using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spike : MonoBehaviour
{
    private PlayerController player;
    public float rightPow, leftPow, upPowL, upPowR;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
    }
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            // Truyền dữ liệu qua Player khi vị trí player < vị trí this
            if(player.transform.position.x < gameObject.transform.position.x)
            {
                player.Damage(1);
                player.KnockBack(upPowL, leftPow, player.transform.position);
            }
            // Truyền dữ liệu qua Player khi vị trí player > vị trí this
            if (player.transform.position.x > gameObject.transform.position.x)
            {
                player.Damage(1);
                player.KnockBack(upPowR, rightPow, player.transform.position);
            }
        }
    }
}
