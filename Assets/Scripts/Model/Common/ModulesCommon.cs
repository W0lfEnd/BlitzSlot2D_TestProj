using Model.Modules;
using Model.StaticData;
using Model.StaticData.Readers;


namespace Model.Common
{

  public static class ModulesCommon
  {
    public static StaticDataContainer staticDataContainer = null;
    public static ModulesContainer modulesContainer = null;

    public static void init( string staticDataPath )
    {
      initStaticData( staticDataPath );
      modulesContainer = new ModulesContainer();
    }

    private static void initStaticData( string staticDataPath )
    {
      staticDataContainer = new StaticDataContainer( new StaticDataFileReader( staticDataPath ) );

      staticDataContainer.load();
    }
  }

}