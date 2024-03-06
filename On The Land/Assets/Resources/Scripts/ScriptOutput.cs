using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ScriptOutput : MonoBehaviour
{
    public Button setA;
    public Button setB;

    public Button logBtn;
    public Button backBtn;
    public ScrollRect scrollRect;

    public Button autoBtn;
    public Text autoBtnText; // �ڵ����� ��ư�� �ؽ�Ʈ�� �����ϱ� ���� ���� �߰�

    public GameObject loadScreen;

    // �迭 ���� ����
    public string[] texts;
    public int[] facialExpressions;
    public string[] names;

    public Text nameText;
    public Text scripts;

    public bool isButtonClicked = false;

    public int count=0;

    //�ڵ�����
    private void autoBtnClick()
    {
        isButtonClicked = !isButtonClicked; // �ڵ� ���� ���¸� ����մϴ�.

        if (isButtonClicked)
        {
            autoBtnText.text = "�Ͻ�����"; // ��ư �ؽ�Ʈ�� "�Ͻ�����"�� �����մϴ�.
            InvokeRepeating(nameof(HandleMouseClick), 0f, 1f);
        }
        else
        {
            autoBtnText.text = "�ڵ�����"; // ��ư �ؽ�Ʈ�� "�ڵ�����"���� �����մϴ�.
            CancelInvoke(nameof(HandleMouseClick));
        }
    }


    private void Start()
    {
        setA.gameObject.SetActive(false);
        setB.gameObject.SetActive(false);

        autoBtn.onClick.AddListener(autoBtnClick);
    }

    //Ŭ�� �� ���� ����
    private void Update()
    {
        if (!scrollRect.gameObject.activeSelf && !backBtn.gameObject.activeSelf 
            && logBtn.gameObject.activeSelf && !isButtonClicked
            && !loadScreen.gameObject.activeSelf)
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
            setA.gameObject.SetActive(true);
            setB.gameObject.SetActive(true);
        }
    }

}
