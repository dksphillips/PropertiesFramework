using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Autodesk.PropertiesFramework;
using Autodesk.PropertiesFramework.BasicProperties;


namespace Autodesk.PropertiesFramework.BasicPropertiesTests
{
   [TestClass]
   public class BasicPropertyTests
   {
      #region Construction Tests

      // test that a basic property is properly created
      // with the default constructor
      [TestMethod]
      public void Property_Creation_Default()
      {
         BasicProperty prop = new BasicProperty();

         // check the default values
         Assert.IsNotNull(prop.Definition, 
                           "BasicProperty default constructor should create a default property definition.");
         Assert.IsNull(prop.Value,
                       "BasicProperty default construction should not have a value.");
         TestUtilities.checkDefaultPropertyDefinition(prop.Definition);
      }

      // test that a basic property definition is properly created
      [TestMethod]
      public void Property_Creation_ValidNameAndID()
      {
         BasicProperty prop = new BasicProperty(TestConstants.anID, TestConstants.aName);

         Assert.IsNotNull(prop.Definition,
                          "BasicProperty constructor should create a property definition.");
         Assert.AreEqual(TestConstants.anID, prop.Definition.ID);
         Assert.AreEqual(TestConstants.aName, prop.Definition.Name);
         Assert.IsNull(prop.Value,
                       "BasicProperty default construction should not have a value.");
      }

      [TestMethod]
      public void Property_Creation_ValidDefinition()
      {
         BasicPropertyDefinition fakeDef = new BasicPropertyDefinition("fakeId", "fakeName");
         BasicProperty prop = new BasicProperty(fakeDef);

         Assert.AreEqual(fakeDef, prop.Definition);
         Assert.IsInstanceOfType(prop.Definition, fakeDef.GetType());
      }

      [TestMethod]
      public void Property_Creation_NullDefinition()
      {
         BasicProperty prop = null;
         ArgumentException expectedException = null;

         try
         {
            prop = new BasicProperty(null);
         }
         catch (ArgumentException e)
         {
            expectedException = e;
         }

         TestUtilities.checkException(expectedException, TestConstants.propDefinition, TestConstants.paramDefinition);
         Assert.IsNull(prop, "No property should be created.");
      }

      [TestMethod]
      public void Property_Creation_Invalid_NullID()
      {
         createInvalidProperty(null, TestConstants.aName, TestConstants.propID, TestConstants.paramID);
      }

      [TestMethod]
      public void Property_Creation_Invalid_EmptyID()
      {
         createInvalidProperty(string.Empty, TestConstants.aName, TestConstants.propID, TestConstants.paramID);
      }

      [TestMethod]
      public void Property_Creation_Invalid_WhitespaceID()
      {
         createInvalidProperty(TestConstants.whitespaceOnly, TestConstants.aName, TestConstants.propID, TestConstants.paramID);
      }

      [TestMethod]
      public void Property_Creation_Invalid_NullName()
      {
         createInvalidProperty(TestConstants.anID, null, TestConstants.propName, TestConstants.paramName);
      }

      [TestMethod]
      public void Property_Creation_Invalid_EmptyName()
      {
         createInvalidProperty(TestConstants.anID, string.Empty, TestConstants.propName, TestConstants.paramName);
      }

      [TestMethod]
      public void Property_Creation_Invalid_WhitespaceName()
      {
         createInvalidProperty(TestConstants.anID, TestConstants.whitespaceOnly, TestConstants.propName, TestConstants.paramName);
      }

      [TestMethod]
      public void Property_Creation_ValidDefinitionAndNullValue()
      {
         BasicPropertyDefinition fakeDef = new BasicPropertyDefinition("fakeId", "fakeName");
         BasicProperty prop = new BasicProperty(fakeDef, null);

         Assert.AreEqual(fakeDef, prop.Definition);
         Assert.IsInstanceOfType(prop.Definition, fakeDef.GetType());
         Assert.IsNull(prop.Value);
      }

      [TestMethod]
      public void Property_Creation_ValidDefinitionAndValue()
      {
         BasicPropertyDefinition fakeDef = new BasicPropertyDefinition("fakeId", "fakeName");
         FakeValue fakeValue = new FakeValue();
         BasicProperty prop = new BasicProperty(fakeDef, fakeValue);

         Assert.AreEqual(fakeDef, prop.Definition);
         Assert.AreEqual(fakeValue, prop.Value);
         Assert.IsInstanceOfType(prop.Definition, fakeDef.GetType());
         Assert.IsInstanceOfType(prop.Value, fakeValue.GetType());
      }

      #endregion Construction Tests

      #region Definition Property Tests
      [TestMethod]
      public void Property_Definition_Set()
      {
         BasicPropertyDefinition fakeDef = new BasicPropertyDefinition("fakeId", "fakeName");
         BasicProperty prop = new BasicProperty();

         prop.Definition = fakeDef;

         Assert.AreEqual(fakeDef, prop.Definition);
      }

      [TestMethod]
      public void Property_Definition_SetNull()
      {
         BasicProperty prop = new BasicProperty();
         ArgumentException expectedException = null;

         try
         {
            prop.Definition = null;
         }
         catch (ArgumentException e)
         {
            expectedException = e;
         }

         TestUtilities.checkException(expectedException, TestConstants.propDefinition, TestConstants.paramDefinition);
      }
      #endregion Definition Property Tests

      #region Value Property Tests
      [TestMethod]
      public void Property_Value_Set()
      {
         FakeValue fakeValue = new FakeValue();
         BasicProperty prop = new BasicProperty();

         prop.Value = fakeValue;

         Assert.AreEqual(fakeValue, prop.Value);
         Assert.IsInstanceOfType(prop.Value, fakeValue.GetType());
      }
      #endregion Value Property Tests

      #region Helper Utilities
      public void createInvalidProperty(string id, string name, string propertyToTest, string parameterToTest)
      {
         BasicProperty prop = null;
         ArgumentException expectedException = null;

         try
         {
            prop = new BasicProperty(id, name);
         }
         catch (ArgumentException e)
         {
            expectedException = e;
         }

         TestUtilities.checkException(expectedException, propertyToTest, parameterToTest);
         Assert.IsNull(prop, "No property should be created.");
      }
      #endregion Helper Utilities

      #region Fakes
      internal class FakeValue : IDataValue
      {
         public object Value
         {
            get { return null; }
            set { }
         }
         public DataType ValueType { get { return DataType.Undefined; } }
         public bool IsIndeterminate { get { return true; } }

         // for when a property represents a collection of unequal values
         public bool IsVaries { get { return false; } }
         public bool AsBoolean() { return false; }
         public Int32 AsInteger() { return Convert.ToInt32(AsBoolean()); }
         public Int32 AsEnum() { return AsInteger();  }
         public double AsDouble() { return Convert.ToDouble(AsBoolean()); }
         public String AsString() { return AsBoolean().ToString(); }
         public bool IsEqual(IDataValue other) { return false; }
         public bool IsSameType(IDataValue other) { return false; }
      }
      #endregion Fakes

   }
}