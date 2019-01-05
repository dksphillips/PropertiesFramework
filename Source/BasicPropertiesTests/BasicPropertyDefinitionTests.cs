using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Autodesk.PropertiesFramework;
using Autodesk.PropertiesFramework.BasicProperties;

namespace Autodesk.PropertiesFramework.BasicPropertiesTests
{
   [TestClass]
   public class BasicPropertyDefinitionTests
   {
      #region Construction Tests

      // test that a basic property definition is properly created
      // with the default constructor
      [TestMethod]
      public void PropertyDefinition_Creation_Default()
      {
         BasicPropertyDefinition def = new BasicPropertyDefinition();

         // check the expected default values
         TestUtilities.checkDefaultPropertyDefinition(def);
      }

      // test that a basic property definition is properly created
      [TestMethod]
      public void PropertyDefinition_Creation_Valid()
      {
         BasicPropertyDefinition def = new BasicPropertyDefinition(TestConstants.anID, TestConstants.aName);

         Assert.AreEqual(TestConstants.anID, def.ID, false);
         Assert.AreEqual(TestConstants.aName, def.Name, false);
      }

      [TestMethod]
      public void PropertyDefinition_Creation_Invalid_NullID()
      {
         BasicPropertyDefinition def = null;
         ArgumentException expectedException = null;

         try
         {
            def = new BasicPropertyDefinition(null, TestConstants.aName);
         }
         catch (ArgumentException e)
         {
            expectedException = e;
         }

         TestUtilities.checkException(expectedException, TestConstants.propID, TestConstants.paramID);
         Assert.IsNull(def, "No property definition should be created.");
      }

      [TestMethod]
      public void PropertyDefinition_Creation_Invalid_EmptyID()
      {
         BasicPropertyDefinition def = null;
         ArgumentException expectedException = null;

         try
         {
            def = new BasicPropertyDefinition(string.Empty, TestConstants.aName);
         }
         catch (ArgumentException e)
         {
            expectedException = e;
         }

         TestUtilities.checkException(expectedException, TestConstants.propID, TestConstants.paramID);
         Assert.IsNull(def, "No property definition should be created.");
      }

      [TestMethod]
      public void PropertyDefinition_Creation_Invalid_WhitespaceID()
      {
         BasicPropertyDefinition def = null;
         ArgumentException expectedException = null;

         try
         {
            def = new BasicPropertyDefinition(TestConstants.whitespaceOnly, TestConstants.aName);
         }
         catch (ArgumentException e)
         {
            expectedException = e;
         }

         TestUtilities.checkException(expectedException, TestConstants.propID, TestConstants.paramID);
         Assert.IsNull(def, "No property definition should be created.");
      }

      [TestMethod]
      public void PropertyDefinition_Creation_Invalid_NullName()
      {
         BasicPropertyDefinition def = null;
         ArgumentException expectedException = null;

         try
         {
            def = new BasicPropertyDefinition(TestConstants.anID, null);
         }
         catch (ArgumentException e)
         {
            expectedException = e;
         }

         TestUtilities.checkException(expectedException, TestConstants.propName, TestConstants.paramName);
         Assert.IsNull(def, "No property definition should be created.");
      }

      [TestMethod]
      public void PropertyDefinition_Creation_Invalid_EmptyName()
      {
         BasicPropertyDefinition def = null;
         ArgumentException expectedException = null;

         try
         {
            def = new BasicPropertyDefinition(TestConstants.anID, string.Empty);
         }
         catch (ArgumentException e)
         {
            expectedException = e;
         }

         TestUtilities.checkException(expectedException, TestConstants.propName, TestConstants.paramName);
         Assert.IsNull(def, "No property definition should be created.");
      }

      [TestMethod]
      public void PropertyDefinition_Creation_Invalid_WhitespaceName()
      {
         BasicPropertyDefinition def = null;
         ArgumentException expectedException = null;

         try
         {
            def = new BasicPropertyDefinition(TestConstants.anID, TestConstants.whitespaceOnly);
         }
         catch (ArgumentException e)
         {
            expectedException = e;
         }

         TestUtilities.checkException(expectedException, TestConstants.propName, TestConstants.paramName);
         Assert.IsNull(def, "No property definition should be created.");
      }

      #endregion  Construction Tests

      #region ID Property Tests
      [TestMethod]
      public void PropertyDefinition_ID_Set()
      {
         BasicPropertyDefinition def = new BasicPropertyDefinition(TestConstants.anID, 
                                                                   TestConstants.aName);

         def.ID = TestConstants.newID;

         Assert.AreEqual(TestConstants.newID, def.ID, false);
      }

      [TestMethod]
      public void PropertyDefinition_ID_SetNull()
      {
         BasicPropertyDefinition def = new BasicPropertyDefinition(TestConstants.anID,
                                                                   TestConstants.aName);
         ArgumentException expectedException = null;

         try
         {
            def.ID = null;
         }
         catch (ArgumentException e)
         {
            expectedException = e;
         }

         TestUtilities.checkException(expectedException, TestConstants.propID, TestConstants.paramID);
         Assert.AreEqual(TestConstants.anID, def.ID, false, "The ID should not change.");
      }

      [TestMethod]
      public void PropertyDefinition_ID_SetEmpty()
      {
         BasicPropertyDefinition def = new BasicPropertyDefinition(TestConstants.anID, 
                                                                   TestConstants.aName);
         ArgumentException expectedException = null;

         try
         {
            def.ID = string.Empty;
         }
         catch (ArgumentException e)
         {
            expectedException = e;
         }

         TestUtilities.checkException(expectedException, TestConstants.propID, TestConstants.paramID);
         Assert.AreEqual(TestConstants.anID, def.ID, false, "The ID should not change.");
      }

      [TestMethod]
      public void PropertyDefinition_ID_SetWhitespace()
      {
         BasicPropertyDefinition def = new BasicPropertyDefinition(TestConstants.anID, 
                                                                   TestConstants.aName);
         ArgumentException expectedException = null;

         try
         {
            def.ID = TestConstants.whitespaceOnly;
         }
         catch (ArgumentException e)
         {
            expectedException = e;
         }

         TestUtilities.checkException(expectedException, TestConstants.propID, TestConstants.paramID);
         Assert.AreEqual(TestConstants.anID, def.ID, false, "The ID should not change.");
      }

      #endregion  ID Property Tests

      #region Name Property Tests
      [TestMethod]
      public void PropertyDefinition_Name_Set()
      {
         BasicPropertyDefinition def = new BasicPropertyDefinition(TestConstants.anID, 
                                                                   TestConstants.aName);

         def.Name = TestConstants.newName;

         Assert.AreEqual(TestConstants.newName, def.Name, false);
      }

      [TestMethod]
      public void PropertyDefinition_Name_SetNull()
      {
         BasicPropertyDefinition def = new BasicPropertyDefinition(TestConstants.anID, 
                                                                   TestConstants.aName);
         ArgumentException expectedException = null;

         try
         {
            def.Name = null;
         }
         catch (ArgumentException e)
         {
            expectedException = e;
         }

         TestUtilities.checkException(expectedException, TestConstants.propName, TestConstants.paramName);
         Assert.AreEqual(TestConstants.aName, def.Name, false, "The Name should not change.");
      }

      [TestMethod]
      public void PropertyDefinition_Name_SetEmpty()
      {
         BasicPropertyDefinition def = new BasicPropertyDefinition(TestConstants.anID, 
                                                                   TestConstants.aName);
         ArgumentException expectedException = null;

         try
         {
            def.Name = string.Empty;
         }
         catch (ArgumentException e)
         {
            expectedException = e;
         }

         TestUtilities.checkException(expectedException, TestConstants.propName, TestConstants.paramName);
         Assert.AreEqual(TestConstants.aName, def.Name, false, "The Name should not change.");
      }

      [TestMethod]
      public void PropertyDefinition_Name_SetWhitespace()
      {
         BasicPropertyDefinition def = new BasicPropertyDefinition(TestConstants.anID, 
                                                                   TestConstants.aName);
         ArgumentException expectedException = null;

         try
         {
            def.Name = TestConstants.whitespaceOnly;
         }
         catch (ArgumentException e)
         {
            expectedException = e;
         }

         TestUtilities.checkException(expectedException, TestConstants.propName, TestConstants.paramName);
         Assert.AreEqual(TestConstants.aName, def.Name, false, "The Name should not change.");
      }

      #endregion  Name Property Tests

      #region DataType Property Tests
      [TestMethod]
      public void PropertyDefinition_DataType_Set()
      {
         BasicPropertyDefinition def = new BasicPropertyDefinition(TestConstants.anID, 
                                                                   TestConstants.aName);

         // test the default value
         Assert.AreEqual(DataType.String, def.DataType);

         def.DataType = DataType.Boolean;
         Assert.AreEqual(DataType.Boolean, def.DataType);

         def.DataType = DataType.Double;
         Assert.AreEqual(DataType.Double, def.DataType);

         def.DataType = DataType.Enum;
         Assert.AreEqual(DataType.Enum, def.DataType);

         def.DataType = DataType.Integer;
         Assert.AreEqual(DataType.Integer, def.DataType);

         def.DataType = DataType.Undefined;
         Assert.AreEqual(DataType.Undefined, def.DataType);

         def.DataType = DataType.String;
         Assert.AreEqual(DataType.String, def.DataType);
      }

      [TestMethod]
      public void PropertyDefinition_DataType_SetInvalid()
      {
         BasicPropertyDefinition def = new BasicPropertyDefinition(TestConstants.anID,
                                                                   TestConstants.aName);
         ArgumentOutOfRangeException expectedException = null;

         try
         {
            def.DataType = (DataType)(-1);
         }
         catch (ArgumentOutOfRangeException e)
         {
            expectedException = e;
         }

         TestUtilities.checkException(expectedException, TestConstants.propDataType, TestConstants.paramDataType);
         Assert.AreEqual(DataType.String, def.DataType, "The DataType should not change.");
      }
      #endregion  DataType Property Tests

      #region ControlType Property Tests
      [TestMethod]
      public void PropertyDefinition_ControlType_Set()
      {
         BasicPropertyDefinition def = new BasicPropertyDefinition(TestConstants.anID,
                                                                   TestConstants.aName);

         // test the default value
         Assert.AreEqual(ControlType.Default, def.ControlType);

         def.ControlType = ControlType.Browse;
         Assert.AreEqual(ControlType.Browse, def.ControlType);

         def.ControlType = ControlType.Button;
         Assert.AreEqual(ControlType.Button, def.ControlType);

         def.ControlType = ControlType.Checkbox;
         Assert.AreEqual(ControlType.Checkbox, def.ControlType);

         def.ControlType = ControlType.Combo;
         Assert.AreEqual(ControlType.Combo, def.ControlType);

         def.ControlType = ControlType.Custom;
         Assert.AreEqual(ControlType.Custom, def.ControlType);

         def.ControlType = ControlType.Edit;
         Assert.AreEqual(ControlType.Edit, def.ControlType);

         def.ControlType = ControlType.EditBrowse;
         Assert.AreEqual(ControlType.EditBrowse, def.ControlType);

         def.ControlType = ControlType.EditCombo;
         Assert.AreEqual(ControlType.EditCombo, def.ControlType);

         def.ControlType = ControlType.Image;
         Assert.AreEqual(ControlType.Image, def.ControlType);

         def.ControlType = ControlType.NumericSpin;
         Assert.AreEqual(ControlType.NumericSpin, def.ControlType);

         def.ControlType = ControlType.Undefined;
         Assert.AreEqual(ControlType.Undefined, def.ControlType);
      }

      [TestMethod]
      public void PropertyDefinition_ControlType_SetInvalid()
      {
         BasicPropertyDefinition def = new BasicPropertyDefinition(TestConstants.anID,
                                                                   TestConstants.aName);
         ArgumentOutOfRangeException expectedException = null;

         try
         {
            def.ControlType = (ControlType)(-1);
         }
         catch (ArgumentOutOfRangeException e)
         {
            expectedException = e;
         }

         TestUtilities.checkException(expectedException, TestConstants.propControlType, TestConstants.paramControlType);
         Assert.AreEqual(ControlType.Default, def.ControlType, "The ControlType should not change.");
      }
      #endregion  ControlType Property Tests

      #region ReadOnly Property Tests
      [TestMethod]
      public void PropertyDefinition_ReadOnly_Set()
      {
         BasicPropertyDefinition def = new BasicPropertyDefinition(TestConstants.anID,
                                                                   TestConstants.aName);

         // test the default value
         Assert.IsFalse(def.ReadOnly, "Default value for the ReadOnly property should be false.");

         def.ReadOnly = true;
         Assert.IsTrue(def.ReadOnly, "Set ReadOnly property true failed.");

         // and set it back to false
         def.ReadOnly = false;
         Assert.IsFalse(def.ReadOnly, "Set ReadOnly property false failed.");
      }
      #endregion  ReadOnly Property Tests

      #region ToolTip Property Tests
      [TestMethod]
      public void PropertyDefinition_ToolTip_Set()
      {
         BasicPropertyDefinition def = new BasicPropertyDefinition(TestConstants.anID,
                                                                   TestConstants.aName);

         // test the default value
         Assert.AreEqual(string.Empty, def.ToolTip);

         // a tool tip can be just about anything, as long is it
         // supports ToString
         def.ToolTip = "fake tooltip";
         Assert.AreEqual("fake tooltip", def.ToolTip);

         def.ToolTip = null;
         Assert.IsNull(def.ToolTip);

         def.ToolTip = 100;
         Assert.AreEqual(100, def.ToolTip);
      }
      #endregion  ToolTip Property Tests

      #region Formatter Property Tests
      [TestMethod]
      public void PropertyDefinition_Formatter_Set()
      {
         BasicPropertyDefinition def = new BasicPropertyDefinition(TestConstants.anID,
                                                                   TestConstants.aName);

         // test the default value
         Assert.IsNull(def.Formatter, "Default value for Formatter property should be null.");

         FakeFormatter fake = new FakeFormatter();
         def.Formatter = fake;
         Assert.AreEqual(fake, def.Formatter);

         // and set it back to null
         def.Formatter = null;
         Assert.IsNull(def.Formatter, "Set Formatter property to null failed.");
      }
      #endregion  Formatter Property Tests

      #region Validator Property Tests
      [TestMethod]
      public void PropertyDefinition_Validator_Set()
      {
         BasicPropertyDefinition def = new BasicPropertyDefinition(TestConstants.anID,
                                                                   TestConstants.aName);

         // test the default value
         Assert.IsNull(def.Validator, "Default value for Validator property should be null.");

         FakeValidator fake = new FakeValidator();
         def.Validator = fake;
         Assert.AreEqual(fake, def.Validator);

         // and set it back to null
         def.Validator = null;
         Assert.IsNull(def.Validator, "Set Validator property to null failed.");
      }
      #endregion  Validator Property Tests

      #region CustomControl Property Tests
      [TestMethod]
      public void PropertyDefinition_CustomControl_Set()
      {
         BasicPropertyDefinition def = new BasicPropertyDefinition(TestConstants.anID,
                                                                   TestConstants.aName);

         // test the default value
         Assert.IsNull(def.CustomControl, "Default value for CustomControl property should be null.");

         FakeCustomControl fake = new FakeCustomControl();
         def.CustomControl = fake;
         Assert.AreEqual(fake, def.CustomControl);

         // and set it back to null
         def.CustomControl = null;
         Assert.IsNull(def.CustomControl, "Set CustomControl property to null failed.");
      }
      #endregion  CustomControl Property Tests
   }

   #region Fakes
   internal class FakeFormatter : IFormatter
   {
      public string format(IDataValue value)
      {
         return "fake value";
      }
   }

   internal class FakeValidator : IValidator
   {
      public ValidityResult validate(IDataValue value) { return ValidityResult.Valid; }
      public void displayMessage(IDataValue value, ValidityResult result) { }
      public string validationMessage { get { return string.Empty; } }
   }

   internal class FakeCustomControl : IControlContentProvider
   {
      public IProperty Property { get { return null; } }
   }

   #endregion  Fakes
}
