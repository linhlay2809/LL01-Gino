using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HeartUI : MonoBehaviour
{
    public Sprite[] heartSprite;
    public Sprite[] heartSprite2;
    public Sprite[] heartSprite3;

    public PlayerController player;

    public Image heartImg;
    public Image heartImg2;
    public Image heartImg3;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
    }

    void Update()
    {
        if (player.ourHealth >= 0)
        {
            // Hiển thị hình ảnh dựa trên số máu đã mất
            heartImg.sprite = heartSprite[player.ourHealth];
            heartImg2.sprite = heartSprite2[player.ourHealth];
            heartImg3.sprite = heartSprite3[player.ourHealth];
        }
        else if(player.ourHealth < 0)
        {
            heartImg.sprite = heartSprite[0];
            heartImg2.sprite = heartSprite2[0];
            heartImg3.sprite = heartSprite3[0];
        }
        
    }
}
