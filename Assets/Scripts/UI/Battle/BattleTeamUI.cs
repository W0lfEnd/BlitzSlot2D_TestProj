using System.Collections.Generic;
using Model.Modules.Battle;
using UnityEngine;


namespace UI
{

  public class BattleTeamUI : MonoBehaviour
  {
    #region Serialize Fields
    [SerializeField] private BattleHeroUI prefabBattleHeroUI    = null;
    [SerializeField] private Transform    rootForBattleHeroesUI = null;

    [SerializeField] private List<BattleHeroUI> battleHeroes = null;
    #endregion

    #region Private Fields
    private BattleTeam battleTeam = null;
    #endregion


    #region Public Methods
    public void init( BattleTeam battle_team )
    {
      battleTeam = battle_team;

      int heroes_ui_count_delta = battleTeam.battleHeroes.Count - battleHeroes.Count;
      if ( heroes_ui_count_delta > 0 )
        spawnNBattleHeroes( heroes_ui_count_delta );

      enableNBattleHeroes( battleTeam.battleHeroes.Count );

      for ( int i = 0; i < battleTeam.battleHeroes.Count; i++ )
        battleHeroes[i].init( battleTeam.battleHeroes[i] );
    }
    #endregion

    #region Private Methods
    private void spawnNBattleHeroes( int count )
    {
      for ( int i = 0; i < count; i++ )
        battleHeroes.Add( Instantiate( prefabBattleHeroUI, rootForBattleHeroesUI ) );
    }

    private void enableNBattleHeroes( int count )
    {
      for ( int i = 0; i < battleHeroes.Count; i++ )
        battleHeroes[i].gameObject.SetActive( i < count );
    }
    #endregion
  }

}