using UnityEngine;
using UnityEngine.UI;

// State �������̽�
public interface IScriptOutputState
{
    int HandleState(string name, Image img);
}

public class StateNomal : IScriptOutputState
{
    private string goldGirlPath = "Sprites/�ݹ߿�ĳ/nomal";
    private string blueGirlPath = "Sprites/û�߿�ĳ/nomal";

    public int HandleState(string name, Image img)
    {
        Sprite spriteToLoad = null;

        switch (name)
        {
            case "�ݹ߿�ĳ":
                spriteToLoad = Resources.Load<Sprite>(goldGirlPath);
                break;
            case "û�߿�ĳ":
                spriteToLoad = Resources.Load<Sprite>(blueGirlPath);
                break;
            default:
                break;
        }

        if (spriteToLoad != null)
        {
            img.sprite = spriteToLoad;
            return 1; // ó�� ����
        }
        else
        {
            Debug.LogError("Failed to load sprite for nomal state: " + name);
            return -1; // ó�� ����
        }
    }
}
public class StateSad : IScriptOutputState
{
    private string goldGirlPath = "Sprites/�ݹ߿�ĳ/sad";
    //û�� ��ĳ�� sad ǥ���� ��� �ӽ÷� �������� �־��
    private string blueGirlPath = "Sprites/û�߿�ĳ/sharpe";

    public int HandleState(string name, Image img)
    {
        Sprite spriteToLoad = null;

        switch (name)
        {
            case "�ݹ߿�ĳ":
                spriteToLoad = Resources.Load<Sprite>(goldGirlPath);
                break;
            case "û�߿�ĳ":
                spriteToLoad = Resources.Load<Sprite>(blueGirlPath);
                break;
            default:
                break;
        }

        if (spriteToLoad != null)
        {
            img.sprite = spriteToLoad;
            return 1; // ó�� ����
        }
        else
        {
            Debug.LogError("Failed to load sprite for state: " + name);
            return -1; // ó�� ����
        }
    }
}

public class StateSmile : IScriptOutputState
{
    private string goldGirlPath = "Sprites/�ݹ߿�ĳ/smile";
    private string blueGirlPath = "Sprites/û�߿�ĳ/smile";

    public int HandleState(string name, Image img)
    {
        Sprite spriteToLoad = null;

        switch (name)
        {
            case "�ݹ߿�ĳ":
                spriteToLoad = Resources.Load<Sprite>(goldGirlPath);
                break;
            case "û�߿�ĳ":
                spriteToLoad = Resources.Load<Sprite>(blueGirlPath);
                break;
            default:
                break;
        }

        if (spriteToLoad != null)
        {
            img.sprite = spriteToLoad;
            return 1; // ó�� ����
        }
        else
        {
            Debug.LogError("Failed to load sprite for state: " + name);
            return -1; // ó�� ����
        }
    }
}
public class StateShy : IScriptOutputState
{
    private string goldGirlPath = "Sprites/�ݹ߿�ĳ/shy";
    private string blueGirlPath = "Sprites/û�߿�ĳ/shy";

    public int HandleState(string name, Image img)
    {
        Sprite spriteToLoad = null;

        switch (name)
        {
            case "�ݹ߿�ĳ":
                spriteToLoad = Resources.Load<Sprite>(goldGirlPath);
                break;
            case "û�߿�ĳ":
                spriteToLoad = Resources.Load<Sprite>(blueGirlPath);
                break;
            default:
                break;
        }

        if (spriteToLoad != null)
        {
            img.sprite = spriteToLoad;
            return 1; // ó�� ����
        }
        else
        {
            Debug.LogError("Failed to load sprite for state: " + name);
            return -1; // ó�� ����
        }
    }
}

public class StateAngry : IScriptOutputState
{
    private string goldGirlPath = "Sprites/�ݹ߿�ĳ/angry";
    private string blueGirlPath = "Sprites/û�߿�ĳ/angry";

    public int HandleState(string name, Image img)
    {
        Sprite spriteToLoad = null;

        switch (name)
        {
            case "�ݹ߿�ĳ":
                spriteToLoad = Resources.Load<Sprite>(goldGirlPath);
                break;
            case "û�߿�ĳ":
                spriteToLoad = Resources.Load<Sprite>(blueGirlPath);
                break;
            default:
                break;
        }

        if (spriteToLoad != null)
        {
            img.sprite = spriteToLoad;
            return 1; // ó�� ����
        }
        else
        {
            Debug.LogError("Failed to load sprite for state: " + name);
            return -1; // ó�� ����
        }
    }
}

public class ScriptOutputState : MonoBehaviour
{
    
    public Image img;

    private IScriptOutputState currentState;

    void Start()
    {
        // �ʱ� ���� ����
        currentState = new StateNomal();
    }

    public int SOState(int facialExpression, string name)
    {
        switch (facialExpression)
        {
            case 0:
                currentState = new StateNomal();
                currentState.HandleState(name, img);
                Debug.Log("nomal");
                break;
            case 1:
                currentState = new StateAngry();
                currentState.HandleState(name, img);
                Debug.Log("angry");
                break;
            case 2:
                currentState = new StateSad();
                currentState.HandleState(name, img);
                Debug.Log("sad");
                break;
            case 3:
                currentState = new StateShy();
                currentState.HandleState(name, img);
                Debug.Log("shy");
                break;
            case 4:
                currentState = new StateSmile();
                currentState.HandleState(name, img);
                Debug.Log("smile");
                break;
            default:
                Debug.LogError("Invalid facial expression value");
                break;
        }
        return 0;
    }
}
