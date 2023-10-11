using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class GameController : MonoBehaviour
{
    private GameObject leftRound;
    private GameObject rightRound;
    private Button leftPencil;
    private Button rightPencil;
    private Button originPencil;
    private int leftCount;
    private int rightCount;
    public Button BtNextScene;
    public Button BtFullScene;
    // Start is called before the first frame update
    void Start()
    {
        leftRound = transform.Find("left").gameObject;
        rightRound = transform.Find("right").gameObject;
        leftPencil = transform.Find("PencilLeft").GetComponent<Button>();
        rightPencil = transform.Find("PencilRight").GetComponent<Button>();
        originPencil = transform.Find("pencil").GetComponent<Button>();
        leftPencil.gameObject.SetActive(false);
        rightPencil.gameObject.SetActive(false);
        originPencil.gameObject.SetActive(true);
        originPencil.onClick.AddListener(onClickOriginPencil);
        leftPencil.onClick.AddListener(onClickLeftPencil);
        rightPencil.onClick.AddListener(onClickRightPencil);
        leftCount = 0;
        rightCount = 0;
        BtNextScene.gameObject.SetActive(false);
        BtFullScene.onClick.AddListener(BackToFullScene);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void onClickOriginPencil()
    {
        leftPencil.gameObject.SetActive(true);
        rightPencil.gameObject.SetActive(false);
        originPencil.gameObject.SetActive(false);
    }
    private void onClickLeftPencil()
    {
        if (leftCount < 5)
        {
            leftRound.gameObject.transform.Rotate(new Vector3(0,0,60));
            leftCount++;
        }
        else
        {
            leftRound.gameObject.transform.Rotate(new Vector3(0, 0, 60));
            leftCount = 0;
            leftPencil.gameObject.SetActive(false);
            rightPencil.gameObject.SetActive(true);
        }
        

    }
    private void onClickRightPencil()
    {
        if (rightCount < 5)
        {
            rightCount++;
            rightRound.gameObject.transform.Rotate(new Vector3(0, 0, 60));
        }
        else
        {
            BtNextScene.gameObject.SetActive(true);
            rightRound.gameObject.transform.Rotate(new Vector3(0, 0, 60));
            rightCount = 0;
            rightPencil.gameObject.SetActive(false);
            originPencil.gameObject.SetActive(true);
        }
    }
    private void BackToFullScene()
    {
        transform.gameObject.SetActive(false);
    }
}
