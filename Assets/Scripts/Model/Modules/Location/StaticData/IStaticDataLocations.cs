using System.Collections.Generic;
using Model.StaticData;


namespace Model.Modules.Location.StaticData
{

  public interface IStaticDataLocations : IStaticData
  {
    List<LocationData> locations { get; set; }
  }

}