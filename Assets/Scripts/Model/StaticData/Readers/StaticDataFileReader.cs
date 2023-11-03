using System;
using System.IO;
using Unity.Plastic.Newtonsoft.Json;


namespace Model.StaticData.Readers
{

  public class StaticDataFileReader : IStaticDataReader
  {
    public string pathBase { get; set; }


    public StaticDataFileReader( string basePath )
    {
      pathBase = basePath;
    }

    public IStaticData read( Type staticDataType )
    {
      string fileContent = File.ReadAllText( Path.Combine( pathBase, staticDataType.Name + ".json" ) );

      return JsonConvert.DeserializeObject( fileContent, staticDataType ) as IStaticData;
    }
  }

}