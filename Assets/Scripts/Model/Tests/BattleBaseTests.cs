using System.Collections.Generic;
using Model;
using Model.Modules.Battle;
using NUnit.Framework;


public class BattleTests
{
  [Test]
  public void TestBattleIteration()
  {
    BattleHero hero1 = new BattleHero(HeroPrototypeID.HERO_PROTOTYPE_1, 100, 10);
    BattleHero hero2 = new BattleHero(HeroPrototypeID.HERO_PROTOTYPE_1, 100, 10);

    BattleTeam team1 = new BattleTeam(new List<BattleHero> { hero1 });
    BattleTeam team2 = new BattleTeam(new List<BattleHero> { hero2 });

    BattleBase battle = new BattleBase( team1, team2 );

    int old_iteration_num = battle.iteration;
    battle.doIteration();

    Assert.AreEqual( 90,                    hero2.health );
    Assert.AreEqual( old_iteration_num + 1, battle.iteration );
  }

  [Test]
  public void TestBattleFinish()
  {
    BattleHero hero1 = new BattleHero( HeroPrototypeID.HERO_PROTOTYPE_1, 100, 10 );
    BattleHero hero2 = new BattleHero( HeroPrototypeID.HERO_PROTOTYPE_1, 0,   10 );

    BattleTeam team1 = new BattleTeam( new List<BattleHero> { hero1 } );
    BattleTeam team2 = new BattleTeam( new List<BattleHero> { hero2 } );

    BattleBase battle = new BattleBase( team1, team2 );

    bool was_battle_finish_event_triggered = false;
    bool winner_was_right = false;

    battle.onBattleFinish += winner_id =>
    {
      was_battle_finish_event_triggered = true;
      winner_was_right = winner_id == TeamID.FIRST;
    };

    battle.doIteration();

    Assert.IsTrue( was_battle_finish_event_triggered );
    Assert.IsTrue( winner_was_right );
  }
}