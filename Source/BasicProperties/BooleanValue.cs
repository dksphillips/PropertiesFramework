﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autodesk.PropertiesFramework;

namespace Autodesk.PropertiesFramework.BasicProperties
{
   public class BooleanValue : BasicValue, IDataValue
   {
      public BooleanValue() : base(DataType.Boolean, true) {}

      public BooleanValue(bool value) : base(DataType.Boolean, false)
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

            m_value = Convert.ToBoolean(value);
         }
      }

      // accessors for the controls to get the value in an appropriate form
      public bool AsBoolean()
      {
         validateCurrentValue("a boolean");
         return m_value;
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
            return m_value.CompareTo(dataValueObj.AsBoolean());
         }

         return m_value.CompareTo(obj);
      }

      #region Data Members
      bool m_value = false;
      #endregion Data Members
   }
}
