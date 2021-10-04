using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameMaster : MonoBehaviour
{
    [Header("Information")]
    private int score;
    public int amountKnife;

    [Header("Texts")]
    public Text scoreText;
    public Text knifeText;
    public Text pressEText;

    // Update is called once per frame
    void Update()
    {
        // Giới hạn knife là 3
        if(amountKnife > 3)
        {
            amountKnife = 3;
        }
    }
    // Cộng điểm khi ăn diamond
    public void AddScore(int score)
    {
        this.score += score;
        scoreText.text = "" + this.score;
    }
    // Hiển thị số lượng knife
    public void AddKnife(int knife)
    {
        this.amountKnife += knife;
        knifeText.text = "" + amountKnife;
    }
}
