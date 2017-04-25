using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using LINQ101MVC;

namespace TestLINQ101MVC
{
    [TestClass]
    public class UnitTestEssentials
    {
        [TestMethod]
        public void ModelMapper_Map_Method_ShuldReturn_NullObject()
        {
            // Arrangement
            object sourceNullObjectAny = null;

            // Action(s)
            LINQ101MVC.ViewModels.ModelMapper.Map(sourceNullObjectAny, sourceNullObjectAny);

            // Assertions
            Assert.IsNull(sourceNullObjectAny);

        }

        [TestMethod]
        public void ModelMapper_Map_Method_ShuldReturn_NotNullObject()
        {
            // Arrangement
            object sourceNotNullObject = new {Name = "CustomerName"};
            object targetNotNullObject = new {Name = ""};

            // Action(s)
            LINQ101MVC.ViewModels.ModelMapper.Map(sourceNotNullObject, targetNotNullObject);

            // Assertions
            Assert.IsNotNull(targetNotNullObject);
        }

        [TestMethod]
        public void ModelMapper_Map_Method_ShuldReturn_NotNullMappedObject()
        {
            // Arrangement
            object sourceNotNullObject = new FakeType(){Id = 1, Name = "NameValue", IsTrue = true, MyDate = DateTime.Now, StringCollections = new List<string>(){ "String value 1", "String value 2"}};
            object targetNotNullObject = new FakeType();

            // Action(s)
            LINQ101MVC.ViewModels.ModelMapper.Map(sourceNotNullObject, targetNotNullObject);

            // Assertions
            Assert.Equals(targetNotNullObject, sourceNotNullObject);
        }

    }

    internal class FakeType
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsTrue { get; set; }
        public DateTime? MyDate { get; set; }
        public ICollection<string> StringCollections { get; set; }

    }
}
