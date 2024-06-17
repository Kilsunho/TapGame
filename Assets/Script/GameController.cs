using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public int score { get; private set; }
    public int clickValue = 1;
    public int autoClickValue = 1;
    public float autoClickInterval = 1f;
    private int currency;

    private Coroutine autoClickCoroutine;
    private List<Upgrade> upgrades;

    public void Init()
    {
        score = 0;
        currency = 0;
        upgrades = new List<Upgrade>();
        LoadUpgrades(); // 업그레이드 초기화
        StartAutoClick();
    }

    void LoadUpgrades()
    {
        // 예시: 업그레이드 초기화
        upgrades.Add(new Upgrade { name = "Click Upgrade 1", cost = 10, type = 1, multiplier = 1.5f });
        upgrades.Add(new Upgrade { name = "Auto Click Upgrade 1", cost = 20, type = 2, multiplier = 2f });
    }

    public void Click()
    {
        score += clickValue;
        GameManager.Instance.uiManager.UpdateScoreUI(score);
    }

    IEnumerator AutoClickCoroutine()
    {
        while (true)
        {
            yield return new WaitForSeconds(autoClickInterval);
            score += autoClickValue;
            GameManager.Instance.uiManager.UpdateScoreUI(score);
        }
    }

    public void StartAutoClick()
    {
        if (autoClickCoroutine == null)
        {
            autoClickCoroutine = StartCoroutine(AutoClickCoroutine());
        }
    }

    public void StopAutoClick()
    {
        if (autoClickCoroutine != null)
        {
            StopCoroutine(autoClickCoroutine);
            autoClickCoroutine = null;
        }
    }

    public void EarnCurrency(int amount)
    {
        currency += amount;
    }

    public bool SpendCurrency(int amount)
    {
        if (currency >= amount)
        {
            currency -= amount;
            return true;
        }
        return false;
    }

    public void PurchaseUpgrade(int index)
    {
        Upgrade upgrade = upgrades[index];
        if (SpendCurrency(upgrade.cost))
        {
            switch (upgrade.type)
            {
                case 1: // Click Upgrade
                    clickValue = Mathf.CeilToInt(clickValue * upgrade.multiplier);
                    break;
                case 2: // Auto Click Upgrade
                    autoClickValue = Mathf.CeilToInt(autoClickValue * upgrade.multiplier);
                    break;
                default:
                    Debug.LogError("Unknown upgrade type.");
                    break;
            }
        }
    }

    public List<Upgrade> GetUpgrades()
    {
        return upgrades;
    }
}