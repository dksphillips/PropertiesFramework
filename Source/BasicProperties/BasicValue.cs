using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Autodesk.PropertiesFramework.BasicProperties
{
   static class CompareResult
   {
      public const int Equal = 0;
      public const int GreaterThan = 1;
      public const int LessThan = -1;
      public const int CompareValue = -2;
   }

   public abstract class BasicValue : IComparable
   {
      protected BasicValue(DataType valueType)
      {
         m_valueType = valueType;
         IsIndeterminate = true;
      }

      protected BasicValue(DataType valueType, bool isIndeterminate)
      {
         m_valueType = valueType;
         IsIndeterminate = isIndeterminate;
      }

      #region Partial IDataValue Implementation
      public DataType ValueType
      {
         get { return m_valueType; }
      }

      public abstract object Value { get; set; }

      public bool IsIndeterminate
      {
         get { return m_indeterminate; }
         set
         {
            if (value != m_indeterminate)
            {
               m_indeterminate = value;
            }
         }
      }

      // for when a property represents a collection of unequal values
      public bool IsVaries
      {
         get { return m_varies; }
         set
         {
            if (value != m_varies)
            {
               m_varies = value;
            }
         }
      }

      public bool IsSameType(IDataValue other)
      {
         return m_valueType == other.ValueType;
      }

      // for comparison
      public bool IsEqual(IDataValue other)
      {
         return CompareTo(other) == 0;
      }

      // for conversion
      public String AsString()
      {
         return asString(Value);
      }

      #endregion Partial IDataValue Implementation

      #region Helpers
      public int CompareTo(object obj)
      {
         // check for reference equality first
         if (object.ReferenceEquals(this, obj))
         {
            return CompareResult.Equal;
         }

         // check for null reference
         if (obj == null)
         {
            return CompareResult.GreaterThan;
         }

         // handle comparison based on the IDataValue interface
         if (obj is IDataValue)
         {
            IDataValue dataValueObj = obj as IDataValue;

            // first check for the indeterminate state
            if (IsIndeterminate == true)
            {
               return dataValueObj.IsIndeterminate ? CompareResult.Equal : CompareResult.LessThan;
            }
            else if (dataValueObj.IsIndeterminate)
            {
               return CompareResult.GreaterThan;
            }

            // then check for the varies state
            if (IsVaries == true)
            {
               return dataValueObj.IsVaries ? CompareResult.Equal : CompareResult.LessThan;
            }
            else if (dataValueObj.IsVaries)
            {
               return CompareResult.GreaterThan;
            }
         }

         // the values are neither indeterminate or varies,
         // so let the subclas to compare the values
         return compareValue(obj);
      }

      protected abstract int compareValue(object obj);

      protected String asString(object theValue)
      {
         // TODO - localize this when the time comes
         if (IsVaries)
         {
            return "varies";
         }

         if (IsIndeterminate)
         {
            throw new InvalidOperationException("Cannot convert an indeterminate value to a string");
         }

         return Convert.ToString(theValue);
      }

      protected void validateCurrentValue(string expectedValueType)
      {
         if (IsVaries)
            throw new InvalidOperationException(string.Format("Cannot convert a varies value to {0}", expectedValueType));

         if (IsIndeterminate)
            throw new InvalidOperationException(string.Format("Cannot convert an empty value to {0}", expectedValueType));
      }
      #endregion Helpers

      #region Data Members
      DataType m_valueType = DataType.Undefined;
      bool m_indeterminate = true;
      bool m_varies = false;
      #endregion Data Members
   }
}
