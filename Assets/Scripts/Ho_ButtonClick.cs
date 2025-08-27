using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Ho_ButtonClick : MonoBehaviour
{
    private Ray ray;
    private RaycastHit hit;

    // ��ư �̸��� �� �̸��� ������ Dictionary
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

    // ī�޶� ȸ���� ����
    private static Quaternion savedRotation = Quaternion.identity;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked; // ���콺�� ȭ�� �߾ӿ� ����

        // �� �ε� �̺�Ʈ�� ȸ�� ���� �Լ� ����
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    void Update()
    {
        ButtonSee(); // ��ư Ŭ�� ���� �޼��� ȣ��
    }

    void ButtonSee()
    {
        ray = Camera.main.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
        float rayRadius = 1f;    // ��ư ���� �ݰ�
        float rayDistance = 100f; // �ִ� �Ÿ� ����

        if (Physics.SphereCast(ray, rayRadius, out hit, rayDistance))
        {
            if (hit.collider.CompareTag("Button"))
            {
                UnityEngine.Debug.Log($"Ray hit: {hit.collider.gameObject.name}");
                string name = hit.collider.gameObject.name;

                if (Input.GetMouseButtonDown(0)) // ���� ���콺 ��ư Ŭ�� ����
                {
                    if (buttonSceneMapping.TryGetValue(name, out string sceneName))
                    {
                        UnityEngine.Debug.Log($"{name} Ŭ����, {sceneName}�� �̵�"); // ��ư Ŭ�� �α� ���
                        SaveCameraRotation(); // ī�޶� ȸ���� ����
                        SceneManager.LoadScene(sceneName); // �ش� ������ ��ȯ
                    }
                    else
                    {
                        UnityEngine.Debug.Log("Unknown Button Clicked"); // �˷����� ���� ��ư �α� ���
                    }
                }
            }
        }
    }

    void SaveCameraRotation()
    {
        savedRotation = Camera.main.transform.rotation; // ���� ī�޶� ȸ���� ����
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        // �� �ε� �� ����� ȸ������ ����
        if (savedRotation != Quaternion.identity)
        {
            Camera.main.transform.rotation = savedRotation;
        }
    }

    void OnDestroy()
    {
        // �� �ε� �̺�Ʈ���� �Լ� �и�
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }
}
