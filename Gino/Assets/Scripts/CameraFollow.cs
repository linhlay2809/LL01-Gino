using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    // Giá trị độ chậm chuyển động camera
    public float smoothtimeX, smoothtimeY;
    public Vector2 velocity;

    public GameObject player;

    public Vector2 minPos, maxPos;
    public bool bound;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void FixedUpdate()
    {
        // Đặt posX theo trục X với mục tiêu là Player với độ chậm chuyển động smoothtimeX
        float posX = Mathf.SmoothDamp(this.transform.position.x, player.transform.position.x, ref velocity.x, smoothtimeX);
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
