using UnityEngine;
using UnityEngine.Video;

public class Transition : MonoBehaviour
{
    public VideoPlayer videoPlayer;
    private bool IsOver;
    [SerializeField]

    private void Awake() {
        //videoPlayer.gameObject.SetActive(false);
        // 获取Video Player组件
        //videoPlayer = GetComponent<VideoPlayer>();

        // 添加事件监听器，以在循环点达到时触发
        videoPlayer.loopPointReached += OnVideoPlaybackFinished;
        // 设置视频文件的路径
        //videoPlayer.url = "Resources/videos/scene1.mp4";

        
        IsOver = false;
    }

    /// <summary>
    /// 播放转场前的动画
    /// </summary>
    public void StartTrans(){
        videoPlayer.gameObject.SetActive(true);
        // 准备视频
        videoPlayer.Prepare();
        videoPlayer.Play();
        //animator.SetTrigger("Start");
    }

    /// <summary>
    /// 播放转场后的动画
    /// </summary>
    public void EndTrans(){
        //animator.SetTrigger("End");
    }

    /// <summary>
    /// 当前动画是否播放完成
    /// </summary>
    /// <returns></returns>
    public bool IsAnimationDone(){
        //if(animator.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1)
        //    return true;
        //else 
        //    return false;
        if (IsOver)
        {
            IsOver = false;
            videoPlayer.gameObject.SetActive(false);
            return true;
        }
        else
        {
            return false;
        }
    }
    

    void OnVideoPlaybackFinished(VideoPlayer vp)
    {
        // 视频播放完成时触发的操作
        Debug.Log("视频播放完成！");
        IsOver = true;
    }
}
