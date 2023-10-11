using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class StatusController : MonoBehaviour
{
    public Button BtMainCamera;
    public Camera mainCamera; // 主摄像机
    public Camera focusCamera; // 对焦摄像机
    public Animator animator;
    public GameObject noticeSign;
    // Start is called before the first frame update
    void Start()
    {
        
        BtMainCamera.onClick.AddListener(OnClickMainCamera);
        BtMainCamera.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnClickMainCamera()
    {
        // 切换到main摄像机
        mainCamera.enabled = true;
        focusCamera.enabled = false;
        BtMainCamera.gameObject.SetActive(false);
        noticeSign.SetActive(true);
    }
}
