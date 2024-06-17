using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
    public static UIManager instance;

    public TMP_Text moneyText; // 돈을 표시할 TMP 텍스트
    public TMP_Text upgradeCostText; // 업그레이드 비용을 표시할 TMP 텍스트
    public GameObject upgradeButton; // 강화 버튼

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void UpdateMoneyUI(int money)
    {
        moneyText.text = money.ToString(); // 돈을 UI에 업데이트
    }

    public void UpdateUpgradeCostUI(float upgradeCost)
    {
        upgradeCostText.text = "Upgrade Cost: " + upgradeCost.ToString("F0"); // 업그레이드 비용 업데이트
    }

    public void SetButtonInteractable(GameObject button, bool interactable)
    {
        // 버튼의 상호작용 가능 여부 설정
        button.GetComponent<UnityEngine.UI.Button>().interactable = interactable;

        // 버튼 비활성화 시 투명도를 조절하여 흐리게 표현
        CanvasGroup canvasGroup = button.GetComponent<CanvasGroup>();
        if (canvasGroup == null)
        {
            canvasGroup = button.AddComponent<CanvasGroup>();
        }
        canvasGroup.alpha = interactable ? 1f : 0.5f; // 활성화일 때는 투명도 1, 비활성화일 때는 투명도 0.5
    }
}
