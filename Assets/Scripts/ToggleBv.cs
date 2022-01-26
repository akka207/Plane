using UnityEngine;
using UnityEngine.UI;

public class ToggleBv : MonoBehaviour
{
    
    public Toggle selectedToggle;

    void Start()
    {
        selectedToggle.onValueChanged.AddListener(delegate {ToggleValueChangedOccured(selectedToggle);});
    }

    void ToggleValueChangedOccured(Toggle tglValue)
    {
        PlaneBv.useRandomSpeed = tglValue.isOn;
    }

}
