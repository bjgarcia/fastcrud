using CrudFast.Data.Domain;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;


namespace CrudFast.Data.Test.Integration
{
    [TestClass]
    public class ZipCodeContextTest
    {
        private List<ZipCode> zipStubs = null;
        private IZipCodeRepository zRepo = null;

        public ZipCodeContextTest()
        {
            zRepo = new ZipCodeRepository();
        }
        
        [TestInitialize]
        public void Initialize()
        {
            zipStubs = new List<ZipCode>()
            {
                new ZipCode()
                {
                    zipcodeid = "99999",
                    city = "Tampa",
                    state = "Fl",
                    country = "US",
                    updated = DateTime.Now,
                    updatedby = "test"
                },
                new ZipCode()
                {
                    zipcodeid = "99998",
                    city = "Gaeta",
                    state = "",
                    country = "Italy",
                    updated = DateTime.Now,
                    updatedby = "test"
                }
            };
        }

        [TestCleanup]
        public void cleanup()
        {
            zRepo.Delete(zipStubs[0].zipcodeid);
            zRepo.Delete(zipStubs[1].zipcodeid);
        }

        [TestMethod]
        public void Can_Add_Single_Entity()
        {
            var addEntity = zRepo.Add(zipStubs[1]);
            Assert.IsNotNull(addEntity);
        }

        [TestMethod]
        public void Can_Add_And_Get_Multiple_Entities()
        {
            zipStubs[0] = zRepo.Add(zipStubs[0]);
            zipStubs[1] = zRepo.Add(zipStubs[1]);

            var getEntities = zRepo.Get().Where(e => e.zipcodeid == zipStubs[0].zipcodeid || e.zipcodeid == zipStubs[1].zipcodeid);
            Assert.IsTrue(getEntities.Count() > 1);
        }

        [TestMethod]
        public void Can_Add_Get_And_Update_Entity()
        {
            var getEntity = zRepo.Add(zipStubs[1]);

            getEntity.state = "confusion";
            getEntity.city = "random";
            getEntity.country = "ml";
            getEntity.updatedby = "me";

            var updateEntity = zRepo.Update(getEntity);
            var newEntity = zRepo.Get(zipStubs[1].zipcodeid);

            Assert.AreEqual(updateEntity.zipcodeid, newEntity.zipcodeid);
            Assert.AreEqual(updateEntity.city, newEntity.city);
            Assert.AreEqual(updateEntity.state, newEntity.state);
            Assert.AreEqual(updateEntity.country, newEntity.country);
            Assert.AreEqual(updateEntity.updatedby, newEntity.updatedby);
        }

        [TestMethod]
        public void Will_Delete_By_Id()
        {
            zipStubs[0] = zRepo.Add(zipStubs[0]);
            zRepo.Delete(zipStubs[0].zipcodeid);
            var getEntity = zRepo.Get(zipStubs[0].zipcodeid);
            Assert.IsNull(getEntity);
        }
    }
}
