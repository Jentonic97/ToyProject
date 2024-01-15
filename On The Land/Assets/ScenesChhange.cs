using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScenesChhange : MonoBehaviour
{
    // �������� �̵��� ���� �̸��� �����մϴ�.
    public string nextSceneName;

    public void OnButtonClick()
    {
        // Check if nextSceneName is not null or empty
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
