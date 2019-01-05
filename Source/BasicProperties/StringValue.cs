using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Autodesk.PropertiesFramework.BasicProperties
{
   public class StringValue : BasicValue, IDataValue
   {
      public StringValue() : base(DataType.String, true) { }

      public StringValue(string value) : base(DataType.String, false)
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

            m_value = Convert.ToString(value);
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
         return Convert.ToInt32(m_value);
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
            return m_value.CompareTo(dataValueObj.AsString());
         }

         return m_value.CompareTo(obj);
      }

      #region Data Members
      string m_value = string.Empty;
      #endregion Data Members
   }
}
