using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class ScriptOutput : MonoBehaviour
{
    public Button setA;
    public Button setB;

    // 배열 변수 선언
    public string[] texts;
    public int[] facialExpressions;
    public string[] names;

    public Text nameText;
    public Text scripts;

    private int count=0;

    private void Start()
    {
        setA.gameObject.SetActive(false);
        setB.gameObject.SetActive(false);
    }   

    private void Update()
    {
        // 마우스 클릭 감지
        if (Input.GetMouseButtonDown(0)|| Input.GetKeyDown("space"))
        {
            HandleMouseClick();
        }
    }

    private void HandleMouseClick()
    {
        if(count< texts.Length)
        {
            nameText.text = names[count];
            scripts.text = texts[count];

            //state 패턴 적용해야함
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
