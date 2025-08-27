using System.Diagnostics;
using UnityEngine;
using UnityEngine.SceneManagement;

public class mainClick : MonoBehaviour
{
    // 이 메서드를 클릭 이벤트로 연결합니다.
    public void LoadPassScene()
    {
        SceneManager.LoadScene("Pass"); // Pass 씬 이름에 맞춰 변경하세요.
        UnityEngine.Debug.Log("Pass 씬으로 이동");
    }
}
