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
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (player.ourHealth >= 0)
        {
            // Hiển thị hình ảnh dựa trên số máu đã mất
            heartImg.sprite = heartSprite[player.ourHealth];
            heartImg2.sprite = heartSprite2[player.ourHealth];
            heartImg3.sprite = heartSprite3[player.ourHealth];
        }
        
    }
}
