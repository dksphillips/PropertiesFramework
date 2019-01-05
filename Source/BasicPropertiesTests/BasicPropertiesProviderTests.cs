using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autodesk.PropertiesFramework.BasicProperties;

namespace Autodesk.PropertiesFramework.BasicPropertiesTests
{
   [TestClass()]
   public class BasicPropertiesProviderTests
   {
      #region Construction Tests

      // test that a basic property provider is properly created
      // with the default constructor
      [TestMethod]
      public void Provider_Creation_Default()
      {
         BasicPropertiesProvider provider = new BasicPropertiesProvider();

         // check the expected default values
         checkDefaultProvider(provider);
      }

      // test that a basic property definition is properly created
      [TestMethod]
      public void Provider_Creation_Valid()
      {
         BasicPropertiesProvider provider = new BasicPropertiesProvider(TestConstants.anID, TestConstants.aName);

         Assert.AreEqual(TestConstants.anID, provider.ID, false);
         Assert.AreEqual(TestConstants.aName, provider.Name, false);
      }

      [TestMethod]
      public void Provider_Creation_Invalid_NullID()
      {
         BasicPropertiesProvider provider = null;
         ArgumentException expectedException = null;

         try
         {
            provider = new BasicPropertiesProvider(null, TestConstants.aName);
         }
         catch (ArgumentException e)
         {
            expectedException = e;
         }

         TestUtilities.checkException(expectedException, TestConstants.propID, TestConstants.paramID);
         Assert.IsNull(provider, "No provider should be created.");
      }

      [TestMethod]
      public void Provider_Creation_Invalid_EmptyID()
      {
         BasicPropertiesProvider provider = null;
         ArgumentException expectedException = null;

         try
         {
            provider = new BasicPropertiesProvider(string.Empty, TestConstants.aName);
         }
         catch (ArgumentException e)
         {
            expectedException = e;
         }

         TestUtilities.checkException(expectedException, TestConstants.propID, TestConstants.paramID);
         Assert.IsNull(provider, "No provider should be created.");
      }

      [TestMethod]
      public void Provider_Creation_Invalid_WhitespaceID()
      {
         BasicPropertiesProvider provider = null;
         ArgumentException expectedException = null;

         try
         {
            provider = new BasicPropertiesProvider(TestConstants.whitespaceOnly, TestConstants.aName);
         }
         catch (ArgumentException e)
         {
            expectedException = e;
         }

         TestUtilities.checkException(expectedException, TestConstants.propID, TestConstants.paramID);
         Assert.IsNull(provider, "No provider should be created.");
      }

      [TestMethod]
      public void Provider_Creation_Invalid_NullName()
      {
         BasicPropertiesProvider provider = null;
         ArgumentException expectedException = null;

         try
         {
            provider = new BasicPropertiesProvider(TestConstants.anID, null);
         }
         catch (ArgumentException e)
         {
            expectedException = e;
         }

         TestUtilities.checkException(expectedException, TestConstants.propName, TestConstants.paramName);
         Assert.IsNull(provider, "No provider should be created.");
      }

      [TestMethod]
      public void Provider_Creation_Invalid_EmptyName()
      {
         BasicPropertiesProvider provider = null;
         ArgumentException expectedException = null;

         try
         {
            provider = new BasicPropertiesProvider(TestConstants.anID, string.Empty);
         }
         catch (ArgumentException e)
         {
            expectedException = e;
         }

         TestUtilities.checkException(expectedException, TestConstants.propName, TestConstants.paramName);
         Assert.IsNull(provider, "No provider should be created.");
      }

      [TestMethod]
      public void Provider_Creation_Invalid_WhitespaceName()
      {
         BasicPropertiesProvider provider = null;
         ArgumentException expectedException = null;

         try
         {
            provider = new BasicPropertiesProvider(TestConstants.anID, TestConstants.whitespaceOnly);
         }
         catch (ArgumentException e)
         {
            expectedException = e;
         }

         TestUtilities.checkException(expectedException, TestConstants.propName, TestConstants.paramName);
         Assert.IsNull(provider, "No provider should be created.");
      }
      #endregion Construction Tests

      #region ID Property Tests
      [TestMethod]
      public void Provider_ID_Set()
      {
         BasicPropertiesProvider provider = new BasicPropertiesProvider(TestConstants.anID, TestConstants.aName);

         provider.ID = TestConstants.newID;

         Assert.AreEqual(TestConstants.newID, provider.ID, false);
      }

      [TestMethod]
      public void Provider_ID_SetNull()
      {
         BasicPropertiesProvider provider = new BasicPropertiesProvider(TestConstants.anID, TestConstants.aName);
         ArgumentException expectedException = null;

         try
         {
            provider.ID = null;
         }
         catch (ArgumentException e)
         {
            expectedException = e;
         }

         TestUtilities.checkException(expectedException, TestConstants.propID, TestConstants.paramID);
         Assert.AreEqual(TestConstants.anID, provider.ID, false, "The ID should not change.");
      }

      [TestMethod]
      public void Provider_ID_SetEmpty()
      {
         BasicPropertiesProvider provider = new BasicPropertiesProvider(TestConstants.anID, TestConstants.aName);
         ArgumentException expectedException = null;

         try
         {
            provider.ID = string.Empty;
         }
         catch (ArgumentException e)
         {
            expectedException = e;
         }

         TestUtilities.checkException(expectedException, TestConstants.propID, TestConstants.paramID);
         Assert.AreEqual(TestConstants.anID, provider.ID, false, "The ID should not change.");
      }

      [TestMethod]
      public void Provider_ID_SetWhitespace()
      {
         BasicPropertiesProvider provider = new BasicPropertiesProvider(TestConstants.anID, TestConstants.aName);
         ArgumentException expectedException = null;

         try
         {
            provider.ID = TestConstants.whitespaceOnly;
         }
         catch (ArgumentException e)
         {
            expectedException = e;
         }

         TestUtilities.checkException(expectedException, TestConstants.propID, TestConstants.paramID);
         Assert.AreEqual(TestConstants.anID, provider.ID, false, "The ID should not change.");
      }

      #endregion  ID Property Tests

      #region Name Property Tests
      [TestMethod]
      public void Provider_Name_Set()
      {
         BasicPropertiesProvider provider = new BasicPropertiesProvider(TestConstants.anID, TestConstants.aName);

         provider.Name = TestConstants.newName;

         Assert.AreEqual(TestConstants.newName, provider.Name, false);
      }

      [TestMethod]
      public void Provider_Name_SetNull()
      {
         BasicPropertiesProvider provider = new BasicPropertiesProvider(TestConstants.anID, TestConstants.aName);
         ArgumentException expectedException = null;

         try
         {
            provider.Name = null;
         }
         catch (ArgumentException e)
         {
            expectedException = e;
         }

         TestUtilities.checkException(expectedException, TestConstants.propName, TestConstants.paramName);
         Assert.AreEqual(TestConstants.aName, provider.Name, false, "The Name should not change.");
      }

      [TestMethod]
      public void Provider_Name_SetEmpty()
      {
         BasicPropertiesProvider provider = new BasicPropertiesProvider(TestConstants.anID, TestConstants.aName);
         ArgumentException expectedException = null;

         try
         {
            provider.Name = string.Empty;
         }
         catch (ArgumentException e)
         {
            expectedException = e;
         }

         TestUtilities.checkException(expectedException, TestConstants.propName, TestConstants.paramName);
         Assert.AreEqual(TestConstants.aName, provider.Name, false, "The Name should not change.");
      }

      [TestMethod]
      public void Provider_Name_SetWhitespace()
      {
         BasicPropertiesProvider provider = new BasicPropertiesProvider(TestConstants.anID, TestConstants.aName);
         ArgumentException expectedException = null;

         try
         {
            provider.Name = TestConstants.whitespaceOnly;
         }
         catch (ArgumentException e)
         {
            expectedException = e;
         }

         TestUtilities.checkException(expectedException, TestConstants.propName, TestConstants.paramName);
         Assert.AreEqual(TestConstants.aName, provider.Name, false, "The Name should not change.");
      }
      #endregion  Name Property Tests

      #region Properties Tests

      [TestMethod]
      public void Provider_AddProperty()
      {
         BasicPropertiesProvider provider = new BasicPropertiesProvider(TestConstants.anID, TestConstants.aName);
         BasicProperty aProperty = new BasicProperty(TestConstants.anID, TestConstants.aName);

         provider.AddProperty(aProperty);

         TestUtilities.checkForSingleItem(provider.Properties, aProperty, "Properties");
      }

      [TestMethod]
      public void Provider_AddProperty_Null()
      {
         BasicPropertiesProvider provider = new BasicPropertiesProvider(TestConstants.anID, TestConstants.aName);
         ArgumentNullException expectedException = null;

         try
         {
            provider.AddProperty(null);
         }
         catch (ArgumentNullException e)
         {
            expectedException = e;
         }

         TestUtilities.checkException(expectedException, TestConstants.propProperty, TestConstants.paramProperty);
         TestUtilities.checkEmpty(provider.Properties, "Properties");
      }

      [TestMethod]
      public void Provider_AddProperty_Duplicate()
      {
         BasicPropertiesProvider provider = new BasicPropertiesProvider(TestConstants.anID, TestConstants.aName);
         BasicProperty aProperty = new BasicProperty(TestConstants.anID, TestConstants.aName);
         ArgumentException expectedException = null;

         provider.AddProperty(aProperty);

         try
         {
            provider.AddProperty(aProperty);
         }
         catch (ArgumentException e)
         {
            expectedException = e;
         }

         TestUtilities.checkException(expectedException);
         TestUtilities.checkForSingleItem(provider.Properties, aProperty, "Properties");
      }

      [TestMethod]
      public void Provider_RemoveProperty()
      {
         BasicPropertiesProvider provider = new BasicPropertiesProvider(TestConstants.anID, TestConstants.aName);
         BasicProperty aProperty = new BasicProperty(TestConstants.anID, TestConstants.aName);

         provider.AddProperty(aProperty);
         provider.RemoveProperty(aProperty);

         TestUtilities.checkEmpty(provider.Properties, "Properties");
      }

      [TestMethod]
      public void Provider_RemoveProperty_ByID()
      {
         BasicPropertiesProvider provider = new BasicPropertiesProvider(TestConstants.anID, TestConstants.aName);
         BasicProperty aProperty = new BasicProperty(TestConstants.anID, TestConstants.aName);

         provider.AddProperty(aProperty);
         provider.RemoveProperty(TestConstants.anID);

         TestUtilities.checkEmpty(provider.Properties, "Properties");
      }

      [TestMethod]
      public void Provider_RemoveProperty_NullProperty()
      {
         BasicPropertiesProvider provider = new BasicPropertiesProvider(TestConstants.anID, TestConstants.aName);
         ArgumentNullException expectedException = null;

         try
         {
            provider.RemoveProperty((IProperty)null);
         }
         catch (ArgumentNullException e)
         {
            expectedException = e;
         }

         Assert.IsNotNull(expectedException, "ArgumentNullException not thrown");
         TestUtilities.checkEmpty(provider.Properties, "Properties");
      }

      [TestMethod]
      public void Provider_RemoveProperty_NullID()
      {
         BasicPropertiesProvider provider = new BasicPropertiesProvider(TestConstants.anID, TestConstants.aName);
         ArgumentNullException expectedException = null;

         try
         {
            provider.RemoveProperty((string)null);
         }
         catch (ArgumentNullException e)
         {
            expectedException = e;
         }

         TestUtilities.checkException(expectedException);
         TestUtilities.checkEmpty(provider.Properties, "Properties");
      }

      [TestMethod]
      public void Provider_RemoveProperty_NonexistentProperty()
      {
         BasicPropertiesProvider provider = new BasicPropertiesProvider(TestConstants.anID, TestConstants.aName);
         BasicProperty aProperty = new BasicProperty(TestConstants.anID, TestConstants.aName);
         KeyNotFoundException expectedException = null;

         try
         {
            provider.RemoveProperty(aProperty);
         }
         catch (KeyNotFoundException e)
         {
            expectedException = e;
         }

         Assert.IsNotNull(expectedException, "KeyNotFoundException not thrown");
         TestUtilities.checkEmpty(provider.Properties, "Properties");
      }

      [TestMethod]
      public void Provider_RemoveProperty_NonexistentID()
      {
         BasicPropertiesProvider provider = new BasicPropertiesProvider(TestConstants.anID, TestConstants.aName);
         KeyNotFoundException expectedException = null;

         try
         {
            provider.RemoveProperty(TestConstants.anID);
         }
         catch (KeyNotFoundException e)
         {
            expectedException = e;
         }

         Assert.IsNotNull(expectedException, "KeyNotFoundException not thrown");
         TestUtilities.checkEmpty(provider.Properties, "Properties");
      }

      [TestMethod]
      [Description("Confirm that the properties are maintained in the order in which they are added.")]
      public void Provider_IterateProperties()
      {
         BasicPropertiesProvider provider = new BasicPropertiesProvider(TestConstants.anID, TestConstants.aName);
         BasicProperty propertyAA = new BasicProperty("AA", "AA");
         BasicProperty propertyBB = new BasicProperty("BB", "BB");
         BasicProperty propertyCC = new BasicProperty("CC", "CC");

         List<string> expectedIDs = new List<string>() { "CC", "BB", "AA" };

         provider.AddProperty(propertyCC);
         provider.AddProperty(propertyBB);
         provider.AddProperty(propertyAA);

         List<string> actualIds = new List<string>();
         foreach (IProperty property in provider.Properties)
         {
            actualIds.Add(property.Definition.ID);
         }

         Assert.AreEqual(expectedIDs.Count, actualIds.Count);
         for (int i = 0; i < expectedIDs.Count; i++)
         {
            Assert.AreEqual(expectedIDs[i], actualIds[i]);
         }
      }
      #endregion  Properties Tests


      #region Helpers
      private static void checkDefaultProvider(IPropertiesProvider provider)
      {
         // check the expected default values
         // the ID should be a valid guid
         TestUtilities.checkGuid(provider.ID, true);
         Assert.AreEqual(BasicPropertiesProvider.DefaultProviderName, provider.Name, false);
         Assert.AreEqual(string.Empty, provider.ToolTip);

         // the groups and properties in the specified provider should not
         // be null references and should be empty
         TestUtilities.checkEmpty(provider.Groups, "Groups");
         TestUtilities.checkEmpty(provider.Properties, "Properties");
      }
      #endregion Helpers
   }
}
