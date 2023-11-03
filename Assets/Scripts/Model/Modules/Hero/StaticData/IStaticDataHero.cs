using System.Collections.Generic;
using Model.StaticData;


namespace Model.Modules.Hero.StaticData
{

  public interface IStaticDataHero : IStaticData
  {
    public IEnumerable<HeroPrototype> getPrototypes();
  }

}