using UnityEngine;

public class RechargeableShield : MonoBehaviour
{
    public ShieldInfo shieldInfo;
    public InteractableObject shieldRechargerInteractable;
    public EnergyHolder energyHolder;

    void Awake()
    {
        if (!energyHolder)
        {
            energyHolder = GetComponentInParent<EnergyHolder>();
        }
        if (!shieldRechargerInteractable)
        {
            shieldRechargerInteractable = GetComponentInChildren<InteractableObject>();
        }
    }

    void Start()
    {
        shieldRechargerInteractable.activationDelay = shieldInfo.activationDelay;
    }

    public void Recharge()
    {
        energyHolder.gameObject.SetActive(true);
        energyHolder.Increment(shieldInfo.rechangePerActivation);
    }
}
