using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [Header("Smooth Camera")]
    // Giá trị độ chậm chuyển động camera
    public float smoothtimeX; 
    public float smoothtimeY;

    [Header("Min-Max POS")]
    public Vector2 minPos; 
    public Vector2 maxPos;
    [Space(10)]
    public bool bound;

    [Header("Target")]
    public GameObject player;

    private PlayerController control;
    private Vector2 velocity;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        control = player.GetComponent<PlayerController>();
    }

    void LateUpdate()
    {
        float posX;
        // Đặt posX theo trục X với mục tiêu là Player với độ chậm chuyển động smoothtimeX
        if (control.faceRight)
        {
            posX = Mathf.SmoothDamp(this.transform.position.x, player.transform.position.x + 5f, ref velocity.x, smoothtimeX);
        }
        else
        {
            posX = Mathf.SmoothDamp(this.transform.position.x, player.transform.position.x - 5f, ref velocity.x, smoothtimeX);
        }

        // Đặt posY theo trục Y với mục tiêu là Player với độ chậm chuyển động smoothtimeY
        float posY = Mathf.SmoothDamp(this.transform.position.y, player.transform.position.y + 2f, ref velocity.y, smoothtimeY);
        // Thay đổi vị trí camera theo posX, posY
        transform.position = new Vector3(posX, posY, transform.position.z);

        if (bound)
        {
            // Giới hạn khung hình camera di chuyển với giá trị min, max
            transform.position = new Vector3(Mathf.Clamp(transform.position.x, minPos.x, maxPos.x),
                                            Mathf.Clamp(transform.position.y, minPos.y, maxPos.y),
                                            Mathf.Clamp(transform.position.z, transform.position.z, transform.position.z));
        }
    }
}
