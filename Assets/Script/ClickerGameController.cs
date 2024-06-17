using UnityEngine;
using System.Collections;

public class ClickerGameController : MonoBehaviour
{
    private int money = 0; // 현재 돈
    private int clickMoney = 1; // 클릭으로 얻는 돈
    private int autoMoneyPerSecond = 5; // 초당 자동으로 얻는 돈
    private bool autoClickActive = false; // 자동 클릭 활성화 여부
    private float upgradeCost = 10f; // 초기 업그레이드 비용
    private float upgradeCostMultiplier = 1.5f; // 강화 비용 증가 배수
    private float clickMoneyMultiplier = 2f; // 클릭 돈 증가 배수

    void Start()
    {
        UIManager.instance.UpdateMoneyUI(money); // 초기화 시 UI 업데이트
        UIManager.instance.UpdateUpgradeCostUI(upgradeCost); // 초기화 시 업그레이드 비용 UI 업데이트
        StartCoroutine(AutoClickCoroutine());
    }

    IEnumerator AutoClickCoroutine()
    {
        while (true)
        {
            yield return new WaitForSeconds(1f);
            if (autoClickActive)
            {
                money += autoMoneyPerSecond;
                UIManager.instance.UpdateMoneyUI(money); // 자동 클릭 시 UI 업데이트
            }
        }
    }

    public void Click()
    {
        money += clickMoney;
        UIManager.instance.UpdateMoneyUI(money); // 클릭 시 UI 업데이트
    }

    public void UpgradeClickDamage()
    {
        if (money >= upgradeCost)
        {
            clickMoney = (int)(clickMoney * clickMoneyMultiplier); // 클릭 공격력 증가
            money -= (int)upgradeCost; // 비용 차감
            upgradeCost *= upgradeCostMultiplier; // 다음 강화 비용 증가
            UIManager.instance.UpdateMoneyUI(money); // UI 업데이트
            UIManager.instance.UpdateUpgradeCostUI(upgradeCost); // 업그레이드 비용 UI 업데이트

            // 업그레이드 비용이 부족하면 버튼 비활성화
            if (money < upgradeCost)
            {
                UIManager.instance.SetButtonInteractable(UIManager.instance.upgradeButton, false); // 버튼을 비활성화하고 흐리게 처리
            }
        }
    }

    public void ToggleAutoClick()
    {
        autoClickActive = !autoClickActive;
    }
}
