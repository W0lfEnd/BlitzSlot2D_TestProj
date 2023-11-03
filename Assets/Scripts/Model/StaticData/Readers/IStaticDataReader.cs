using System;


namespace Model.StaticData.Readers
{

  public interface IStaticDataReader
  {
    public IStaticData read( Type staticDataType );
  }

}