using System;
using System.Collections.Generic;
using System.Linq;
using Model.Common;
using Model.Modules.Battle;
using Model.Modules.Hero;
using Model.Modules.Location;
using UnityEngine;


namespace UI
{

  public class UIController : MonoBehaviour
  {
    #region Serialize Fields
    [SerializeField] public LocationSelectUI locationSelectUI;
    [SerializeField] public BattleUI         battleUI;
    #endregion


    #region Unity Methods
    private void Awake()
    {
      locationSelectUI.onLocationSelected += openBattlePanel;
      battleUI.onBackBtn += openSelectLocationPanel;
    }
    #endregion

    #region Public Methods
    public void init()
    {
      openSelectLocationPanel();
    }
    #endregion

    #region Private Methods
    private void openBattlePanel( int location_idx )
    {
      LocationData location_data = ModuleLocations.static_data.locations.safeGet( location_idx );
      if ( location_data == null )
      {
        Debug.LogError( $"{location_idx} location dont exist" );
        return;
      }

      locationSelectUI.gameObject.SetActive( false );
      battleUI.gameObject.SetActive( true );


      IEnumerable<BattleHero> my_battle_heroes = ModuleHero.myHeroes.Select( createBattleHero );
      BattleTeam              my_team          = new BattleTeam( my_battle_heroes );

      IEnumerable<BattleHero> enemy_battle_heroes = location_data.enemies.Select( createBattleHero );
      BattleTeam              enemy_team          = new BattleTeam( enemy_battle_heroes );

      BattleBase battle_base = new BattleBase( my_team, enemy_team );
      battleUI.init( battle_base );

      static BattleHero createBattleHero( HeroPrototype hero_prototype )
        => GameManager.instance.modulesContainer.hero.createBattleHero( hero_prototype );
    }

    private void openSelectLocationPanel()
    {
      battleUI.gameObject.SetActive( false );
      locationSelectUI.gameObject.SetActive( true );
      
      locationSelectUI.init( ModuleLocations.static_data.locations );
    }
    #endregion
  }

}