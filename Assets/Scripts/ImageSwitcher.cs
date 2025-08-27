using UnityEngine;           // UnityEngine 네임스페이스 포함
using UnityEngine.UI;        // UnityEngine.UI 네임스페이스 포함

public class ImageSwitcher : MonoBehaviour
{
    public UnityEngine.UI.Image displayImage; // 이미지를 표시할 UI Image
    public Sprite javaImage;   // Java 이미지
    public Sprite cImage;      // C 이미지

    private bool isJava = true; // 현재 Java 이미지가 표시되고 있는지 여부

    void Start()
    {
        if (displayImage != null && javaImage != null)
        {
            displayImage.sprite = javaImage; // 초기 이미지를 Java로 설정
        }
        else
        {
            UnityEngine.Debug.LogError("Display Image or Java Image is not assigned."); // UnityEngine.Debug.LogError 사용
        }
    }

    void OnMouseDown()
    {
        if (displayImage != null)
        {
            // 클릭 시 이미지 전환
            isJava = !isJava;
            displayImage.sprite = isJava ? javaImage : cImage;
        }
    }
}
