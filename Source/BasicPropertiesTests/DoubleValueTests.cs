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
   public class DoubleValueTests
   {
      #region Data Members
      DoubleValue _nonzeroValue = null;
      DoubleValue _zeroValue = null;
      DoubleValue _defaultValue = null;
      TestContext _testContext = null;

      public const double aDouble = 99.99;
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
         _nonzeroValue = new DoubleValue(aDouble);
         _zeroValue = new DoubleValue(0);
         _defaultValue = new DoubleValue();
      }

      [TestCleanup]
      public void TearDown()
      {
         _nonzeroValue = null;
         _zeroValue = null;
         _defaultValue = null;
      }
      #endregion Test Setup/Tear Down

      #region Construction Tests
      // test that a basic boolean value is properly created
      // with the default constructor
      [TestMethod]
      public void DoubleValue_Creation_Default()
      {
         // check the expected default values
         TestUtilities.checkDefaultPropertyValue(_defaultValue, DataType.Double);
      }

      [TestMethod]
      public void DoubleValue_Creation_Nonzero()
      {
         TestUtilities.checkValuedPropertyValue(_nonzeroValue, DataType.Double);
         checkValue(_nonzeroValue.Value, aDouble);
      }

      [TestMethod]
      public void DoubleValue_Creation_Zero()
      {
         TestUtilities.checkValuedPropertyValue(_zeroValue, DataType.Double);
         checkValue(_zeroValue.Value, 0.0);
      }
      #endregion Construction Tests

      #region Properties Tests
      [TestMethod]
      public void DoubleValue_ValueType()
      {
         Assert.AreEqual(DataType.Double, _nonzeroValue.ValueType);
      }

      [TestMethod]
      public void DoubleValue_Value_Get()
      {
         checkValue(_nonzeroValue.Value, aDouble);
      }

      [TestMethod]
      public void DoubleValue_Value_Set_Double()
      {
         double testDouble = 0.0;
         _nonzeroValue.Value = testDouble;
         checkValue(_nonzeroValue.Value, testDouble);

         testDouble = aDouble;
         _nonzeroValue.Value = testDouble;
         checkValue(_nonzeroValue.Value, testDouble);
      }

      [TestMethod]
      public void DoubleValue_Value_Set_Null()
      {
         ArgumentException expectedException = null;

         try
         {
            _nonzeroValue.Value = null;
         }
         catch (ArgumentException e)
         {
            expectedException = e;
         }

         TestUtilities.checkException(expectedException, TestConstants.propValue, TestConstants.paramValue);
         checkValue(_nonzeroValue.Value, aDouble);
      }

      [TestMethod]
      public void DoubleValue_Value_Set_Boolean()
      {
         _nonzeroValue.Value = true;
         checkValue(_nonzeroValue.Value, Convert.ToDouble(true));

         _nonzeroValue.Value = false;
         checkValue(_nonzeroValue.Value, Convert.ToDouble(false));
      }

      [TestMethod]
      public void DoubleValue_Value_Set_Integer()
      {
         _nonzeroValue.Value = 100;
         checkValue(_nonzeroValue.Value, 100);
      }

      [TestMethod]
      public void DoubleValue_Value_Set_ValidString()
      {
         _nonzeroValue.Value = "0.0";
         checkValue(_nonzeroValue.Value, 0.0);

         _nonzeroValue.Value = "599.99";
         checkValue(_nonzeroValue.Value, 599.99);
      }

      [TestMethod]
      public void DoubleValue_Value_Set_InvalidString()
      {
         FormatException expectedException = null;

         try
         {
            _nonzeroValue.Value = "an invalid string";
         }
         catch (FormatException e)
         {
            expectedException = e;
         }

         Assert.IsNotNull(expectedException, "FormatException not thrown");
         checkValue(_nonzeroValue.Value, aDouble);
      }

      [TestMethod]
      public void DoubleValue_IsIndeterminate_Set()
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
      public void DoubleValue_IsVaries_Set()
      {
         Assert.IsFalse(_nonzeroValue.IsVaries, "The value should not vary");
         Assert.IsNotNull(_nonzeroValue.Value, "The actual value should not be null");

         _nonzeroValue.IsVaries = true;
         Assert.IsTrue(_nonzeroValue.IsVaries, "The value should vary");
         Assert.IsNull(_nonzeroValue.Value, "The actual value should be null when IsVaries is true");

         _nonzeroValue.IsVaries = false;
         Assert.IsFalse(_nonzeroValue.IsVaries, "The value should not vary");
         Assert.IsNotNull(_nonzeroValue.Value, "The actual value should not be null when IsVaries is false");
      }
      #endregion Properties Tests

      #region Conversion Tests
      [TestMethod]
      public void DoubleValue_AsBoolean()
      {
         Assert.IsTrue(_nonzeroValue.AsBoolean());
         Assert.IsFalse(_zeroValue.AsBoolean());
      }

      [TestMethod]
      [ExpectedException(typeof(InvalidOperationException))]
      public void DoubleValue_AsBoolean_IsIndeterminate()
      {
         bool result = _defaultValue.AsBoolean();
      }

      [TestMethod]
      [ExpectedException(typeof(InvalidOperationException))]
      public void DoubleValue_AsBoolean_IsVaries()
      {
         _nonzeroValue.IsVaries = true;
         bool result = _nonzeroValue.AsBoolean();
      }

      [TestMethod]
      public void DoubleValue_AsInteger()
      {
         Assert.AreEqual(Convert.ToInt32(aDouble), _nonzeroValue.AsInteger());
         Assert.AreEqual(0.0, _zeroValue.AsInteger());
      }

      [TestMethod]
      [ExpectedException(typeof(InvalidOperationException))]
      public void DoubleValue_AsInteger_IsIndeterminate()
      {
         int result = _defaultValue.AsInteger();
      }

      [TestMethod]
      [ExpectedException(typeof(InvalidOperationException))]
      public void DoubleValue_AsInteger_IsVaries()
      {
         _nonzeroValue.IsVaries = true;
         int result = _nonzeroValue.AsInteger();
      }

      [TestMethod]
      public void DoubleValue_AsDouble()
      {
         Assert.AreEqual(aDouble, _nonzeroValue.AsDouble());
         Assert.AreEqual(0.0, _zeroValue.AsDouble());
      }

      [TestMethod]
      [ExpectedException(typeof(InvalidOperationException))]
      public void DoubleValue_AsDouble_IsIndeterminate()
      {
         double result = _defaultValue.AsDouble();
      }

      [TestMethod]
      [ExpectedException(typeof(InvalidOperationException))]
      public void DoubleValue_AsDouble_IsVaries()
      {
         _nonzeroValue.IsVaries = true;
         double result = _nonzeroValue.AsDouble();
      }

      [TestMethod]
      public void DoubleValue_AsString()
      {
         Assert.AreEqual(aDouble.ToString(), _nonzeroValue.AsString());
         Assert.AreEqual(Convert.ToString(0.0), _zeroValue.AsString());
      }

      [TestMethod]
      [ExpectedException(typeof(InvalidOperationException))]
      public void DoubleValue_AsString_IsIndeterminate()
      {
         string result = _defaultValue.AsString();
      }

      [TestMethod]
      public void DoubleValue_AsString_IsVaries()
      {
         _nonzeroValue.IsVaries = true;

         Assert.AreEqual("varies", _nonzeroValue.AsString());
      }
      #endregion Conversion Tests

      #region Comparison Tests
      [TestMethod]
      public void DoubleValue_IsEqual_True()
      {
         // reference equality
         Assert.IsTrue(_nonzeroValue.IsEqual(_nonzeroValue));
         Assert.IsTrue(_zeroValue.IsEqual(_zeroValue));
         Assert.IsTrue(_defaultValue.IsEqual(_defaultValue));

         DoubleValue anotherValue = new DoubleValue(aDouble);
         Assert.IsTrue(_nonzeroValue.IsEqual(anotherValue));
         anotherValue.Value = 0.0;
         Assert.IsTrue(_zeroValue.IsEqual(anotherValue));
         anotherValue.IsVaries = true;
         _nonzeroValue.IsVaries = true;
         Assert.IsTrue(_nonzeroValue.IsEqual(anotherValue));
         anotherValue.IsIndeterminate = true;
         Assert.IsTrue(_defaultValue.IsEqual(anotherValue));
      }

      [TestMethod]
      public void DoubleValue_IsEqual_False()
      {
         Assert.IsFalse(_nonzeroValue.IsEqual(_zeroValue));
         Assert.IsFalse(_zeroValue.IsEqual(_nonzeroValue));
         Assert.IsFalse(_nonzeroValue.IsEqual(_defaultValue));

         DoubleValue anotherValue = new DoubleValue(aDouble);
         anotherValue.IsVaries = true;
         Assert.IsFalse(_nonzeroValue.IsEqual(anotherValue));
      }

      [TestMethod]
      public void DoubleValue_IsSameType()
      {
         Assert.IsTrue(_nonzeroValue.IsSameType(_defaultValue));
      }

      [TestMethod]
      public void DoubleValue_CompareTo_ReferenceEquality()
      {
         Assert.IsTrue(_nonzeroValue.CompareTo(_nonzeroValue) == 0);
      }

      [TestMethod]
      public void DoubleValue_CompareTo_Null()
      {
         Assert.IsTrue(_nonzeroValue.CompareTo(null) > 0);
      }

      [TestMethod]
      public void DoubleValue_CompareTo_True_False()
      {
         Assert.IsTrue(_nonzeroValue.CompareTo(_zeroValue) > 0);
      }

      [TestMethod]
      public void DoubleValue_CompareTo_False_True()
      {
         Assert.IsTrue(_zeroValue.CompareTo(_nonzeroValue) < 0);
      }

      [TestMethod]
      public void DoubleValue_CompareTo_Indeterminate_Indeterminate()
      {
         _nonzeroValue.IsIndeterminate = true;
         Assert.IsTrue(_nonzeroValue.CompareTo(_defaultValue) == 0);
      }

      [TestMethod]
      public void DoubleValue_CompareTo_Indeterminate_True()
      {
         Assert.IsTrue(_defaultValue.CompareTo(_nonzeroValue) < 0);
      }

      [TestMethod]
      public void DoubleValue_CompareTo_True_Indeterminate()
      {
         Assert.IsTrue(_nonzeroValue.CompareTo(_defaultValue) > 0);
      }

      [TestMethod]
      public void DoubleValue_CompareTo_Varies_Varies()
      {
         _nonzeroValue.IsVaries = true;
         _zeroValue.IsVaries = true;
         Assert.IsTrue(_nonzeroValue.CompareTo(_zeroValue) == 0);
      }

      [TestMethod]
      public void DoubleValue_CompareTo_Varies_True()
      {
         DoubleValue variesValue = new DoubleValue(aDouble);
         variesValue.IsVaries = true;

         Assert.IsTrue(variesValue.CompareTo(_nonzeroValue) < 0);
      }

      [TestMethod]
      public void DoubleValue_CompareTo_Nonzero_Varies()
      {
         DoubleValue variesValue = new DoubleValue(aDouble);
         variesValue.IsVaries = true;

         Assert.IsTrue(_nonzeroValue.CompareTo(variesValue) > 0);
      }

      [TestMethod]
      public void DoubleValue_CompareTo_SystemDoubleType()
      {
         Assert.IsTrue(_nonzeroValue.CompareTo(aDouble) == 0);
         Assert.IsTrue(_nonzeroValue.CompareTo(0.0) > 0);
         Assert.IsTrue(_nonzeroValue.CompareTo(aDouble + 100.00) < 0);
         Assert.IsTrue(_zeroValue.CompareTo(aDouble) < 0);
         Assert.IsTrue(_zeroValue.CompareTo(0.0) == 0);
         Assert.IsTrue(_zeroValue.CompareTo(-aDouble) > 0);
      }

      [TestMethod]
      [ExpectedException(typeof(ArgumentException))]
      public void DoubleValue_CompareTo_Boolean()
      {
         Assert.IsTrue(_nonzeroValue.CompareTo(true) == 0);
      }

      [TestMethod]
      [ExpectedException(typeof(ArgumentException))]
      public void DoubleValue_CompareTo_String()
      {
         Assert.IsTrue(_nonzeroValue.CompareTo(aDouble.ToString()) == 0);
      }
      #endregion Comparison Tests

      #region Helper Methods
      private void checkValue(object theValue, double expectedValue)
      {
         Assert.AreEqual(expectedValue, 
                         theValue, 
                         string.Format("Value should be {0}", expectedValue));
         Assert.AreEqual("System.Double", theValue.GetType().FullName);
      }
      #endregion Helper Methods
   }
}