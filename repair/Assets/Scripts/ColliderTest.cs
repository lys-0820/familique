using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ColliderTest : MonoBehaviour
{
    public Camera mainCamera; // 主摄像机
    public Camera focusCamera; // 对焦摄像机
    public Animator animator;
    public Button BtMainCamera;
    public GameObject noticeSign;
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
        if (Input.GetMouseButtonDown(0)) // when left mouse is clicked
        {
            Debug.Log(Camera.main);
            // get the position of the mouse
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            // collision happens
            if (Physics.Raycast(ray, out hit))
            {
                if (hit.collider.gameObject == gameObject)
                {
                    Debug.Log(gameObject);
                    noticeSign.SetActive(false);
                    // change to the focus camera and begin the animation
                    mainCamera.enabled = false;
                    focusCamera.enabled = true;
                    animator.SetTrigger("enterAnim");
                    BtMainCamera.gameObject.SetActive(true);
                }
            }
        }
    }
}
