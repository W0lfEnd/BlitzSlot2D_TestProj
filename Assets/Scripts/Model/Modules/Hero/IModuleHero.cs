using System.Collections.Generic;
using Model.Modules.Battle;


namespace Model.Modules.Hero
{

  public interface IModuleHero
  {
    List<HeroPrototype> getMyHeroes();
    BattleHero createBattleHero( HeroPrototype hero_prototype );
  }

}