using Adventura.Data;
using Adventura.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace Adventura.Tests
{
    
    [TestClass]
    public class AdventureTests
    {
        public static Guid userId = new Guid("300faab2-c025-4b37-a115-fbd82b6fdb9e");
        private AdventureService _repo = new AdventureService(userId);
        private List<Adventure> _adventures = new List<Adventure>();
        [TestInitialize]
        public void Seed()
        {
            _adventures = new List<Adventure>();
            _repo = new AdventureService(userId);
            Adventure seedAdventure = new Adventure();
            {
                seedAdventure.AdventureId = 3004;
                seedAdventure.Title = "Beaches of Jamaica";
                seedAdventure.Description = null;
            };
            _adventures.Add(seedAdventure);
        }
    }
    /*
    [TestMethod]
    public void CreateAdventureTest()
    {
    }
    */
}
