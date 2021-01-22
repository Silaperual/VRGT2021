using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestQua : MonoBehaviour
{
    public Transform cube; // 位于(0, 3, 0)的一个cube的transform
    public Vector3 target;   // cube的朝向目标, 初始值为(0, 3, 0)


    void Update()
    {
        cube.rotation = Quaternion.LookRotation(target - cube.position, Vector3.up); // 注意, 此处Vector3.up并不一定与target - cube.position垂直

        Debug.DrawLine(Vector3.zero, cube.forward, Color.blue); // 绘制每根轴
        Debug.DrawLine(Vector3.zero, cube.right, Color.red);
        Debug.DrawLine(Vector3.zero, cube.up, Color.green);
    }
}
