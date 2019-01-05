using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections;
using System.Collections.Generic;
using Autodesk.PropertiesFramework.BasicProperties;

namespace Autodesk.PropertiesFramework.BasicPropertiesTests
{
   class TestUtilities
   {
      public static void checkException(ArgumentException e)
      {
         Assert.IsNotNull(e, "ArgumentException not thrown");
      }

      public static void checkException(ArgumentException e, string messageStart, string param)
      {
         Assert.IsNotNull(e, "ArgumentException not thrown");
         checkExceptionContent(e, messageStart, param);
      }

      public static void checkException(ArgumentOutOfRangeException e, string messageStart, string param)
      {
         Assert.IsNotNull(e, "ArgumentOutOfRangeException not thrown");
         checkExceptionContent(e, messageStart, param);
      }

      public static void checkExceptionContent(ArgumentException e, string messageStart, string param)
      {
         if (e != null)
         {
            StringAssert.StartsWith(e.Message, messageStart);
            Assert.AreEqual(param, e.ParamName, false);
         }
      }

      internal static void checkDefaultPropertyDefinition(IPropertyDefinition def)
      {
         // check the expected default values
         // the ID should be a valid guid
         checkGuid(def.ID, true);
         Assert.AreEqual(BasicPropertyDefinition.DefaultName, def.Name, false);
         Assert.AreEqual(string.Empty, def.ToolTip);
         Assert.AreEqual(DataType.String, def.DataType, "Default value for DataType should be string.");
         Assert.AreEqual(ControlType.Default, def.ControlType, "Default value for ControlType should be default.");
         Assert.IsFalse(def.ReadOnly, "Default value for the ReadOnly property should be false.");
         Assert.AreEqual(string.Empty, def.ToolTip, "Default value for the ToolTip property should be an empty string.");
         Assert.IsNull(def.Formatter, "Default value for Formatter property should be null.");
         Assert.IsNull(def.Validator, "Default value for Validator property should be null.");
         Assert.IsNull(def.CustomControl, "Default value for CustomControl property should be null.");
      }

      internal static void checkDefaultGroup(IGroup group)
      {
         // check the expected default values
         // the ID should be a valid guid
         checkGuid(group.ID, true);
         Assert.AreEqual(BasicGroup.DefaultName, group.Name, false);
         Assert.AreEqual(string.Empty, group.ToolTip);

         // the groups and properties in the specified group should not
         // be null references and should be empty
         checkEmpty(group.Groups, "Groups");
         checkEmpty(group.Properties, "Properties");
      }

      internal static void checkDefaultPropertyValue(IDataValue propValue, DataType expectedType)
      {
         // check the expected default values
         Assert.AreEqual(expectedType, 
                         propValue.ValueType, 
                         string.Format("ValueType should be {0}", Enum.GetName(typeof(DataType), expectedType)));
         Assert.IsNull(propValue.Value, "Value should be null");
         Assert.IsTrue(propValue.IsIndeterminate, "The value should be indeterminate");
         Assert.IsFalse(propValue.IsVaries, "The value should not vary");
      }

      internal static void checkValuedPropertyValue(IDataValue propValue, DataType expectedType)
      {
         // check the expected values when the property value has an actual value
         Assert.AreEqual(expectedType,
                         propValue.ValueType,
                         string.Format("ValueType should be {0}", Enum.GetName(typeof(DataType), expectedType)));
         Assert.IsNotNull(propValue.Value, "Value should not be null");
         Assert.IsFalse(propValue.IsIndeterminate, "The value should not be indeterminate");
         Assert.IsFalse(propValue.IsVaries, "The value should not vary");
      }


      internal static void checkEmpty(IEnumerable target, string containerName)
      {
         Assert.IsNotNull(target);
         if (target != null)
         {
            Assert.IsFalse(target.GetEnumerator().MoveNext(), string.Format("{0} is not empty.", containerName));
         }
      }

      internal static void checkGuid(string guidValue, bool isDefault)
      {
         // check the expected default values
         // the ID should be a valid guid
         Guid guidResult = Guid.Empty;
         bool validGuid = Guid.TryParse(guidValue, out guidResult);
         if (isDefault)
         {
            Assert.AreNotEqual(Guid.Empty, guidResult, "The default ID should not be an empty guid.");
            Assert.IsTrue(validGuid, "The default ID should be a guid.");
         }
         else
         {
            Assert.AreNotEqual(Guid.Empty, guidResult, "The ID should not be an empty guid.");
            Assert.IsTrue(validGuid, "The ID should be a guid.");
         }
      }

      internal static void checkForSingleItem(IEnumerable target, object expectedItem, string containerName)
      {
         int count = 0;
         foreach (object item in target)
         {
            if (count == 0)
            {
               Assert.AreEqual(expectedItem, item, string.Format("The first item in {0} is not the expected item.", containerName));
            }

            count++;
         }

         Assert.AreEqual(1, count, string.Format("There should one and only one item in {0}", containerName));
      }
   }
}
