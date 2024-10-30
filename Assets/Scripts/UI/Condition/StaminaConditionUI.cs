using UnityEngine;
using UnityEngine.UI;

//딱 결과값만 PlayerCoditionController한테 받아 보여줍니다.
public class StaminaConditionUI : MonoBehaviour
{
    public Image uiBar;

    public void ApplyUI(float currentValue, float maxValue)
    {
        uiBar.fillAmount = currentValue / maxValue;
    }
}
