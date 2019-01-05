using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autodesk.PropertiesFramework;

// TODO: Add as appropriate: probably should be on the interfaces, but maybe just IComparable
// IComparable – an object that can be compared with other objects of the same type
// IConvertible – an object that can be converted to different types
// ISerializable – an object that can be serialized

namespace Autodesk.PropertiesFramework.BasicProperties
{
   public class BasicGroup : BasicItem, IGroup
   {
      // Default constructor
      public BasicGroup() : base(DefaultName) { }

      public BasicGroup(string id, string name) : base(id, name) { }

      internal BasicGroup(string name) : base(name) { }

      public ICollection<IGroup> Groups { get { return m_groups.Values; } }
      public ICollection<IProperty> Properties { get { return m_properties.Values; } }

      public void AddGroup(IGroup group)
      {
         if (group == null)
         {
            throw new ArgumentNullException("group", "Group is invalid; it cannot be null.");
         }

         m_groups.Add(group.ID, group);
      }

      public void RemoveGroup(IGroup group)
      {
         if (group == null)
         {
            throw new ArgumentNullException("group", "Group is invalid; it cannot be null.");
         }

         RemoveGroup(group.ID);
      }

      public void RemoveGroup(string ID)
      {
         if (!m_groups.Remove(ID))
         {
            throw new KeyNotFoundException("Specified group was not found.");
         }
      }

      public void AddProperty(IProperty property)
      {
         if (property == null)
         {
            throw new ArgumentNullException("property", "Property is invalid; it cannot be null.");
         }

         m_properties.Add(property.Definition.ID, property);
      }

      public void RemoveProperty(IProperty property)
      {
         if (property == null)
         {
            throw new ArgumentNullException("property", "Property is invalid; it cannot be null.");
         }

         RemoveProperty(property.Definition.ID);
      }

      public void RemoveProperty(string ID)
      {
         if (!m_properties.Remove(ID))
         {
            throw new KeyNotFoundException("Specified property was not found.");
         }
      }

      #region For Testing Only
      // exposed for testing purposes
      internal static string DefaultName
      {
         get { return "Need_Localized_Group_Name_Here"; }
      }
      #endregion  For Testing Only

      #region Data Members
      private Dictionary<string, IGroup> m_groups = new Dictionary<string, IGroup>();
      private Dictionary<string, IProperty> m_properties = new Dictionary<string, IProperty>();
      #endregion Data Members

   }
}
