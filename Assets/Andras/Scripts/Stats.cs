using UnityEngine;

public class Stats : MonoBehaviour
{
    public float maxHealth;
    [HideInInspector] public float currentHealth;

    public int money;

    private void Start()
    {
        currentHealth = maxHealth;
    }
}
