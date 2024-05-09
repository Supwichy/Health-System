public interface IHasHealthSystem
{
    public void Damage(float damageAmount);
    public void Heal(float healAmount);
    public bool IsDead();
    public void ReSpawn();
    public void UpgradeHealth(float healthAmount);
}