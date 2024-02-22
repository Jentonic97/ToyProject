using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class logOutput : MonoBehaviour
{
    public Button logBtn;
    public Button backBtn;

    public ScrollRect scrollRect;
    public Text logText;

    private ScriptOutput scriptOutput; // ScriptOutput ������Ʈ�� �����ϱ� ���� ���� �߰�

    public int logCount;

    private void Start()
    {
        scrollRect.gameObject.SetActive(false);
        backBtn.gameObject.SetActive(false);
        logBtn.onClick.AddListener(TaskOnClick);

        // ScriptOutput ������Ʈ ��������
        scriptOutput = GetComponent<ScriptOutput>();

        // logText�� null�̸� �ڽ� ������Ʈ���� ã�Ƽ� �Ҵ�
        if (logText == null)
        {
            logText = GetComponentInChildren<Text>();
        }
    }

    void TaskOnClick()
    {
        scrollRect.gameObject.SetActive(true);
        backBtn.gameObject.SetActive(true);
        
        logBtn.gameObject.SetActive(false);
        
        backBtn.onClick.AddListener(Task2OnClick);

        // ScriptOutput ������Ʈ�� �����ϰ� logText�� null�� �ƴ��� Ȯ��
        if (logText != null && scriptOutput != null)
        {
            // count ������ŭ�� ��ҵ��� logText�� �߰�
            for (int i = 0; i < scriptOutput.count; i++)
            {
                logText.text += "\n" + scriptOutput.names[i] + " : " + scriptOutput.texts[i] + "\n";
            }
        }
    }

    void Task2OnClick()
    {
        scrollRect.gameObject.SetActive(false);
        backBtn.gameObject.SetActive(false);
        
        logBtn.gameObject.SetActive(true);
    }
}
