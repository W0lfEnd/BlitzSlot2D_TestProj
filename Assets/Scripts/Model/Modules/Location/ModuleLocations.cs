using Model.Common;
using Model.Modules.Location.StaticData;


namespace Model.Modules.Location
{

  public class ModuleLocations : IModuleLocations
  {
    public static IStaticDataLocations static_data => ModulesCommon.staticDataContainer.locations;
  }

}