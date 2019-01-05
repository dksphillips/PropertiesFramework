using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Autodesk.PropertiesFramework.BasicProperties
{
   public class IntegerValue : BasicValue, IDataValue
   {
      public IntegerValue() : base(DataType.Integer, true) { }

      public IntegerValue(int value) : base(DataType.Integer, false)
      {
         m_value = value;
      }

      #region IDataValue Implementation
      public override object Value
      {
         get
         {
            if (IsIndeterminate || IsVaries)
            {
               return null;
            }

            return m_value;
         }
         set
         {
            if (value == null)
            {
               throw new ArgumentNullException("value", "Value is invalid; it cannot be null.");
            }

            // TODO: add ceil/floor support
            m_value = Convert.ToInt16(value);
         }
      }

      // accessors for the controls to get the value in an appropriate form
      public bool AsBoolean()
      {
         validateCurrentValue("a boolean");
         return Convert.ToBoolean(m_value);
      }

      public Int32 AsInteger()
      {
         validateCurrentValue("an integer");
         return m_value;
      }

      public double AsDouble()
      {
         validateCurrentValue("a double");
         return Convert.ToDouble(m_value);
      }

      #endregion IDataValue

      protected override int compareValue(object obj)
      {
         // handle comparison based on the IDataValue interface
         if (obj is IDataValue)
         {
            IDataValue dataValueObj = obj as IDataValue;
            return m_value.CompareTo(dataValueObj.AsInteger());
         }

         return m_value.CompareTo(obj);
      }

      #region Data Members
      Int32 m_value = 0;
      #endregion Data Members
   }
}
