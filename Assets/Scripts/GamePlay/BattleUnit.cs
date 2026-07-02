public class BattleUnit
{
    public Hero Hero { get; }
    public Enemy Enemy { get; }
    public bool IsHero => Hero != null;
    public int Speed => IsHero ? Hero.Speed : Enemy.Speed;
    public BattleUnit(Hero hero)
    {
        Hero = hero;
    }
    public BattleUnit(Enemy enemy)
    {
        Enemy = enemy;
    }
}