using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameMaster : MonoBehaviour
{
    [Header("Information")]
    public int score;
    public int amountKnife = 3;

    [Header("Texts")]
    public Text scoreText;
    public Text knifeText;
    public Text pressEText;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Cộng điểm khi ăn diamond
        scoreText.text = "" + score;
        // Hiển thị số lượng knife
        knifeText.text = "" + amountKnife;
        // Giới hạn knife là 3
        if(amountKnife > 3)
        {
            amountKnife = 3;
        }
    }
}
