using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class ScriptOutput : MonoBehaviour
{
    public struct scriptstruct
    {
        public string text;
        public int index;
    }

    public scriptstruct[] scriptArray = new scriptstruct[]
    {
        new scriptstruct { text = "�ؽ�Ʈ1", index = 0 },
        new scriptstruct { text = "�ؽ�Ʈ2", index = 1 },
        // �ʿ信 ���� �� ���� �׸� �߰�
    };

    public Text legacyText;
    public Button myButton;
    public Button myButton1;
    public Image img;

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
        for (; currentIndex < scriptArray.Length; currentIndex++)
        {
            legacyText.text = scriptArray[currentIndex].text;

            // �̹��� ��������Ʈ �Ҵ� (�ּ� �����Ͽ� ���)
            /*
            if (scriptArray[currentIndex].index == 0)
                img.sprite = normal;
            else if (scriptArray[currentIndex].index == 1)
                img.sprite = smile;
            // �� ���� ���� �߰�
            */

            if (currentIndex >= scriptArray.Length)
            {
                myButton.gameObject.SetActive(true);
                myButton1.gameObject.SetActive(true);
            }
            else
            {
                yield return new WaitForSeconds(textChangeInterval);
            }
        }
    }
}
