using System.Collections.Generic;
using Model.Common;
using Model.Modules.Battle;
using Model.Modules.Hero.StaticData;


namespace Model.Modules.Hero
{

  public class ModuleHero : IModuleHero
  {
    public static IStaticDataHero static_data => ModulesCommon.staticDataContainer.hero;

    public static List<HeroPrototype> myHeroes = new List<HeroPrototype>()
    {
      new HeroPrototype()
      {
        heroPrototypeID = HeroPrototypeID.HERO_PROTOTYPE_1, damage = 1, maxHealth = 10,
      }
    , new HeroPrototype()
      {
        heroPrototypeID = HeroPrototypeID.HERO_PROTOTYPE_2, damage = 2, maxHealth = 20,
      }
    , new HeroPrototype()
      {
        heroPrototypeID = HeroPrototypeID.HERO_PROTOTYPE_3, damage = 3, maxHealth = 30,
      }
    , new HeroPrototype()
      {
        heroPrototypeID = HeroPrototypeID.HERO_PROTOTYPE_4, damage = 4, maxHealth = 40,
      }
    };

    public BattleHero createBattleHero( HeroPrototype hero_prototype )
    {
      return new BattleHero( hero_prototype.heroPrototypeID, hero_prototype.maxHealth, hero_prototype.damage );
    }
  }

}