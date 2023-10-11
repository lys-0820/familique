using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class NoticeMusic : MonoBehaviour
{
    public Camera mainCamera; // 摄像机
    public Camera noticeCamera; // 摄像机
    public Animator animator;
    public GameObject cassette;
    public GameObject midi;
    public GameObject reward;
    public RawImage img;
    public RawImage largeImg;
    public Text text;
    private string nowStr;
    public string nowWord;
    private GameObject nowObj;
    private bool IsRotate;
    private Transform target;
    public float zoomLevel = 50f;
    public float zoomSpeed = 5f;
    public float rotationSpeed = 5f;
    public GameObject gamePanel;
    public GameObject noticeSign;
    // Start is called before the first frame update
    void Start()
    {
        img.gameObject.SetActive(false);
        largeImg.gameObject.SetActive(false);
        Camera.main.enabled = false; // 将当前主摄像机禁用
        mainCamera.enabled = true;
        IsRotate = false;
        gamePanel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        // 缩放相机
        float scroll = Input.GetAxis("Mouse ScrollWheel");
        zoomLevel -= scroll * zoomSpeed;
        zoomLevel = Mathf.Clamp(zoomLevel, 10f, 100f);
        noticeCamera.fieldOfView = zoomLevel;

        if (Input.GetMouseButtonDown(0)) // 检测鼠标左键点击
        {
            Debug.Log(Camera.main);
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                switch (hit.collider.gameObject.name)
                {
                    case "cassette":
                        img.gameObject.SetActive(true);
                        nowWord = "The tapes are full of '90s hits.";
                        text.text = nowWord;
                        if (nowStr != null)
                        {
                            animator.SetBool(nowStr, false);
                        }
                        nowStr = "cassette";
                        nowObj = cassette;
                        animator.SetBool(nowStr, true);
                        break;
                    case "midi":
                        img.gameObject.SetActive(true);
                        nowWord = "It looks like it would make good synthesizer music.";
                        text.text = nowWord;
                        if (nowStr != null)
                        {
                            animator.SetBool(nowStr, false);
                        }
                        nowStr = "midi";
                        nowObj = midi;
                        animator.SetBool(nowStr, true);
                        break;
                    case "reward":
                        img.gameObject.SetActive(true);
                        nowWord = "Award certificates for electronic music competitions.";
                        text.text = nowWord;
                        if (nowStr != null)
                        {
                            animator.SetBool(nowStr, false);
                        }
                        nowStr = "reward";
                        nowObj = reward;
                        animator.SetBool(nowStr, true);
                        break;
                    case "Walkman":
                        //noticeSign.SetActive(false);
                        gamePanel.SetActive(true);
                        break;
                }

                // 点击到了物体
                // TODO：更改为Bool，再点击一次返回主场景
                //if (hit.collider.gameObject == gameObject)
                //{
                //    Debug.Log(gameObject);
                //    // 切换到对焦摄像机
                //    animator.SetTrigger("enterAnim");
                //}
            }
        }
        if (IsRotate)
        {
            if (Input.GetMouseButton(1))
            {
               
                float rotationX = Input.GetAxis("Mouse X") * rotationSpeed;
                float rotationY = Input.GetAxis("Mouse Y") * rotationSpeed;
                target = nowObj.transform;
                target.rotation *= Quaternion.Euler(rotationY, rotationX, 0f);
                print("nowObj:" + nowObj.name);
            }
            
        }
    }
    public void LargePerspective()
    {
        print("change to large");
        img.gameObject.SetActive(false);
        largeImg.gameObject.SetActive(true);
        largeImg.gameObject.GetComponentInChildren<TypewriterEffect>().StartEffect(nowWord);
        IsRotate = true;
    }
    public void NormalPerspective()
    {
        print("change to normal");
        img.gameObject.SetActive(true);
        largeImg.gameObject.SetActive(false);
        IsRotate = false;
    }

}
