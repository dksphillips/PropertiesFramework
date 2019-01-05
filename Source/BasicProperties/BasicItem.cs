using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Autodesk.PropertiesFramework.BasicProperties
{
   public class BasicItem : IItem
   {
      // Default constructor
      public BasicItem() { }

      public BasicItem(string id, string name)
      {
         ID = id;
         Name = name;
      }

      protected BasicItem(string name)
      {
         Name = name;
      }

      // localized name
      public String Name
      {
         get { return m_name; }
         set
         {
            if (string.IsNullOrWhiteSpace(value))
               throw new ArgumentException("Name is invalid; it cannot be null, empty, or contain only whitespace.", "name");

            if (string.Compare(value, m_name) != 0)
            {
               m_name = value;
            }
         }
      }

      public String ID
      {
         get { return m_id; }
         set
         {
            if (string.IsNullOrWhiteSpace(value))
               throw new ArgumentException("ID is invalid; it cannot be null, empty, or contain only whitespace.", "id");

            if (string.Compare(value, m_id) != 0)
            {
               m_id = value;
            }
         }
      }

      // default localized tooltip; the client can override the default behavior
      // by providing an IToolTipPresenter to the IPropertiesPresenter
      public object ToolTip
      {
         get { return m_tooltip; }
         set
         {
            if (value != m_tooltip)
            {
               m_tooltip = value;
            }
         }
      }

      #region For Testing Only
      internal static string DefaultItemName
      {
         get { return "Need_Localized_Name_Here"; }
      }

      internal static string DefaultItemID
      {
         get { return Guid.NewGuid().ToString();  }
      }
      #endregion  For Testing Only

      #region Data Members
      private string m_id = DefaultItemID;
      private string m_name = DefaultItemName;
      private object m_tooltip = string.Empty;
      #endregion Data Members
   }
}
