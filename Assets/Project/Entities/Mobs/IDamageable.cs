public interface IDamageable
{
    void Damage(int value);
    
    bool IsAllowDamage { get; }

    TeamType Team { get; }
}

public enum TeamType
{
    Allience = 0,
    Enemy
}