using System.Diagnostics;
using UnityEngine;
using UnityEngine.SceneManagement;

public class mainClick : MonoBehaviour
{
    // �� �޼��带 Ŭ�� �̺�Ʈ�� �����մϴ�.
    public void LoadPassScene()
    {
        SceneManager.LoadScene("Pass"); // Pass �� �̸��� ���� �����ϼ���.
        UnityEngine.Debug.Log("Pass ������ �̵�");
    }
}
