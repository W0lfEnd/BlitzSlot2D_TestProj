using System;


namespace Model.Modules.Hero
{

  [Serializable]
  public struct HeroPrototype
  {
    public HeroPrototypeID heroPrototypeID;
    public float           maxHealth;
    public float           damage;
  }

}