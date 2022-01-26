using UnityEngine;
using UnityEngine.UI;

public class SettingsUI : MonoBehaviour
{
    
    public Text bulletSpeedText;
    public Text planeSpeedText;
    public Text shotFaultText;
    public Text shotDensityText;
    public Text queueText;

    public void ChangePlaneSpeed(float newValue)
    {
        PlaneBv.speedToUI = newValue;
    }

    public void ChangeBulletSpeed(float newValue)
    {
        CanonBv.bulletSpeedToUI = newValue;
    }

    public void ChangeShotFault(float newValue)
    {
        CanonBv.shotFault = newValue;
    }

    public void ChangeShotDensity(float newValue)
    {
        CanonBv.shotDensity = newValue;
    }

    public void ChangeQueue(float newValue)
    {
        CanonBv.queue = newValue;
    }

    void Update()
    {
        bulletSpeedText.text = CanonBv.bulletSpeedToUI.ToString();
        planeSpeedText.text = PlaneBv.speedToUI.ToString();
        shotFaultText.text = CanonBv.shotFault.ToString();
        shotDensityText.text = CanonBv.shotDensity.ToString();
        queueText.text = CanonBv.queue.ToString();
    }
}
