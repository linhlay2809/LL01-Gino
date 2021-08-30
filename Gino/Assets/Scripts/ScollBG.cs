using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScollBG : MonoBehaviour
{
    private PlayerController player;
    [SerializeField] private float speedScoll = 0.2f;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
    }

    private void FixedUpdate()
    {
        Vector2 offset = GetComponent<MeshRenderer>().material.mainTextureOffset;
        // Di chuyển background theo Player
        offset.x = player.transform.position.x;
        GetComponent<MeshRenderer>().material.mainTextureOffset = offset * Time.deltaTime / speedScoll;
    }
}
