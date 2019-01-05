using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autodesk.PropertiesFramework;

namespace Autodesk.PropertiesFramework.BasicProperties
{
   public class BasicPropertiesProvider : BasicItem, IPropertiesProvider
   {
      // Default constructor
      public BasicPropertiesProvider() : base(DefaultProviderName) { }

      public BasicPropertiesProvider(string id, string name) : base(id, name) { }

      public ICollection<IGroup> Groups { get { return m_group.Groups; } }
      public ICollection<IProperty> Properties { get { return m_group.Properties; } }

      public void AddGroup(IGroup group)
      {
         m_group.AddGroup(group);
      }

      public void RemoveGroup(IGroup group)
      {
         m_group.RemoveGroup(group);
      }

      public void RemoveGroup(string ID)
      {
         m_group.RemoveGroup(ID);
      }

      public void AddProperty(IProperty property)
      {
         m_group.AddProperty(property);
      }

      public void RemoveProperty(IProperty property)
      {
         m_group.RemoveProperty(property);
      }

      public void RemoveProperty(string ID)
      {
         m_group.RemoveProperty(ID);
      }

      #region For Testing Only
      internal static string DefaultProviderName
      {
         get { return "Need_Localized_Provider_Name_Here"; }
      }
      #endregion  For Testing Only

      #region Data Members
      BasicGroup m_group = new BasicGroup();
      #endregion Data Members
   }
}
