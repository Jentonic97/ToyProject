using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class noneBtnScriptOutput : MonoBehaviour
{
    // �迭 ���� ����
    public string[] texts;
    public int[] facialExpressions;
    public string[] names;

    public Button logBtn;
    public Button backBtn;
    public ScrollRect scrollRect;

    public Text nameText;
    public Text scripts;

    private int count=0;

    public string nextSceneName;

    private void Update()
    {
        if (!scrollRect.gameObject.activeSelf && !backBtn.gameObject.activeSelf && logBtn.gameObject.activeSelf)
        {
            // ���콺 Ŭ�� ����
            if (Input.GetMouseButtonDown(0) || Input.GetKeyDown("space"))
            {
                HandleMouseClick();
                //Ŭ�� ó��
            }
        }
    }

    private void HandleMouseClick()
    {
        if(count< texts.Length)
        {
            nameText.text = names[count];
            scripts.text = texts[count];

            //state ���� �����ؾ���
            ScriptOutputState state = GetComponent<ScriptOutputState>();
            state.SOState(facialExpressions[count], names[count]);
            count++;
        }
        else
        {
            //Scence Change
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

}
