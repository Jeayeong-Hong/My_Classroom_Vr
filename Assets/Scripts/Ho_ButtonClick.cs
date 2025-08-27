using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Ho_ButtonClick : MonoBehaviour
{
    private Ray ray;
    private RaycastHit hit;

    // 버튼 이름과 씬 이름을 매핑할 Dictionary
    private Dictionary<string, string> buttonSceneMapping = new Dictionary<string, string>()
    {
        { "401F_Btn", "401Front" },
        { "401BC_Btn", "401Back" },
        { "402BC_Btn", "402Back" },
        { "402M_Btn", "402Middle" },
        { "402F_Btn", "402Front" },
        { "403BC_Btn", "403Back" },
        { "403M_Btn", "403Middle" },
        { "403F_Btn", "403Front" },
        { "408F_Btn", "408Front" },
        { "408BC_Btn", "408Back" },
        { "back_pass0_Btn", "back_pass0" },
        { "back_pass1_Btn", "back_pass1" },
        { "back_pass2_Btn", "back_pass2" },
        { "back_pass3_Btn", "back_pass3" },
        { "pass_Btn", "pass" },
        { "pass1_Btn", "pass1" },
        { "pass2_Btn", "pass2" },
        { "pass3_Btn", "pass3" },
        { "pass4_Btn", "pass4" },
        { "pass1_1_Btn", "pass1_1" },
        { "class_Btn", "class" }
    };

    // 카메라 회전값 저장
    private static Quaternion savedRotation = Quaternion.identity;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked; // 마우스를 화면 중앙에 고정

        // 씬 로드 이벤트에 회전 적용 함수 연결
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    void Update()
    {
        ButtonSee(); // 버튼 클릭 감지 메서드 호출
    }

    void ButtonSee()
    {
        ray = Camera.main.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
        float rayRadius = 1f;    // 버튼 감지 반경
        float rayDistance = 100f; // 최대 거리 설정

        if (Physics.SphereCast(ray, rayRadius, out hit, rayDistance))
        {
            if (hit.collider.CompareTag("Button"))
            {
                UnityEngine.Debug.Log($"Ray hit: {hit.collider.gameObject.name}");
                string name = hit.collider.gameObject.name;

                if (Input.GetMouseButtonDown(0)) // 왼쪽 마우스 버튼 클릭 감지
                {
                    if (buttonSceneMapping.TryGetValue(name, out string sceneName))
                    {
                        UnityEngine.Debug.Log($"{name} 클릭됨, {sceneName}로 이동"); // 버튼 클릭 로그 출력
                        SaveCameraRotation(); // 카메라 회전값 저장
                        SceneManager.LoadScene(sceneName); // 해당 씬으로 전환
                    }
                    else
                    {
                        UnityEngine.Debug.Log("Unknown Button Clicked"); // 알려지지 않은 버튼 로그 출력
                    }
                }
            }
        }
    }

    void SaveCameraRotation()
    {
        savedRotation = Camera.main.transform.rotation; // 현재 카메라 회전값 저장
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        // 씬 로드 후 저장된 회전값을 적용
        if (savedRotation != Quaternion.identity)
        {
            Camera.main.transform.rotation = savedRotation;
        }
    }

    void OnDestroy()
    {
        // 씬 로드 이벤트에서 함수 분리
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }
}
