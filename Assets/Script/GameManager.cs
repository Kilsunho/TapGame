using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject); // �ߺ��� GameManager �ν��Ͻ� ����
        }
    }

    // UI ������Ʈ
    public void UpdateMoneyUI(TMP_Text moneyText, int money)
    {
        moneyText.text = money.ToString();
    }

    // ������ Ŭ�����Ͽ� ���� ���������� �̵�
    public void ClearBoss()
    {
        Debug.Log("������ Ŭ�����߽��ϴ�. ���� ���������� �̵��մϴ�.");
        // ���� �������� ���� �߰�
    }
}


