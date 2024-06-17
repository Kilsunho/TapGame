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
            Destroy(gameObject); // 중복된 GameManager 인스턴스 방지
        }
    }

    // UI 업데이트
    public void UpdateMoneyUI(TMP_Text moneyText, int money)
    {
        moneyText.text = money.ToString();
    }

    // 보스를 클리어하여 다음 스테이지로 이동
    public void ClearBoss()
    {
        Debug.Log("보스를 클리어했습니다. 다음 스테이지로 이동합니다.");
        // 다음 스테이지 로직 추가
    }
}


