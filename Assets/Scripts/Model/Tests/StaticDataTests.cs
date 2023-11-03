using Model.StaticData;
using Model.StaticData.Readers;
using NUnit.Framework;
using UnityEngine;


public class StaticDataTests
{
    [Test, Parallelizable]
    public void StaticDataReaderTest()
    {
        StaticDataContainer static_data_container = new StaticDataContainer( new StaticDataFileReader( Application.dataPath + "/static_data" ) );
        static_data_container.load();

        Assert.IsTrue( static_data_container.locations != null );
        Assert.IsTrue( static_data_container.hero != null );
    }
}
