using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class btnScenesChange : MonoBehaviour
{
    // �������� �̵��� ���� �̸��� �����մϴ�.
    public string nextSceneName;
    public Button changeBtn;

    void Start()
    {
        Button btn = changeBtn.GetComponent<Button>();
        btn.onClick.AddListener(TaskOnClick);
    }

    void TaskOnClick()
    {
        if (!string.IsNullOrEmpty(nextSceneName))
        {
            // Check if the scene exists
            if (SceneManager.GetSceneByName(nextSceneName) != null)
            {
                // Log and load the scene
                Debug.Log("�� ��ȯ");
                SceneManager.LoadScene(nextSceneName);
            }
            else
            {
                // Log an error if the scene doesn't exist
                Debug.LogError("���� �������� �ʽ��ϴ�: " + nextSceneName);
            }
        }
        else
        {
            // Log an error if nextSceneName is null or empty
            Debug.LogError("���� ���� �̸��� �������� �ʾҽ��ϴ�.");
        }
    }

}
