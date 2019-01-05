using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autodesk.PropertiesFramework;
using Autodesk.PropertiesFramework.BasicProperties;

namespace Autodesk.PropertiesFramework.BasicProperties
{
   public class BasicProperty : IProperty
   {
      // Constructors
      public BasicProperty() { }

      public BasicProperty(IPropertyDefinition definition)
      {
         Definition = definition;
      }

      public BasicProperty(string id, string name)
      {
         Definition = new BasicPropertyDefinition(id, name);
      }

      public BasicProperty(IPropertyDefinition definition, IDataValue value)
      {
         Definition = definition;
         Value = value;
      }

      public IPropertyDefinition Definition
      {
         get { return m_propDef; }
         set
         {
            if (value == null)
               throw new ArgumentNullException("definition", "Definition is invalid; it cannot be null.");

            if (value != m_propDef)
            {
               m_propDef = value;
            }
         }
      }

      // implementer is responsible for changed notifications, if required
      public IDataValue Value
      {
         get { return m_value; }
         set
         {
            if (value != m_value)
            {
               m_value = value;
            }
         }
      }

      // data members
      IPropertyDefinition m_propDef = new BasicPropertyDefinition();
      IDataValue m_value = null;
   }
}
