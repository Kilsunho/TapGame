using UnityEngine;
using UnityEngine.UI;

public class UpgradeButton : MonoBehaviour
{
    public Text upgradeNameText;
    public Text costText;
    private Upgrade upgrade;

    public void Init(Upgrade upgrade)
    {
        this.upgrade = upgrade;
        upgradeNameText.text = upgrade.name;
        costText.text = "Cost: " + upgrade.cost.ToString();
    }

    public void OnClick()
    {
        GameManager.Instance.GameController.PurchaseUpgrade(upgrade);
        GameManager.Instance.uiManager.RefreshUpgradePanel();
    }
}