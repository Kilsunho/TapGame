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
        // ���� ��ư�� ����
        foreach (Transform child in upgradePanel)
        {
            Destroy(child.gameObject);
        }

        // ���ο� ���׷��̵� ��ư ����
        List<Upgrade> upgrades = GameManager.Instance.GameController.GetUpgrades();
        foreach (Upgrade upgrade in upgrades)
        {
            GameObject buttonGO = Instantiate(upgradeButtonPrefab, upgradePanel);
            UpgradeButton upgradeButton = buttonGO.GetComponent<UpgradeButton>();
            upgradeButton.Init(upgrade);
        }
    }
}