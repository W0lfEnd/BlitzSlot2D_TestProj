using Model.Modules.Battle;


namespace Model.Modules.Hero
{

  public interface IModuleHero
  {
    BattleHero createBattleHero( HeroPrototype hero_prototype );
  }

}