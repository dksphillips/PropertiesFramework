using System;
using Autodesk.PropertiesFramework;

namespace Autodesk.PropertiesFramework.BasicProperties
{
   public class BasicPropertyDefinition : BasicItem, IPropertyDefinition
   {
      // Default constructor
      public BasicPropertyDefinition() : base(DefaultName) { }

      public BasicPropertyDefinition(string id, string name) : base(id, name) { }

      public DataType DataType
      {
         get { return m_dataType; }
         set
         {
            if ((value < DataType.Undefined) || (value > DataType.String))
            {
               throw new ArgumentOutOfRangeException("dataType", "DataType value must be valid.");
            }

            if (value != m_dataType)
            {
               m_dataType = value;
            }
         }
      }

      public ControlType ControlType
      {
         get { return m_controlType; }
         set
         {
            if ((value < ControlType.Default) || (value > ControlType.Undefined))
            {
               throw new ArgumentOutOfRangeException("controlType", "ControlType value must be valid.");
            }

            if (value != m_controlType)
            {
               m_controlType = value;
            }
         }
      }

      public bool ReadOnly
      {
         get { return m_readOnly; }
         set
         {
            if (value != m_readOnly)
            {
               m_readOnly = value;
            }
         }
      }

      public IFormatter Formatter
      {
         get { return m_formatter; }
         set
         {
            if (value != m_formatter)
            {
               m_formatter = value;
            }
         }
      }

      public IValidator Validator
      {
         get { return m_validator; }
         set
         {
            if (value != m_validator)
            {
               m_validator = value;
            }
         }
      }

      public IControlContentProvider CustomControl
      {
         get { return m_customControl; }
         set
         {
            if (value != m_customControl)
            {
               m_customControl = value;
            }
         }
      }

      #region For Testing Only
      internal static string DefaultName
      {
         get { return "Need_Localized_Property_Name_Here"; }
      }
      #endregion  For Testing Only

      #region Data Members
      private IValidator m_validator = null;
      private IFormatter m_formatter = null;
      private ControlType m_controlType = ControlType.Default;
      private DataType m_dataType = DataType.String;
      private bool m_readOnly = false;
      private IControlContentProvider m_customControl = null;
      #endregion Data Members
   }
}
