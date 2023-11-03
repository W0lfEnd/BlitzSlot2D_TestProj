using System;
using System.Collections.Generic;


namespace Model.Modules.Hero.StaticData
{

  public class StaticDataHero : IStaticDataHero
  {
    private List<HeroPrototype> prototypes = null;

    public IEnumerable<HeroPrototype> getPrototypes()
    {
      if ( prototypes == null )
        throw new Exception( "Static data not loaded" );

      return prototypes;
    }
  }

}