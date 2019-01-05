using Microsoft.VisualStudio.TestTools.UnitTesting;
using Autodesk.PropertiesFramework.BasicProperties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Autodesk.PropertiesFramework.BasicPropertiesTests
{
   [TestClass]
   public class BooleanValueTests
   {
      #region Data Members
      BooleanValue _trueValue = null;
      BooleanValue _falseValue = null;
      BooleanValue _defaultValue = null;
      TestContext _testContext = null;
      #endregion

      public TestContext TestContext
      {
         get { return _testContext; }
         set { _testContext = value; }
      }

      #region Test Setup/Tear Down
      [TestInitialize]
      public void Setup()
      {
         _trueValue = new BooleanValue(true);
         _falseValue = new BooleanValue(false);
         _defaultValue = new BooleanValue();
      }

      [TestCleanup]
      public void TearDown()
      {
         _trueValue = null;
         _falseValue = null;
         _defaultValue = null;
      }
      #endregion Test Setup/Tear Down

      #region Construction Tests
      // test that a basic boolean value is properly created
      // with the default constructor
      [TestMethod]
      public void BooleanValue_Creation_Default()
      {
         // check the expected default values
         TestUtilities.checkDefaultPropertyValue(_defaultValue, DataType.Boolean);
      }

      [TestMethod]
      public void BooleanValue_Creation_True()
      {
         TestUtilities.checkValuedPropertyValue(_trueValue, DataType.Boolean);
         checkValue(_trueValue.Value, true);
      }

      [TestMethod]
      public void BooleanValue_Creation_False()
      {
         TestUtilities.checkValuedPropertyValue(_falseValue, DataType.Boolean);
         checkValue(_falseValue.Value, false);
      }
      #endregion Construction Tests

      #region Properties Tests
      [TestMethod]
      public void BooleanValue_ValueType()
      {
         Assert.AreEqual(DataType.Boolean, _trueValue.ValueType);
      }

      [TestMethod]
      public void BooleanValue_Value_Get()
      {
         checkValue(_trueValue.Value, true);
      }

      [TestMethod]
      public void BooleanValue_Value_Set_Boolean()
      {
         _trueValue.Value = false;
         checkValue(_trueValue.Value, false);
         _trueValue.Value = true;
         checkValue(_trueValue.Value, true);
      }

      [TestMethod]
      public void BooleanValue_Value_Set_Null()
      {
         ArgumentException expectedException = null;

         try
         {
            _trueValue.Value = null;
         }
         catch (ArgumentException e)
         {
            expectedException = e;
         }

         TestUtilities.checkException(expectedException, TestConstants.propValue, TestConstants.paramValue);
         checkValue(_trueValue.Value, true);
      }

      [TestMethod]
      public void BooleanValue_Value_Set_Integer()
      {
         _trueValue.Value = 0;
         checkValue(_trueValue.Value, false);

         _trueValue.Value = 1;
         checkValue(_trueValue.Value, true);

         _trueValue.Value = false;
         _trueValue.Value = -1;
         checkValue(_trueValue.Value, true);
      }

      [TestMethod]
      public void BooleanValue_Value_Set_Double()
      {
         _trueValue.Value = 0.0;
         checkValue(_trueValue.Value, false);

         _trueValue.Value = 99.99;
         checkValue(_trueValue.Value, true);

         _trueValue.Value = false;
         _trueValue.Value = -99.99;
         checkValue(_trueValue.Value, true);
      }

      [TestMethod]
      public void BooleanValue_Value_Set_ValidStrings()
      {
         _trueValue.Value = Boolean.FalseString;
         checkValue(_trueValue.Value, false);

         _trueValue.Value = Boolean.TrueString;
         checkValue(_trueValue.Value, true);
      }

      [TestMethod]
      public void BooleanValue_Value_Set_InvalidString()
      {
         FormatException expectedException = null;

         try
         {
            _trueValue.Value = "an invalid string";
         }
         catch (FormatException e)
         {
            expectedException = e;
         }

         Assert.IsNotNull(expectedException, "FormatException not thrown");
         checkValue(_trueValue.Value, true);
      }

      [TestMethod]
      public void BooleanValue_Value_Set_EmptyString()
      {
         FormatException expectedException = null;

         try
         {
            _trueValue.Value = string.Empty;
         }
         catch (FormatException e)
         {
            expectedException = e;
         }

         Assert.IsNotNull(expectedException, "FormatException not thrown");
         checkValue(_trueValue.Value, true);
      }

      [TestMethod]
      public void BooleanValue_IsIndeterminate_Set()
      {
         Assert.IsTrue(_defaultValue.IsIndeterminate, "The value should be indeterminate");
         Assert.IsNull(_defaultValue.Value, "The actual value should be null when IsIndeterminate is true");

         _defaultValue.IsIndeterminate = false;
         Assert.IsFalse(_defaultValue.IsIndeterminate, "The value should be determinate");
         Assert.IsNotNull(_defaultValue.Value, "The actual value should be not be null when IsIndeterminate is false");

         _defaultValue.IsIndeterminate = true;
         Assert.IsTrue(_defaultValue.IsIndeterminate, "The value should be indeterminate");
         Assert.IsNull(_defaultValue.Value, "The actual value should be null when IsIndeterminate is true");
      }

      [TestMethod]
      public void BooleanValue_IsVaries_Set()
      {
         Assert.IsFalse(_trueValue.IsVaries, "The value should not vary");
         Assert.IsNotNull(_trueValue.Value, "The actual value should not be null");

         _trueValue.IsVaries = true;
         Assert.IsTrue(_trueValue.IsVaries, "The value should vary");
         Assert.IsNull(_trueValue.Value, "The actual value should be null when IsVaries is true");

         _trueValue.IsVaries = false;
         Assert.IsFalse(_trueValue.IsVaries, "The value should not vary");
         Assert.IsNotNull(_trueValue.Value, "The actual value should not be null when IsVaries is false");
      }
      #endregion Properties Tests

      #region Conversion Tests
      [TestMethod]
      public void BooleanValue_AsBoolean()
      {
         Assert.IsTrue(_trueValue.AsBoolean());

         _trueValue.Value = false;
         Assert.IsFalse(_trueValue.AsBoolean());
      }

      [TestMethod]
      [ExpectedException(typeof(InvalidOperationException))]
      public void BooleanValue_AsBoolean_IsIndeterminate()
      {
         bool result = _defaultValue.AsBoolean();
      }

      [TestMethod]
      [ExpectedException(typeof(InvalidOperationException))]
      public void BooleanValue_AsBoolean_IsVaries()
      {
         _trueValue.IsVaries = true;
         bool result = _trueValue.AsBoolean();
      }

      [TestMethod]
      public void BooleanValue_AsInteger()
      {
         Assert.AreEqual(1, _trueValue.AsInteger());
         Assert.AreEqual(0, _falseValue.AsInteger());
      }

      [TestMethod]
      [ExpectedException(typeof(InvalidOperationException))]
      public void BooleanValue_AsInteger_IsIndeterminate()
      {
         int result = _defaultValue.AsInteger();
      }

      [TestMethod]
      [ExpectedException(typeof(InvalidOperationException))]
      public void BooleanValue_AsInteger_IsVaries()
      {
         _trueValue.IsVaries = true;
         int result = _trueValue.AsInteger();
      }

      [TestMethod]
      public void BooleanValue_AsDouble()
      {
         Assert.AreEqual(1.0, _trueValue.AsDouble());
         Assert.AreEqual(0.0, _falseValue.AsDouble());
      }

      [TestMethod]
      [ExpectedException(typeof(InvalidOperationException))]
      public void BooleanValue_AsDouble_IsIndeterminate()
      {
         double result = _defaultValue.AsDouble();
      }

      [TestMethod]
      [ExpectedException(typeof(InvalidOperationException))]
      public void BooleanValue_AsDouble_IsVaries()
      {
         _trueValue.IsVaries = true;
         double result = _trueValue.AsDouble();
      }

      [TestMethod]
      public void BooleanValue_AsString()
      {
         Assert.AreEqual(Boolean.TrueString, _trueValue.AsString());
         Assert.AreEqual(Boolean.FalseString, _falseValue.AsString());
      }

      [TestMethod]
      [ExpectedException(typeof(InvalidOperationException))]
      public void BooleanValue_AsString_IsIndeterminate()
      {
         string result = _defaultValue.AsString();
      }

      [TestMethod]
      public void BooleanValue_AsString_IsVaries()
      {
         _trueValue.IsVaries = true;

         Assert.AreEqual("varies", _trueValue.AsString());
      }
      #endregion Conversion Tests

      #region Comparison Tests
      [TestMethod]
      public void BooleanValue_IsEqual_True()
      {
         // reference equality
         Assert.IsTrue(_trueValue.IsEqual(_trueValue));
         Assert.IsTrue(_falseValue.IsEqual(_falseValue));
         Assert.IsTrue(_defaultValue.IsEqual(_defaultValue));

         BooleanValue anotherValue = new BooleanValue(true);
         Assert.IsTrue(_trueValue.IsEqual(anotherValue));
         anotherValue.Value = false;
         Assert.IsTrue(_falseValue.IsEqual(anotherValue));
         anotherValue.IsVaries = true;
         _trueValue.IsVaries = true;
         Assert.IsTrue(_trueValue.IsEqual(anotherValue));
         anotherValue.IsIndeterminate = true;
         Assert.IsTrue(_defaultValue.IsEqual(anotherValue));
      }

      [TestMethod]
      public void BooleanValue_IsEqual_False()
      {
         Assert.IsFalse(_trueValue.IsEqual(_falseValue));
         Assert.IsFalse(_falseValue.IsEqual(_trueValue));
         Assert.IsFalse(_trueValue.IsEqual(_defaultValue));

         BooleanValue anotherValue = new BooleanValue(true);
         anotherValue.IsVaries = true;
         Assert.IsFalse(_trueValue.IsEqual(anotherValue));
      }

      [TestMethod]
      public void BooleanValue_IsSameType()
      {
         Assert.IsTrue(_trueValue.IsSameType(_defaultValue));
      }

      [TestMethod]
      public void BooleanValue_CompareTo_ReferenceEquality()
      {
         Assert.IsTrue(_trueValue.CompareTo(_trueValue) == 0);
      }

      [TestMethod]
      public void BooleanValue_CompareTo_Null()
      {
         Assert.IsTrue(_trueValue.CompareTo(null) > 0);
      }

      [TestMethod]
      public void BooleanValue_CompareTo_True_False()
      {
         Assert.IsTrue(_trueValue.CompareTo(_falseValue) > 0);
      }

      [TestMethod]
      public void BooleanValue_CompareTo_False_True()
      {
         Assert.IsTrue(_falseValue.CompareTo(_trueValue) < 0);
      }

      [TestMethod]
      public void BooleanValue_CompareTo_Indeterminate_Indeterminate()
      {
         _trueValue.IsIndeterminate = true;
         Assert.IsTrue(_trueValue.CompareTo(_defaultValue) == 0);
      }

      [TestMethod]
      public void BooleanValue_CompareTo_Indeterminate_True()
      {
         Assert.IsTrue(_defaultValue.CompareTo(_trueValue) < 0);
      }

      [TestMethod]
      public void BooleanValue_CompareTo_True_Indeterminate()
      {
         Assert.IsTrue(_trueValue.CompareTo(_defaultValue) > 0);
      }

      [TestMethod]
      public void BooleanValue_CompareTo_Varies_Varies()
      {
         _trueValue.IsVaries = true;
         _falseValue.IsVaries = true;
         Assert.IsTrue(_trueValue.CompareTo(_falseValue) == 0);
      }

      [TestMethod]
      public void BooleanValue_CompareTo_Varies_True()
      {
         BooleanValue variesValue = new BooleanValue(true);
         variesValue.IsVaries = true;

         Assert.IsTrue(variesValue.CompareTo(_trueValue) < 0);
      }

      [TestMethod]
      public void BooleanValue_CompareTo_True_Varies()
      {
         BooleanValue variesValue = new BooleanValue(true);
         variesValue.IsVaries = true;

         Assert.IsTrue(_trueValue.CompareTo(variesValue) > 0);
      }

      [TestMethod]
      public void BooleanValue_CompareTo_SystemBooleanType()
      {
         Assert.IsTrue(_trueValue.CompareTo(true) == 0);
         Assert.IsTrue(_trueValue.CompareTo(false) > 0);
         Assert.IsTrue(_falseValue.CompareTo(true) < 0);
         Assert.IsTrue(_falseValue.CompareTo(false) == 0);
      }

      [TestMethod]
      [ExpectedException(typeof(ArgumentException))]
      public void BooleanValue_CompareTo_Integer()
      {
         Assert.IsTrue(_trueValue.CompareTo(99) == 0);
      }

      [TestMethod]
      [ExpectedException(typeof(ArgumentException))]
      public void BooleanValue_CompareTo_String()
      {
         Assert.IsTrue(_trueValue.CompareTo(Boolean.TrueString) == 0);
      }
      #endregion Comparison Tests

      #region Helper Methods
      private void checkValue(object theValue, bool expectedValue)
      {
         Assert.AreEqual(expectedValue, 
                         theValue, 
                         string.Format("Value should be {0}", expectedValue ? Boolean.TrueString : Boolean.FalseString));
         Assert.AreEqual("System.Boolean", theValue.GetType().FullName);
      }
      #endregion Helper Methods

   }
}