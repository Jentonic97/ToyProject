using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class ScriptOutput : MonoBehaviour
{
    public string[] textArray;

    //scriptArray�� �ٲ���� 
    
    public Text legacyText;
    public Button myButton;
    public Button myButton1;

    private int currentIndex = 0;
    private float textChangeInterval = 2f; // �ؽ�Ʈ ���� ���� (��)

    private void Start()
    {
        myButton.gameObject.SetActive(false);
        myButton1.gameObject.SetActive(false);

        StartCoroutine(UpdateTextWithDelay());
    }

    private IEnumerator UpdateTextWithDelay()
    {
    }
}
