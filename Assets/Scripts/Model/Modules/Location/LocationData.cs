using System;
using System.Collections.Generic;
using Model.Modules.Hero;


namespace Model.Modules.Location
{

  [Serializable]
  public class LocationData
  {
    public List<HeroPrototype> enemies = new List<HeroPrototype>();
  }

}