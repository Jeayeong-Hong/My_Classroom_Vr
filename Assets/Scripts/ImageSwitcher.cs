using UnityEngine;           // UnityEngine ���ӽ����̽� ����
using UnityEngine.UI;        // UnityEngine.UI ���ӽ����̽� ����

public class ImageSwitcher : MonoBehaviour
{
    public UnityEngine.UI.Image displayImage; // �̹����� ǥ���� UI Image
    public Sprite javaImage;   // Java �̹���
    public Sprite cImage;      // C �̹���

    private bool isJava = true; // ���� Java �̹����� ǥ�õǰ� �ִ��� ����

    void Start()
    {
        if (displayImage != null && javaImage != null)
        {
            displayImage.sprite = javaImage; // �ʱ� �̹����� Java�� ����
        }
        else
        {
            UnityEngine.Debug.LogError("Display Image or Java Image is not assigned."); // UnityEngine.Debug.LogError ���
        }
    }

    void OnMouseDown()
    {
        if (displayImage != null)
        {
            // Ŭ�� �� �̹��� ��ȯ
            isJava = !isJava;
            displayImage.sprite = isJava ? javaImage : cImage;
        }
    }
}
