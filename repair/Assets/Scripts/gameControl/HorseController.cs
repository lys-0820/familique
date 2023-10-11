using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class HorseController : MonoBehaviour
{
    public List<GameObject> dragFragments;
    private bool IsGameFinished = true;
    public Button BtNextScene;
    public Button BtFullScene;
    // Start is called before the first frame update
    void Start()
    {
        BtNextScene.gameObject.SetActive(false);
        BtFullScene.onClick.AddListener(BackToFullScene);
    }

    // Update is called once per frame
    void Update()
    {
        IsGameFinished = true;
        foreach(GameObject obj in dragFragments)
        {
            if (obj.activeSelf)
            {
                IsGameFinished = false;
            }
        }
        if (IsGameFinished)
        {
            BtNextScene.gameObject.SetActive(true);
        }
    }
    private void BackToFullScene()
    {
        transform.gameObject.SetActive(false);
    }
}
