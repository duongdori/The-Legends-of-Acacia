using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class parallaxClound : MonoBehaviour
{
    public float speed = 1f;  // Tốc độ di chuyển của đám mây

    // Update được gọi mỗi khung hình
    void Update()
    {
        // Di chuyển đám mây sang phải dựa trên tốc độ và thời gian đã trôi qua từ lần cuối cùng cập nhật
        transform.Translate(Vector3.right * speed * Time.deltaTime);
    }
}
