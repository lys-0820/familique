using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class BlurController : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IDragHandler
{
    public Slider blurSlider;
    public Material blurMaterial;
    public Animator animator;
    public GameObject endScene;
    private bool isSliderPressed = true;
    private void Start()
    {
        // allocate slider and blur material
        if (blurSlider == null || blurMaterial == null)
        {
            Debug.LogError("Slider or Material is not assigned.");
            return;
        }

        // add a listener on slider value
        blurSlider.onValueChanged.AddListener(UpdateBlurAmount);
        blurSlider.value = 0.6F;
        endScene.SetActive(false);
    }

    private void UpdateBlurAmount(float blurValue)
    {
        blurValue = Mathf.Abs(blurValue);
        // map the value of slider to the value of the material
        blurMaterial.SetFloat("_FxBlend", blurValue);
        // judge whether the end position in right
        if (!isSliderPressed)
        {
            if (blurValue < 0.1F)
            {
                Debug.Log("game success!");
                endScene.SetActive(true);
                animator.SetTrigger("End");
            }
        }

    }
    public void OnPointerDown(PointerEventData eventData)
    {
        // 当按下Slider时调用
        Debug.Log("press!");
        //isSliderPressed = true;
    }

    public void OnDrag(PointerEventData eventData)
    {
        // 当按下Slider时调用
        Debug.Log("drag!");
        isSliderPressed = true;
    }
    public void OnPointerUp(PointerEventData eventData)
    {
        // 当松开Slider时调用
        Debug.Log("exit!");
        isSliderPressed = false;
    }
}
