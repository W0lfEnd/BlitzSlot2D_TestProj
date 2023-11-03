using System;
using System.Collections.Generic;
using System.Linq;


namespace Model.Modules.Battle
{

  public class BattleTeam
  {
    public readonly IReadOnlyList<BattleHero> battleHeroes;


    public BattleTeam( IEnumerable<BattleHero> battle_heroes )
    {
      battleHeroes = battle_heroes.ToList();
    }

    public bool isAnyAlive => battleHeroes.Any( it => it.isAlive );

    public bool isAllDead => battleHeroes.All( it => it.isDead );
  }

}