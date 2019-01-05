using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Autodesk.PropertiesFramework.BasicProperties
{
   public class DoubleValue : BasicValue, IDataValue
   {
      public DoubleValue() : base(DataType.Double, true) { }

      public DoubleValue(double value) : base(DataType.Double, false)
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

            m_value = Convert.ToDouble(value);
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
         return m_value;
      }
      #endregion IDataValue

      protected override int compareValue(object obj)
      {
         // handle comparison based on the IDataValue interface
         if (obj is IDataValue)
         {
            IDataValue dataValueObj = obj as IDataValue;
            return m_value.CompareTo(dataValueObj.AsDouble());
         }

         // TODO: needs fuzzy equality support
         return m_value.CompareTo(obj);
      }

      #region Data Members
      double m_value = 0;
      #endregion Data Members
   }
}
