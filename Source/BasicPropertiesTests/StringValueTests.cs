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
   public class StringValueTests
   {
      #region Data Members
      StringValue _testValue = null;
      StringValue _emptyTestValue = null;
      StringValue _defaultValue = null;
      TestContext _testContext = null;

      public const string aTestString = "aaa";
      public const string anIntegerString = "100";
      public const string anDoubleString = "99.99";
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
         _testValue = new StringValue(aTestString);
         _emptyTestValue = new StringValue(string.Empty);
         _defaultValue = new StringValue();
      }

      [TestCleanup]
      public void TearDown()
      {
         _testValue = null;
         _emptyTestValue = null;
         _defaultValue = null;
      }
      #endregion Test Setup/Tear Down

      #region Construction Tests
      // test that a basic boolean value is properly created
      // with the default constructor
      [TestMethod]
      public void StringValue_Creation_Default()
      {
         // check the expected default values
         TestUtilities.checkDefaultPropertyValue(_defaultValue, DataType.String);
      }

      [TestMethod]
      public void StringValue_Creation_Nonempty()
      {
         TestUtilities.checkValuedPropertyValue(_testValue, DataType.String);
         checkValue(_testValue.Value, aTestString);
      }

      [TestMethod]
      public void StringValue_Creation_Empty()
      {
         TestUtilities.checkValuedPropertyValue(_emptyTestValue, DataType.String);
         checkValue(_emptyTestValue.Value, string.Empty);
      }
      #endregion Construction Tests

      #region Properties Tests
      [TestMethod]
      public void StringValue_ValueType()
      {
         Assert.AreEqual(DataType.String, _testValue.ValueType);
      }

      [TestMethod]
      public void StringValue_Value_Get()
      {
         checkValue(_testValue.Value, aTestString);
         checkValue(_emptyTestValue.Value, string.Empty);
      }

      [TestMethod]
      public void BooleanValue_Value_Set_String()
      {
         _testValue.Value = "bbb";
         checkValue(_testValue.Value, "bbb");
      }

      [TestMethod]
      public void StringValue_Value_Set_Null()
      {
         ArgumentException expectedException = null;

         try
         {
            _testValue.Value = null;
         }
         catch (ArgumentException e)
         {
            expectedException = e;
         }

         TestUtilities.checkException(expectedException, TestConstants.propValue, TestConstants.paramValue);
         checkValue(_testValue.Value, aTestString);
      }

      [TestMethod]
      public void StringValue_Value_Set_Boolean()
      {
         _testValue.Value = true;
         checkValue(_testValue.Value, Convert.ToString(true));

         _testValue.Value = false;
         checkValue(_testValue.Value, Convert.ToString(false));
      }

      [TestMethod]
      public void StringValue_Value_Set_Integer()
      {
         int intValue = 100;
         _testValue.Value = intValue;
         checkValue(_testValue.Value, intValue.ToString());
      }

      [TestMethod]
      public void StringValue_Value_Set_Double()
      {
         double dblValue = 99.99;
         _testValue.Value = dblValue;
         checkValue(_testValue.Value, dblValue.ToString());
      }

      [TestMethod]
      public void StringValue_IsIndeterminate_Set()
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
      public void StringValue_IsVaries_Set()
      {
         Assert.IsFalse(_testValue.IsVaries, "The value should not vary");
         Assert.IsNotNull(_testValue.Value, "The actual value should not be null");

         _testValue.IsVaries = true;
         Assert.IsTrue(_testValue.IsVaries, "The value should vary");
         Assert.IsNull(_testValue.Value, "The actual value should be null when IsVaries is true");

         _testValue.IsVaries = false;
         Assert.IsFalse(_testValue.IsVaries, "The value should not vary");
         Assert.IsNotNull(_testValue.Value, "The actual value should not be null when IsVaries is false");
      }
      #endregion Properties Tests

      #region Conversion Tests
      [TestMethod]
      public void StringValue_AsBoolean_ValidStrings()
      {
         _testValue.Value = Boolean.TrueString;
         Assert.IsTrue(_testValue.AsBoolean());

         _testValue.Value = Boolean.FalseString;
         Assert.IsFalse(_testValue.AsBoolean());
      }

      [TestMethod]
      [ExpectedException(typeof(FormatException))]
      public void StringValue_AsBoolean_InvalidString()
      {
         Assert.IsTrue(_testValue.AsBoolean());
      }

      [TestMethod]
      [ExpectedException(typeof(InvalidOperationException))]
      public void StringValue_AsBoolean_IsIndeterminate()
      {
         bool result = _defaultValue.AsBoolean();
      }

      [TestMethod]
      [ExpectedException(typeof(InvalidOperationException))]
      public void StringValue_AsBoolean_IsVaries()
      {
         _testValue.IsVaries = true;
         bool result = _testValue.AsBoolean();
      }

      [TestMethod]
      public void StringValue_AsInteger_ValidString()
      {
         _testValue.Value = "100";
         Assert.AreEqual(100, _testValue.AsInteger());
      }

      [TestMethod]
      [ExpectedException(typeof(FormatException))]
      public void StringValue_AsInteger_InvalidString()
      {
         Assert.IsInstanceOfType(_testValue.AsInteger(), typeof(Int32));
      }

      [TestMethod]
      [ExpectedException(typeof(InvalidOperationException))]
      public void StringValue_AsInteger_IsIndeterminate()
      {
         int result = _defaultValue.AsInteger();
      }

      [TestMethod]
      [ExpectedException(typeof(InvalidOperationException))]
      public void StringValue_AsInteger_IsVaries()
      {
         _testValue.IsVaries = true;
         int result = _testValue.AsInteger();
      }

      [TestMethod]
      public void StringValue_AsDouble_ValidString()
      {
         _testValue.Value = "99.99";
         Assert.AreEqual(99.99, _testValue.AsDouble());
      }

      [TestMethod]
      [ExpectedException(typeof(FormatException))]
      public void StringValue_AsDouble_InvalidString()
      {
         Assert.IsInstanceOfType(_testValue.AsDouble(), typeof(double));
      }

      [TestMethod]
      [ExpectedException(typeof(InvalidOperationException))]
      public void StringValue_AsDouble_IsIndeterminate()
      {
         double result = _defaultValue.AsDouble();
      }

      [TestMethod]
      [ExpectedException(typeof(InvalidOperationException))]
      public void StringValue_AsDouble_IsVaries()
      {
         _testValue.IsVaries = true;
         double result = _testValue.AsDouble();
      }

      [TestMethod]
      public void StringValue_AsString()
      {
         Assert.AreEqual(aTestString, _testValue.AsString());
         Assert.AreEqual(string.Empty, _emptyTestValue.AsString());
      }

      [TestMethod]
      [ExpectedException(typeof(InvalidOperationException))]
      public void StringValue_AsString_IsIndeterminate()
      {
         string result = _defaultValue.AsString();
      }

      [TestMethod]
      public void StringValue_AsString_IsVaries()
      {
         _testValue.IsVaries = true;

         Assert.AreEqual("varies", _testValue.AsString());
      }
      #endregion Conversion Tests

      #region Comparison Tests
      [TestMethod]
      public void StringValue_IsEqual_True()
      {
         // reference equality
         Assert.IsTrue(_testValue.IsEqual(_testValue));
         Assert.IsTrue(_emptyTestValue.IsEqual(_emptyTestValue));
         Assert.IsTrue(_defaultValue.IsEqual(_defaultValue));

         StringValue anotherValue = new StringValue(aTestString);
         Assert.IsTrue(_testValue.IsEqual(anotherValue));
         anotherValue.Value = string.Empty;
         Assert.IsTrue(_emptyTestValue.IsEqual(anotherValue));
         anotherValue.IsVaries = true;
         _testValue.IsVaries = true;
         Assert.IsTrue(_testValue.IsEqual(anotherValue));
         anotherValue.IsIndeterminate = true;
         Assert.IsTrue(_defaultValue.IsEqual(anotherValue));
      }

      [TestMethod]
      public void StringValue_IsEqual_False()
      {
         Assert.IsFalse(_testValue.IsEqual(_emptyTestValue));
         Assert.IsFalse(_emptyTestValue.IsEqual(_testValue));
         Assert.IsFalse(_testValue.IsEqual(_defaultValue));

         StringValue anotherValue = new StringValue(aTestString);
         anotherValue.IsVaries = true;
         Assert.IsFalse(_testValue.IsEqual(anotherValue));
      }

      [TestMethod]
      public void StringValue_IsSameType()
      {
         Assert.IsTrue(_testValue.IsSameType(_defaultValue));

         DoubleValue dblValue = new DoubleValue(99.99);
         Assert.IsFalse(_testValue.IsSameType(dblValue));
      }

      [TestMethod]
      public void StringValue_CompareTo_ReferenceEquality()
      {
         Assert.IsTrue(_testValue.CompareTo(_testValue) == 0);
      }

      [TestMethod]
      public void StringValue_CompareTo_Null()
      {
         Assert.IsTrue(_testValue.CompareTo(null) > 0);
      }

      [TestMethod]
      public void StringValue_CompareTo_Nonempty_Empty()
      {
         Assert.IsTrue(_testValue.CompareTo(_emptyTestValue) > 0);
      }

      [TestMethod]
      public void StringValue_CompareTo_Empty_Nonempty()
      {
         Assert.IsTrue(_emptyTestValue.CompareTo(_testValue) < 0);
      }

      [TestMethod]
      public void StringValue_CompareTo_Indeterminate_Indeterminate()
      {
         _testValue.IsIndeterminate = true;
         Assert.IsTrue(_testValue.CompareTo(_defaultValue) == 0);
      }

      [TestMethod]
      public void StringValue_CompareTo_Indeterminate_Nonempty()
      {
         Assert.IsTrue(_defaultValue.CompareTo(_testValue) < 0);
      }

      [TestMethod]
      public void StringValue_CompareTo_Nonempty_Indeterminate()
      {
         Assert.IsTrue(_testValue.CompareTo(_defaultValue) > 0);
      }

      [TestMethod]
      public void StringValue_CompareTo_Varies_Varies()
      {
         _testValue.IsVaries = true;
         _emptyTestValue.IsVaries = true;
         Assert.IsTrue(_testValue.CompareTo(_emptyTestValue) == 0);
      }

      [TestMethod]
      public void StringValue_CompareTo_Varies_Nonempty()
      {
         StringValue variesValue = new StringValue(aTestString);
         variesValue.IsVaries = true;

         Assert.IsTrue(variesValue.CompareTo(_testValue) < 0);
      }

      [TestMethod]
      public void StringValue_CompareTo_Nonempty_Varies()
      {
         StringValue variesValue = new StringValue(aTestString);
         variesValue.IsVaries = true;

         Assert.IsTrue(_testValue.CompareTo(variesValue) > 0);
      }

      [TestMethod]
      public void StringValue_CompareTo_SystemStringType()
      {
         Assert.IsTrue(_testValue.CompareTo(aTestString) == 0);
         Assert.IsTrue(_testValue.CompareTo(string.Empty) > 0);
         Assert.IsTrue(_testValue.CompareTo(aTestString + "bbb") < 0);
         Assert.IsTrue(_emptyTestValue.CompareTo(aTestString) < 0);
         Assert.IsTrue(_emptyTestValue.CompareTo(string.Empty) == 0);

         _testValue.Value = "bbb";
         Assert.IsTrue(_testValue.CompareTo(aTestString) > 0);
      }

      [TestMethod]
      [ExpectedException(typeof(ArgumentException))]
      public void StringValue_CompareTo_Boolean()
      {
         Assert.IsTrue(_testValue.CompareTo(true) == 0);
      }
      #endregion Comparison Tests

      #region Helper Methods
      private void checkValue(object theValue, string expectedValue)
      {
         Assert.AreEqual(expectedValue, 
                         theValue, 
                         string.Format("Value should be {0}", expectedValue));

         string fullName = theValue.GetType().FullName;
         Assert.AreEqual("System.String", theValue.GetType().FullName);
      }
      #endregion Helper Methods
   }
}