using UnityEngine;
using UnityEngine.UI;

public class StatsHUD : MonoBehaviour
{
    public Stats Stats;

    public Image healthbar;
    public Image oxybar;

    // Update is called once per frame
    void Update()
    {
        healthbar.fillAmount = Stats.currentHealth / Stats.maxHealth;
        oxybar.fillAmount = Stats.currentHealth / Stats.maxHealth;
    }
}
