using UnityEngine;
using UnityEngine.UI;

public class StatsHUD : MonoBehaviour
{
    public PlayerStats Stats;

    public Image healthbar;
    public Image oxybar;

    // Update is called once per frame
    void Update()
    {
        healthbar.fillAmount = Stats.currentHealth / Stats.maxHealth;
        oxybar.fillAmount = Stats.currentOxy / Stats.maxOxy;
    }
}
