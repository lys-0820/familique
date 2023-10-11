using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderTest : MonoBehaviour
{
    public Camera mainCamera; // 主摄像机
    public Camera focusCamera; // 对焦摄像机
    public Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        // 切换到主摄像机
        mainCamera.enabled = true;
        focusCamera.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0)) // 检测鼠标左键点击
        {
            Debug.Log(Camera.main);
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                // 点击到了物体
                // TODO：更改为Bool，再点击一次返回主场景
                if (hit.collider.gameObject == gameObject)
                {
                    Debug.Log(gameObject);
                    // 切换到对焦摄像机
                    mainCamera.enabled = false;
                    focusCamera.enabled = true;
                    animator.SetTrigger("enterAnim");
                }
            }
        }
    }
}
