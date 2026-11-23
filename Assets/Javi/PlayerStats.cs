using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    [Header("Bars")]

    [Tooltip("Max health of Entity")] [Range(1, 100)] public float maxHealth;
    [HideInInspector] public float currentHealth;

    [Tooltip("Max Oxygen of Entity")] [Range(0, 50)] public float maxO2;
    [HideInInspector] public float currentO2;

    [Header("Combat")]

    [Tooltip("Damage Output of Entity")] public float damage;
    [Tooltip("Defence of Entity")] public float defence;

    [Header("Misc.")]

    [Tooltip("Amount of mula Entity has")] public int currency;
    [Tooltip("if Entity is Alive or not")] public bool isDead;

    private void Start()
    {
        currentHealth = maxHealth;
        currentO2 = maxO2;  
    }
}
