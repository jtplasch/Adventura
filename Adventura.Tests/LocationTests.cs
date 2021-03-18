using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Adventura.Data;

namespace Adventura.Tests
{
    [TestClass]
    public class LocationUnitTest
    {
        [TestMethod]
        public void locationMethod()
        {
            try
            {
                Location location = new Location(5, Jamaica, 3004);
                Console.WriteLine(location());
            }
            catch (ArgumentOutOfRangeException outOfRange)
            {
                Console.WriteLine(outOfRange.Message);
            }
        }
    }

    public class LocationUnitTest1
    {
        private int LocationId;
        private string LocationName;
        private int AdventureId;

        [TestMethod]
        public LocationUnitTest1(int locId, string locName, int advId)
        {
            LocationId = locId;
            LocationName = locName;
            AdventureId = advId;
        }
    }
}

