using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.IO;

public class select : MonoBehaviour
{
    //public GameObject creat;	
    public Text[] slotText;		// ���Թ�ư �Ʒ��� �����ϴ� Text��
    public Text newPlayerData;	// ���� �Էµ� �÷��̾��� ���� �����

    bool[] saveFile = new bool[4];	// ���̺����� �������� ����
    public btnScenesChange btnScenesChange;
    public noneBtnScriptOutput noneBtnScriptOutput;

    void Start()
    {
        
        // ���Ժ��� ����� �����Ͱ� �����ϴ��� �Ǵ�.
        for (int i = 0; i < 4; i++)
        {
            if (File.Exists(dataManager.instance.path + $"{i}"))	// �����Ͱ� �ִ� ���
            {
                saveFile[i] = true;			// �ش� ���� ��ȣ�� bool�迭 true�� ��ȯ
                
                dataManager.instance.nowSlot = i;	// ������ ���� ��ȣ ����
                dataManager.instance.loadData();	// �ش� ���� ������ �ҷ���
                slotText[i].text = dataManager.instance.nowData.currentSceneNum;	// ��ư�� ����� �� �ѹ� ǥ��
            }
            else	// �����Ͱ� ���� ���
            {
                slotText[i].text = "�������";
            }
        }
        // �ҷ��� �����͸� �ʱ�ȭ��Ŵ.(��ư�� �г����� ǥ���ϱ������̾��� ����)
        dataManager.instance.DataClear();
    }

    public void slot(int number)	// ������ ��� ����
    {
        dataManager.instance.nowSlot = number;	// ������ ��ȣ�� ���Թ�ȣ�� �Է���.
    
        if (saveFile[number])	// bool �迭���� ���� ���Թ�ȣ�� true��� = ������ �����Ѵٴ� ��
        {
            dataManager.instance.loadData();	// �����͸� �ε��ϰ�
            GoGame();	// ���Ӿ����� �̵�
        }
        else	// bool �迭���� ���� ���Թ�ȣ�� false��� �����Ͱ� ���ٴ� ��
        {
            Creat();	
        }
    }

    public void Creat()
    {
        Debug.Log("Activate Creat() ");
    }

    public void GoGame()
    {
        string currentStorySceneNumber = ""; // ������ ���� �ۿ��� ����

        if (!saveFile[dataManager.instance.nowSlot]) // �����Ͱ� ���ٸ�
        {
            // ��ư�� �ִ��� Ȯ���ϰ� �� �ѹ� ����
            GameObject[] gameObjects = FindObjectsOfType<GameObject>();
            foreach (GameObject go in gameObjects)
            {
                Button button = go.GetComponent<Button>();
                if (button != null)
                {
                    currentStorySceneNumber = btnScenesChange.nextSceneName;
                }
                else
                {
                    currentStorySceneNumber = noneBtnScriptOutput.nextSceneName;
                }
            }

            // ���� �� ���� ����
            dataManager.instance.nowData.currentSceneNum = currentStorySceneNumber;
            dataManager.instance.nowData.currentTime = DateTime.Now.ToString();

            // ������ ����
            dataManager.instance.saveData();
        }

        // ���� ������ �̵�
        SceneManager.LoadScene(1);
    }

}