using Model;
using Model.Modules.Battle;
using NUnit.Framework;


public class BattleHeroTests
{
  [Test]
  public void TestGiveDamageTo()
  {
    BattleHero hero1 = new BattleHero( HeroPrototypeID.HERO_PROTOTYPE_1, 100, 10 );
    BattleHero hero2 = new BattleHero( HeroPrototypeID.HERO_PROTOTYPE_1, 50,  5 );

    float old_hero1_hp = hero1.health;
    hero1.giveDamageTo( hero2 );

    Assert.AreEqual( 40,    hero2.health );
    Assert.AreEqual( hero1.health, old_hero1_hp );
  }

  [Test]
  public void TestDeath()
  {
    BattleHero hero1 = new BattleHero( HeroPrototypeID.HERO_PROTOTYPE_1, 100, 100 );
    BattleHero hero2 = new BattleHero( HeroPrototypeID.HERO_PROTOTYPE_1, 50,  0 );

    bool was_death_event_triggered = false;
    hero2.onDeath += () => was_death_event_triggered = true;

    hero1.giveDamageTo( hero2 );

    Assert.IsTrue( was_death_event_triggered );
  }
}