using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class SceneController : MonoBehaviour
{
    public Animator animator;
    public GameObject startPanel;
    private void Start()
    {
        //if (startPanel != null)
        //    startPanel.SetActive(false);
    }
    public void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
    public void ToNextScene(string sceneName)
    {
        SceneLoader._instance.LoadScene(sceneName);
    }
    public void StartScene()
    {
        startPanel.SetActive(true);
        StartCoroutine(PlayAndExecuteEvent());
        
    }
    private IEnumerator PlayAndExecuteEvent()
    {
        // 播放动画
        animator.SetTrigger("beginAnim");

        // 等待动画播放完成
        while (animator.GetCurrentAnimatorStateInfo(0).normalizedTime < 1)
        {
            yield return null;
        }

        // 动画播放完成后执行
        SceneManager.LoadScene("musicRoom");
    }
}