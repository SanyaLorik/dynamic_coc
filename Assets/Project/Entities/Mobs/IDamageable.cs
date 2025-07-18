public interface IDamageable
{
    void Damage(int value);
    
    bool IsAllowDamage { get; }
}
