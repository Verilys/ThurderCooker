using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VerticalLoopMovement : MonoBehaviour
{
    public float moveSpeed = 2.0f; // 移动速度
    public float minY = -5.0f;      // 移动的最小Y坐标
    public float maxY = 5.0f;       // 移动的最大Y坐标

    void Update()
    {
        // 计算新的Y坐标
        float newY = Mathf.PingPong(Time.time * moveSpeed, maxY - minY) + minY;

        // 更新物体的位置
        transform.position = new Vector3(transform.position.x, newY, transform.position.z);
    }
}
