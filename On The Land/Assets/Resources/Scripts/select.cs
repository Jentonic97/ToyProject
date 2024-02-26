using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.IO;

public class select : MonoBehaviour
{
    public GameObject creat;	// �÷��̾� �г��� �Է�UI
    public Text[] slotText;		// ���Թ�ư �Ʒ��� �����ϴ� Text��
    public Text newPlayerData;	// ���� �Էµ� �÷��̾��� ���� �����

    bool[] saveFile = new bool[4];	// ���̺����� �������� ����
    ScriptOutput scriptOutput = new ScriptOutput();

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

    //public void slot(int number)	// ������ ��� ����
    //{
    //    dataManager.instance.nowSlot = number;	// ������ ��ȣ�� ���Թ�ȣ�� �Է���.
    //
    //    if (saveFile[number])	// bool �迭���� ���� ���Թ�ȣ�� true��� = ������ �����Ѵٴ� ��
    //    {
    //        dataManager.instance.loadData();	// �����͸� �ε��ϰ�
    //        GoGame();	// ���Ӿ����� �̵�
    //    }
    //    else	// bool �迭���� ���� ���Թ�ȣ�� false��� �����Ͱ� ���ٴ� ��
    //    {
    //        Creat();	// �÷��̾� �г��� �Է� UI Ȱ��ȭ
    //    }
    //}

    //public void Creat()	// �÷��̾� �г��� �Է� UI�� Ȱ��ȭ�ϴ� �޼ҵ�
    //{
    //    creat.gameObject.SetActive(true);
    //}

    public void GoGame()	// ���Ӿ����� �̵�
    {
        if (!saveFile[dataManager.instance.nowSlot])	// ���� ���Թ�ȣ�� �����Ͱ� ���ٸ�
        {
            //dataManager.instance.nowData.slotName = newPlayerData.text; // �Է��� �̸��� �����ؿ�
            dataManager.instance.nowData.currentSceneNum = scriptOutput.currentStorySceneNumber;
            dataManager.instance.saveData(); // ���� ������ ������.
        }
        SceneManager.LoadScene(1); // ���Ӿ����� �̵�
    }
}