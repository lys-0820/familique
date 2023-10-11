using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Notice : MonoBehaviour
{
    public Camera mainCamera; // 摄像机
    public Camera noticeCamera; // 摄像机
    public Animator animator;
    public GameObject musicPlayer;
    public GameObject plant;
    public GameObject car;
    public RawImage img;
    public RawImage largeImg;
    //public Text typeWriter;
    public Text text;
    private string nowStr;
    private string nowWord;
    private GameObject nowObj;
    private bool IsRotate;
    private Transform target;
    public float zoomLevel = 50f;
    public float zoomSpeed = 5f;
    public float rotationSpeed = 5f;
    public GameObject GamePanel;
    public GameObject noticeSign;
    // Start is called before the first frame update
    void Start()
    {
        GamePanel.SetActive(false);
        //text = img.GetComponentInChildren<Text>();
        img.gameObject.SetActive(false);
        largeImg.gameObject.SetActive(false);
        Camera.main.enabled = false; // 将当前主摄像机禁用
        mainCamera.enabled = true;
        IsRotate = false;
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
            //transform mouse position to ray object
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            //determine colliding object
            if (Physics.Raycast(ray, out hit))
            {
                switch (hit.collider.gameObject.name)
                {
                    case "musicPlayer":
                        img.gameObject.SetActive(true);
                        nowWord = "It is mother's favorite song...";
                        text.text = nowWord;
                        if (nowStr != null)
                        {
                            animator.SetBool(nowStr, false);
                        }
                        nowStr = "musicPlayer";
                        nowObj = musicPlayer;
                        animator.SetBool(nowStr, true);
                        break;
                    case "plant":
                        img.gameObject.SetActive(true);
                        nowWord = "This tiger orchid looks beautiful.";
                        text.text = nowWord;
                        if (nowStr != null)
                        {
                            animator.SetBool(nowStr, false);
                        }
                        nowStr = "plant";
                        nowObj = plant;
                        animator.SetBool(nowStr, true);
                        break;
                    case "car":
                        img.gameObject.SetActive(true);
                        nowWord = "It looks too old that the wheels don't work so good.";
                        text.text = nowWord;
                        if (nowStr != null)
                        {
                            animator.SetBool(nowStr, false);
                        }
                        nowStr = "car";
                        nowObj = car;
                        animator.SetBool(nowStr, true);
                        break;
                    case "RockingHorse":
                        //noticeSign.SetActive(false);
                        GamePanel.SetActive(true);
                        break;
                }

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
