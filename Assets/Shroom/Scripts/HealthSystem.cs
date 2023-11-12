using System;
public class HealthSystem
{
    public EventHandler OnHealthChanged;
    public EventHandler OnHealthMaxChanged;
    public EventHandler OnDamaged;
    public EventHandler OnHealed;
    public EventHandler OnDead;

    private float health;
    private float healthMax;
    public HealthSystem(float healthMax)
    {
        this.healthMax = healthMax;
        health = healthMax;
    }

    public float GetHealth()
    {
        return health;
    }

    public float GetHealthMax()
    {
        return healthMax;
    }

    public float GetHealthPercent()
    {
        return health / healthMax;
    }
    public void Damage(float damageAmount)
    {
        health -= damageAmount;
        OnDamaged?.Invoke(this, EventArgs.Empty);

        if (health <= 0)
        {
            health = 0;
            OnDead?.Invoke(this, EventArgs.Empty);
        }

        OnHealthChanged?.Invoke(this, EventArgs.Empty);
    }

    public void Heal(float healAmount)
    {
        health += healAmount;
        OnHealed?.Invoke(this, EventArgs.Empty);

        if (health > healthMax)
            health = healthMax;

        OnHealthChanged?.Invoke(this, EventArgs.Empty);

    }
}
