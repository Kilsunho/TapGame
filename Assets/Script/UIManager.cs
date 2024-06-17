using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class UIManager : MonoBehaviour
{
    public Text scoreText;
    public Transform upgradePanel;
    public GameObject upgradeButtonPrefab;

    public void Init()
    {
        UpdateScoreUI(0);
        RefreshUpgradePanel();
    }

    public void UpdateScoreUI(int score)
    {
        if (scoreText != null)
        {
            scoreText.text = "Score: " + score.ToString();
        }
    }

    public void RefreshUpgradePanel()
    {
        // 기존 버튼들 삭제
        foreach (Transform child in upgradePanel)
        {
            Destroy(child.gameObject);
        }

        // 새로운 업그레이드 버튼 생성
        List<Upgrade> upgrades = GameManager.Instance.GameController.GetUpgrades();
        foreach (Upgrade upgrade in upgrades)
        {
            GameObject buttonGO = Instantiate(upgradeButtonPrefab, upgradePanel);
            UpgradeButton upgradeButton = buttonGO.GetComponent<UpgradeButton>();
            upgradeButton.Init(upgrade);
        }
    }
}