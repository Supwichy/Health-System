public sealed class HealthSystem
{
    public event EventHandler OnDamage;
    public event EventHandler OnHeal;
    public event EventHandler OnDead;
    public event EventHandler OnReSpawn;

    private float health;
    private float healthMax;
    private bool isDead;

    public HealthSystem(float health)
    {
        SetHealth(health);
        SetHealthMax(health);
        SetDead(false);
    }

    public float GetHealth() { return health; }
    public float GetHealthMax() { return healthMax; }
    public float GetHealthPercent() { return health / healthMax; }

    public void Damage(float damageAmount)
    {
        if (IsDead())
            return;

        RemoveHealth(damageAmount);
        if (GetHealth() <= 0)
        {
            SetHealth(0);
            SetDead(true);

            OnDead?.Invoke(this, EventArgs.Empty);
        }

        OnDamage?.Invoke(this, EventArgs.Empty);
    }

    public void Heal(float healAmount)
    {
        if (IsDead())
            return;

        AddHealth(healAmount);
        if (GetHealth() >= GetHealthMax())
        {
            SetHealth(healthMax);
        }

        OnHeal?.Invoke(this, EventArgs.Empty);
    }

    public void ReSpawn(float health)
    {
        SetHealth(health);
        SetDead(false);
        OnReSpawn?.Invoke(this, EventArgs.Empty);
    }

    public void ReSpawn()
    {
        ReSpawn(healthMax);
    }

    public bool IsDead()
    {
        return isDead;
    }

    public void UpgradeHealth(float healthAmount)
    {
        AddHealth(healthAmount);
        AddHealthMax(healthAmount);
    }

    private void SetDead(bool isDead)
    {
        this.isDead = isDead;
    }

    private void AddHealth(float healthAmount)
    {
        this.health += healthAmount;
    }

    private void SetHealth(float healthAmount)
    {
        this.health = healthAmount;
    }

    private void RemoveHealth(float healthAmount)
    {
        this.health -= healthAmount;
    }

    private void AddHealthMax(float healthAmount)
    {
        this.healthMax += healthAmount;
    }

    private void SetHealthMax(float healthAmount)
    {
        this.healthMax = healthAmount;
    }

    private void RemoveHealthMax(float healthAmount)
    {
        this.healthMax -= healthAmount;
    }

}