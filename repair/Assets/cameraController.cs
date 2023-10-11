using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class cameraController : MonoBehaviour
{
    public float rotationSpeed = 2.0f;

    void Update()
    {
        // 获取按键输入
        float horizontalInput = Input.GetAxis("Horizontal"); // A和D键或左右箭头键
        float verticalInput = Input.GetAxis("Vertical");     // W和S键或上下箭头键
//        print(horizontalInput);
        // 根据按键输入旋转摄像机
        Vector3 rotation = new Vector3(verticalInput, horizontalInput, 0) * rotationSpeed * Time.deltaTime;
        transform.Rotate(rotation);
    }
}
