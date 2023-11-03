using Model.Modules.Hero.StaticData;
using Model.Modules.Location.StaticData;
using Model.StaticData.Readers;
using UnityEngine;


namespace Model.StaticData
{

  public class StaticDataContainer
  {
    private IStaticDataReader staticDataReader;

    public IStaticDataHero      hero;
    public IStaticDataLocations locations;


    public StaticDataContainer( IStaticDataReader static_data_reader )
      => staticDataReader = static_data_reader;

    public void load()
    {
      hero = (IStaticDataHero)staticDataReader.read( typeof( StaticDataHero ) );
      locations = (IStaticDataLocations)staticDataReader.read( typeof( StaticDataLocations ) );
    }
  }

}