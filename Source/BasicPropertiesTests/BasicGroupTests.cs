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
   public class BasicGroupTests
   {
      #region Construction Tests

      // test that a basic property group is properly created
      // with the default constructor
      [TestMethod]
      public void Group_Creation_Default()
      {
         BasicGroup group = new BasicGroup();

         // check the expected default values
         TestUtilities.checkDefaultGroup(group);
      }

      // test that a basic property definition is properly created
      [TestMethod]
      public void Group_Creation_Valid()
      {
         BasicGroup group = new BasicGroup(TestConstants.anID, TestConstants.aName);

         Assert.AreEqual(TestConstants.anID, group.ID, false);
         Assert.AreEqual(TestConstants.aName, group.Name, false);
      }

      [TestMethod]
      public void Group_Creation_Invalid_NullID()
      {
         BasicGroup group = null;
         ArgumentException expectedException = null;

         try
         {
            group = new BasicGroup(null, TestConstants.aName);
         }
         catch (ArgumentException e)
         {
            expectedException = e;
         }

         TestUtilities.checkException(expectedException, TestConstants.propID, TestConstants.paramID);
         Assert.IsNull(group, "No groupn should be created.");
      }

      [TestMethod]
      public void Group_Creation_Invalid_EmptyID()
      {
         BasicGroup group = null;
         ArgumentException expectedException = null;

         try
         {
            group = new BasicGroup(string.Empty, TestConstants.aName);
         }
         catch (ArgumentException e)
         {
            expectedException = e;
         }

         TestUtilities.checkException(expectedException, TestConstants.propID, TestConstants.paramID);
         Assert.IsNull(group, "No group should be created.");
      }

      [TestMethod]
      public void Group_Creation_Invalid_WhitespaceID()
      {
         BasicGroup group = null;
         ArgumentException expectedException = null;

         try
         {
            group = new BasicGroup(TestConstants.whitespaceOnly, TestConstants.aName);
         }
         catch (ArgumentException e)
         {
            expectedException = e;
         }

         TestUtilities.checkException(expectedException, TestConstants.propID, TestConstants.paramID);
         Assert.IsNull(group, "No group should be created.");
      }

      [TestMethod]
      public void Group_Creation_Invalid_NullName()
      {
         BasicGroup group = null;
         ArgumentException expectedException = null;

         try
         {
            group = new BasicGroup(TestConstants.anID, null);
         }
         catch (ArgumentException e)
         {
            expectedException = e;
         }

         TestUtilities.checkException(expectedException, TestConstants.propName, TestConstants.paramName);
         Assert.IsNull(group, "No group should be created.");
      }

      [TestMethod]
      public void Group_Creation_Invalid_EmptyName()
      {
         BasicGroup group = null;
         ArgumentException expectedException = null;

         try
         {
            group = new BasicGroup(TestConstants.anID, string.Empty);
         }
         catch (ArgumentException e)
         {
            expectedException = e;
         }

         TestUtilities.checkException(expectedException, TestConstants.propName, TestConstants.paramName);
         Assert.IsNull(group, "No group should be created.");
      }

      [TestMethod]
      public void Group_Creation_Invalid_WhitespaceName()
      {
         BasicGroup group = null;
         ArgumentException expectedException = null;

         try
         {
            group = new BasicGroup(TestConstants.anID, TestConstants.whitespaceOnly);
         }
         catch (ArgumentException e)
         {
            expectedException = e;
         }

         TestUtilities.checkException(expectedException, TestConstants.propName, TestConstants.paramName);
         Assert.IsNull(group, "No group should be created.");
      }

      #endregion  Construction Tests

      #region ID Property Tests
      [TestMethod]
      public void Group_ID_Set()
      {
         BasicGroup group = new BasicGroup(TestConstants.anID, TestConstants.aName);

         group.ID = TestConstants.newID;

         Assert.AreEqual(TestConstants.newID, group.ID, false);
      }

      [TestMethod]
      public void Group_ID_SetNull()
      {
         BasicGroup group = new BasicGroup(TestConstants.anID, TestConstants.aName);
         ArgumentException expectedException = null;

         try
         {
            group.ID = null;
         }
         catch (ArgumentException e)
         {
            expectedException = e;
         }

         TestUtilities.checkException(expectedException, TestConstants.propID, TestConstants.paramID);
         Assert.AreEqual(TestConstants.anID, group.ID, false, "The ID should not change.");
      }

      [TestMethod]
      public void Group_ID_SetEmpty()
      {
         BasicGroup group = new BasicGroup(TestConstants.anID, TestConstants.aName);
         ArgumentException expectedException = null;

         try
         {
            group.ID = string.Empty;
         }
         catch (ArgumentException e)
         {
            expectedException = e;
         }

         TestUtilities.checkException(expectedException, TestConstants.propID, TestConstants.paramID);
         Assert.AreEqual(TestConstants.anID, group.ID, false, "The ID should not change.");
      }

      [TestMethod]
      public void Group_ID_SetWhitespace()
      {
         BasicGroup group = new BasicGroup(TestConstants.anID, TestConstants.aName);
         ArgumentException expectedException = null;

         try
         {
            group.ID = TestConstants.whitespaceOnly;
         }
         catch (ArgumentException e)
         {
            expectedException = e;
         }

         TestUtilities.checkException(expectedException, TestConstants.propID, TestConstants.paramID);
         Assert.AreEqual(TestConstants.anID, group.ID, false, "The ID should not change.");
      }

      #endregion  ID Property Tests

      #region Name Property Tests
      [TestMethod]
      public void Group_Name_Set()
      {
         BasicGroup group = new BasicGroup(TestConstants.anID, TestConstants.aName);

         group.Name = TestConstants.newName;

         Assert.AreEqual(TestConstants.newName, group.Name, false);
      }

      [TestMethod]
      public void Group_Name_SetNull()
      {
         BasicGroup group = new BasicGroup(TestConstants.anID, TestConstants.aName);
         ArgumentException expectedException = null;

         try
         {
            group.Name = null;
         }
         catch (ArgumentException e)
         {
            expectedException = e;
         }

         TestUtilities.checkException(expectedException, TestConstants.propName, TestConstants.paramName);
         Assert.AreEqual(TestConstants.aName, group.Name, false, "The Name should not change.");
      }

      [TestMethod]
      public void Group_Name_SetEmpty()
      {
         BasicGroup group = new BasicGroup(TestConstants.anID, TestConstants.aName);
         ArgumentException expectedException = null;

         try
         {
            group.Name = string.Empty;
         }
         catch (ArgumentException e)
         {
            expectedException = e;
         }

         TestUtilities.checkException(expectedException, TestConstants.propName, TestConstants.paramName);
         Assert.AreEqual(TestConstants.aName, group.Name, false, "The Name should not change.");
      }

      [TestMethod]
      public void Group_Name_SetWhitespace()
      {
         BasicGroup group = new BasicGroup(TestConstants.anID, TestConstants.aName);
         ArgumentException expectedException = null;

         try
         {
            group.Name = TestConstants.whitespaceOnly;
         }
         catch (ArgumentException e)
         {
            expectedException = e;
         }

         TestUtilities.checkException(expectedException, TestConstants.propName, TestConstants.paramName);
         Assert.AreEqual(TestConstants.aName, group.Name, false, "The Name should not change.");
      }

      #endregion  Name Property Tests

      #region Properties Tests

      [TestMethod]
      public void Group_AddProperty()
      {
         BasicGroup targetGroup = new BasicGroup(TestConstants.anID, TestConstants.aName);
         BasicProperty aProperty = new BasicProperty(TestConstants.anID, TestConstants.aName);

         targetGroup.AddProperty(aProperty);

         TestUtilities.checkForSingleItem(targetGroup.Properties, aProperty, "Properties");
      }

      [TestMethod]
      public void Group_AddProperty_Null()
      {
         BasicGroup targetGroup = new BasicGroup(TestConstants.anID, TestConstants.aName);
         ArgumentNullException expectedException = null;

         try
         {
            targetGroup.AddProperty(null);
         }
         catch (ArgumentNullException e)
         {
            expectedException = e;
         }

         TestUtilities.checkException(expectedException, TestConstants.propProperty, TestConstants.paramProperty);
         TestUtilities.checkEmpty(targetGroup.Properties, "Properties");
      }

      [TestMethod]
      public void Group_AddProperty_Duplicate()
      {
         BasicGroup targetGroup = new BasicGroup(TestConstants.anID, TestConstants.aName);
         BasicProperty aProperty = new BasicProperty(TestConstants.anID, TestConstants.aName);
         ArgumentException expectedException = null;

         targetGroup.AddProperty(aProperty);

         try
         {
            targetGroup.AddProperty(aProperty);
         }
         catch (ArgumentException e)
         {
            expectedException = e;
         }

         TestUtilities.checkException(expectedException);
         TestUtilities.checkForSingleItem(targetGroup.Properties, aProperty, "Properties");
      }

      [TestMethod]
      public void Group_RemoveProperty()
      {
         BasicGroup targetGroup = new BasicGroup(TestConstants.anID, TestConstants.aName);
         BasicProperty aProperty = new BasicProperty(TestConstants.anID, TestConstants.aName);

         targetGroup.AddProperty(aProperty);
         targetGroup.RemoveProperty(aProperty);

         TestUtilities.checkEmpty(targetGroup.Properties, "Properties");
      }

      [TestMethod]
      public void Group_RemoveProperty_ByID()
      {
         BasicGroup targetGroup = new BasicGroup(TestConstants.anID, TestConstants.aName);
         BasicProperty aProperty = new BasicProperty(TestConstants.anID, TestConstants.aName);

         targetGroup.AddProperty(aProperty);
         targetGroup.RemoveProperty(TestConstants.anID);

         TestUtilities.checkEmpty(targetGroup.Properties, "Properties");
      }

      [TestMethod]
      public void Group_RemoveProperty_NullProperty()
      {
         BasicGroup targetGroup = new BasicGroup(TestConstants.anID, TestConstants.aName);
         ArgumentNullException expectedException = null;

         try
         {
            targetGroup.RemoveProperty((IProperty)null);
         }
         catch (ArgumentNullException e)
         {
            expectedException = e;
         }

         Assert.IsNotNull(expectedException, "ArgumentNullException not thrown");
         TestUtilities.checkEmpty(targetGroup.Properties, "Properties");
      }

      [TestMethod]
      public void Group_RemoveProperty_NullID()
      {
         BasicGroup targetGroup = new BasicGroup(TestConstants.anID, TestConstants.aName);
         ArgumentNullException expectedException = null;

         try
         {
            targetGroup.RemoveProperty((string)null);
         }
         catch (ArgumentNullException e)
         {
            expectedException = e;
         }

         TestUtilities.checkException(expectedException);
         TestUtilities.checkEmpty(targetGroup.Properties, "Properties");
      }

      [TestMethod]
      public void Group_RemoveProperty_NonexistentProperty()
      {
         BasicGroup targetGroup = new BasicGroup(TestConstants.anID, TestConstants.aName);
         BasicProperty aProperty = new BasicProperty(TestConstants.anID, TestConstants.aName);
         KeyNotFoundException expectedException = null;

         try
         {
            targetGroup.RemoveProperty(aProperty);
         }
         catch (KeyNotFoundException e)
         {
            expectedException = e;
         }

         Assert.IsNotNull(expectedException, "KeyNotFoundException not thrown");
         TestUtilities.checkEmpty(targetGroup.Properties, "Properties");
      }

      [TestMethod]
      public void Group_RemoveProperty_NonexistentID()
      {
         BasicGroup targetGroup = new BasicGroup(TestConstants.anID, TestConstants.aName);
         KeyNotFoundException expectedException = null;

         try
         {
            targetGroup.RemoveProperty(TestConstants.anID);
         }
         catch (KeyNotFoundException e)
         {
            expectedException = e;
         }

         Assert.IsNotNull(expectedException, "KeyNotFoundException not thrown");
         TestUtilities.checkEmpty(targetGroup.Properties, "Properties");
      }

      [TestMethod]
      [Description("Confirm that the properties are maintained in the order in which they are added.")]
      public void Group_IterateProperties()
      {
         BasicGroup targetGroup = new BasicGroup(TestConstants.anID, TestConstants.aName);
         BasicProperty propertyAA = new BasicProperty("AA", "AA");
         BasicProperty propertyBB = new BasicProperty("BB", "BB");
         BasicProperty propertyCC = new BasicProperty("CC", "CC");

         List<string> expectedIDs = new List<string>() { "CC", "BB", "AA" };

         targetGroup.AddProperty(propertyCC);
         targetGroup.AddProperty(propertyBB);
         targetGroup.AddProperty(propertyAA);

         List<string> actualIds = new List<string>();
         foreach (IProperty property in targetGroup.Properties)
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

      #region Groups Tests
      [TestMethod]
      public void Group_AddGroup()
      {
         BasicGroup targetGroup = new BasicGroup(TestConstants.anID, TestConstants.aName);
         BasicGroup subgroup = new BasicGroup("aa", "aa");

         targetGroup.AddGroup(subgroup);

         TestUtilities.checkForSingleItem(targetGroup.Groups, subgroup, "Groups");
      }

      [TestMethod]
      public void Group_AddGroup_Null()
      {
         BasicGroup targetGroup = new BasicGroup(TestConstants.anID, TestConstants.aName);
         ArgumentNullException expectedException = null;

         try
         {
            targetGroup.AddGroup(null);
         }
         catch (ArgumentNullException e)
         {
            expectedException = e;
         }

         TestUtilities.checkException(expectedException, TestConstants.propGroup, TestConstants.paramGroup);
         TestUtilities.checkEmpty(targetGroup.Groups, "Groups");
      }

      [TestMethod]
      public void Group_AddGroup_Duplicate()
      {
         BasicGroup targetGroup = new BasicGroup(TestConstants.anID, TestConstants.aName);
         BasicGroup subgroup = new BasicGroup("aa", "aa");
         ArgumentException expectedException = null;

         targetGroup.AddGroup(subgroup);

         try
         {
            targetGroup.AddGroup(subgroup);
         }
         catch (ArgumentException e)
         {
            expectedException = e;
         }

         TestUtilities.checkException(expectedException);
         TestUtilities.checkForSingleItem(targetGroup.Groups, subgroup, "Groups");
      }

      [TestMethod]
      public void Group_RemoveGroup()
      {
         BasicGroup targetGroup = new BasicGroup(TestConstants.anID, TestConstants.aName);
         BasicGroup subgroup = new BasicGroup("aa", "aa");

         targetGroup.AddGroup(subgroup);
         targetGroup.RemoveGroup(subgroup);

         TestUtilities.checkEmpty(targetGroup.Groups, "Groups");
      }

      [TestMethod]
      public void Group_RemoveGroup_ByID()
      {
         BasicGroup targetGroup = new BasicGroup(TestConstants.anID, TestConstants.aName);
         BasicGroup subgroup = new BasicGroup("aa", "aa");

         targetGroup.AddGroup(subgroup);
         targetGroup.RemoveGroup("aa");

         TestUtilities.checkEmpty(targetGroup.Groups, "Groups");
      }

      [TestMethod]
      public void Group_RemoveGroup_NullGroup()
      {
         BasicGroup targetGroup = new BasicGroup(TestConstants.anID, TestConstants.aName);
         ArgumentNullException expectedException = null;

         try
         {
            targetGroup.RemoveGroup((IGroup)null);
         }
         catch (ArgumentNullException e)
         {
            expectedException = e;
         }

         Assert.IsNotNull(expectedException, "ArgumentNullException not thrown");
         TestUtilities.checkEmpty(targetGroup.Groups, "Groups");
      }

      [TestMethod]
      public void Group_RemoveGroup_NullID()
      {
         BasicGroup targetGroup = new BasicGroup(TestConstants.anID, TestConstants.aName);
         ArgumentNullException expectedException = null;

         try
         {
            targetGroup.RemoveGroup((string)null);
         }
         catch (ArgumentNullException e)
         {
            expectedException = e;
         }

         TestUtilities.checkException(expectedException);
         TestUtilities.checkEmpty(targetGroup.Groups, "Groups");
      }

      [TestMethod]
      public void Group_RemoveGroup_NonexistentGroup()
      {
         BasicGroup targetGroup = new BasicGroup(TestConstants.anID, TestConstants.aName);
         BasicGroup subgroup = new BasicGroup("aa", "aa");
         KeyNotFoundException expectedException = null;

         try
         {
            targetGroup.RemoveGroup(subgroup);
         }
         catch (KeyNotFoundException e)
         {
            expectedException = e;
         }

         Assert.IsNotNull(expectedException, "KeyNotFoundException not thrown");
         TestUtilities.checkEmpty(targetGroup.Groups, "Groups");
      }

      [TestMethod]
      public void Group_RemoveGroup_NonexistentID()
      {
         BasicGroup targetGroup = new BasicGroup(TestConstants.anID, TestConstants.aName);
         KeyNotFoundException expectedException = null;

         try
         {
            targetGroup.RemoveGroup(TestConstants.anID);
         }
         catch (KeyNotFoundException e)
         {
            expectedException = e;
         }

         Assert.IsNotNull(expectedException, "KeyNotFoundException not thrown");
         TestUtilities.checkEmpty(targetGroup.Groups, "Groups");
      }

      [TestMethod]
      [Description("Confirm that the groups are maintained in the order in which they are added.")]
      public void Group_IterateGroups()
      {
         BasicGroup targetGroup = new BasicGroup(TestConstants.anID, TestConstants.aName);
         BasicGroup groupAA = new BasicGroup("AA", "AA");
         BasicGroup groupBB = new BasicGroup("BB", "BB");
         BasicGroup groupCC = new BasicGroup("CC", "CC");

         List<string> expectedIDs = new List<string>() { "CC", "BB", "AA" };

         targetGroup.AddGroup(groupCC);
         targetGroup.AddGroup(groupBB);
         targetGroup.AddGroup(groupAA);

         List<string> actualIds = new List<string>();
         foreach (IGroup group in targetGroup.Groups)
         {
            actualIds.Add(group.ID);
         }

         Assert.AreEqual(expectedIDs.Count, actualIds.Count);
         for (int i = 0; i < expectedIDs.Count; i++)
         {
            Assert.AreEqual(expectedIDs[i], actualIds[i]);
         }
      }

      #endregion Groups Tests
   }
}