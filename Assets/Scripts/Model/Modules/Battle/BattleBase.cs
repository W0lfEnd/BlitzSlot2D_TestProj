using System;
using System.Collections.Generic;
using System.Linq;
using Model.Common;


namespace Model.Modules.Battle
{

  public class BattleBase
  {
    public event Action<TeamID> onBattleFinish = delegate {};
    public event Action<int> onIteration = delegate {};

    public int    iteration { get; private set; } = 0;
    public TeamID curTeamID { get; private set; } = TeamID.NONE;
    public Dictionary<TeamID, BattleTeam> battleTeams = new Dictionary<TeamID, BattleTeam>();


    private TeamID winnerID = TeamID.NONE;
    private BattleTeam curTeam => battleTeams[curTeamID];
    private BattleTeam anotherTeam => battleTeams[curTeamID.getNextTeamID()];


    public BattleBase( BattleTeam battle_team1, BattleTeam battle_team2, TeamID first = TeamID.FIRST )
    {
      battleTeams[TeamID.FIRST] = battle_team1;
      battleTeams[TeamID.SECOND] = battle_team2;
      curTeamID = first;
    }

    public void doIteration()
    {
      if ( winnerID != TeamID.NONE )
        return;

      BattleHero random_alive_hero       = curTeam    .battleHeroes.Where( it => !it.isDead ).ToList().randomElement();
      BattleHero random_alive_enemy_hero = anotherTeam.battleHeroes.Where( it => !it.isDead ).ToList().randomElement();
      if ( random_alive_hero != null && random_alive_enemy_hero != null )
        random_alive_hero.giveDamageTo( random_alive_enemy_hero );

      onIteration( iteration );

      if ( checkWinner() )
        return;

      curTeamID = curTeamID.getNextTeamID();
      iteration++;
    }

    private bool checkWinner()
    {
      winnerID = getWinner();
      bool is_finished = winnerID != TeamID.NONE;
      if ( is_finished )
        onBattleFinish( winnerID );

      return is_finished;

      TeamID getWinner()
      {
        if ( battleTeams[TeamID.SECOND].isAllDead )
          return TeamID.FIRST;

        if ( battleTeams[TeamID.FIRST].isAllDead )
          return TeamID.SECOND;

        return TeamID.NONE;
      }
    }

  }

}