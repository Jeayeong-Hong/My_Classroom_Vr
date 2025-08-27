using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonClick : MonoBehaviour
{
    private Ray ray;
    private RaycastHit hit; //ray의 충돌정보를 저장하는 구조체
    
    void Start()
    {
        
    }

    
    void Update()
    {
        ButtonSee();
    }
    
    void ButtonSee()
    {
        ray = Camera.main.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0)); //화면 정중앙에서 레이저 쏘는 ray 생성    
        
        // if (Physics.Raycast(ray, out hit))
        // {
        //     if (hit.collider.gameObject.tag == "Button")
        //     {
        //         Debug.Log("버튼");

        //         string name = this.gameObject.name;
                
            //     switch(name)
            //     {
            //         case("401BtF_Btn"):
                    
            //             Debug.Log("TestSuccess");
            //             break;
            //         default:
            //             Debug.Log("Fault");
            //             break;
            //     }
            // }

        // }
        
        if(Physics.Raycast(ray, out hit))
        {

            string name = hit.collider.gameObject.name;

            if (Input.GetMouseButtonDown(0))
            {
                switch (name)
                {
                    case ("401BtF_Btn"):

                        Debug.Log("TestSuccess");
                        SceneManager.LoadScene("401Front");
                        break;

                    default:

                        Debug.Log("Not Clicked Yet");
                        break;
                }
            }
        }
    }
}
