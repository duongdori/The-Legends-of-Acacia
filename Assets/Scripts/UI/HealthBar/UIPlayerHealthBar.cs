using UnityEngine;
using TMPro;

public class UIPlayerHealthBar : UIHealthBar
{
    public TextMeshProUGUI amountText;

    protected override void FixedUpdate()
    {
        base.FixedUpdate();
        amountText.text = stats.CurrentHealth + "/" + stats.maxHealth.GetValue();
    }

    protected override void LoadComponents()
    {
        base.LoadComponents();
        LoadAmountText();
    }

    protected override void LoadBaseEntity()
    {
        base.LoadBaseEntity();
        if(entity != null) return;
        entity = FindObjectOfType<Player>().GetComponent<Player>();
        Debug.LogWarning(transform.name + " LoadBaseEntity", gameObject);
    }

    protected override void LoadStats()
    {
        base.LoadStats();
        if(stats != null) return;
        stats = entity.GetComponent<CharacterStats>();
        Debug.LogWarning(transform.name + " LoadStats", gameObject);
    }
    
    private void LoadAmountText()
    {
        if(amountText != null) return;
        amountText = GetComponentInChildren<TextMeshProUGUI>();
        Debug.LogWarning(transform.name + " LoadAmountText", gameObject);
    }
}