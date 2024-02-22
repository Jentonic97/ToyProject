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

    // �迭 ���� ����
    public string[] texts;
    public int[] facialExpressions;
    public string[] names;

    public Text nameText;
    public Text scripts;

    public int count=0;

    private void Start()
    {

        nameText.text = names[count];
        scripts.text = texts[count];

        //state ���� �����ؾ���
        ScriptOutputState state = GetComponent<ScriptOutputState>();
        state.SOState(facialExpressions[count], names[count]);
        count++;

        setA.gameObject.SetActive(false);
        setB.gameObject.SetActive(false);
    }   

    private void Update()
    {
        if(!(scrollRect.gameObject.activeSelf && backBtn.gameObject.activeSelf && !logBtn.gameObject.activeSelf))
        { 
            // ���콺 Ŭ�� ����
            if (Input.GetMouseButtonDown(0)|| Input.GetKeyDown("space") )// || �α� ��ư�� setVisible���� ������
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
