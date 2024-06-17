using UnityEngine;
using UnityEngine.EventSystems;

public class Clicker : MonoBehaviour, IPointerClickHandler
{
    public void OnPointerClick(PointerEventData eventData)
    {
        GameController.Instance.Click();
    }
}
