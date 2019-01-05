using System;
using System.Collections.Generic;

namespace Autodesk.PropertiesFramework
{
   // First stab at controls that are supported; others can be added as identified
   public enum ControlType
   {
      Default = 0,      // dictated by type of the property data
      Custom,           // property will provide a custom control conforming to the IControl interface
      Checkbox,         // checkbox
      Edit,             // edit control
      EditBrowse,       // edit control with a button that invokes a modal dialog to browse for a value
      Browse,           // text control with a button that invokes a modal dialog to browse for a value
      NumericSpin,      // numeric edit control with spin button
      Combo,            // combo box
      EditCombo,        // editable combo box
      Button,           // a pushbutton that invokes a modal dialog
      Image,            // an image control
      Undefined         // must always be the last enum value
   }

   public enum DataType
   {
      Undefined = 0,
      Boolean,
      Integer,
      Enum,
      Double,
      String
   }

   public enum ValidityResult
   {
      Valid = 0,
      Warning,
      Error
   };

   public interface IDataValue
   {
      DataType ValueType { get; }

      object Value { get; set; }

      bool IsIndeterminate { get; }

      // for when a property represents a collection of unequal values
      bool IsVaries { get; }

      // accessors for the controls to get the value in an appropriate form
      bool AsBoolean();
      Int32 AsInteger();
      double AsDouble();
      String AsString();

      // for comparison
      bool IsEqual(IDataValue other);
      bool IsSameType(IDataValue other);
   }

   public interface IFormatter
   {
      string format(IDataValue value);
   }

   public interface IValidator
   {
      ValidityResult validate(IDataValue value);
      void displayMessage(IDataValue value, ValidityResult result);
      string validationMessage { get; }
   }

   // defines the additional information that a particular control
   // needs for proper configuration and alignment with a parent property
   // TODO: this needs more definition eventually
   public interface IControlContentProvider
   {
      IProperty Property { get; }
   };

   public interface IItem
   {
      // localized name
      String Name { get; }

      // for GUID-based Settings, convert the GUID to a string;
      // must be unique
      String ID { get; }

      // default localized tooltip; the client can override the default behavior
      // by providing an IToolTipPresenter to the IPropertiesPresenter
      object ToolTip { get; }
   }

   public interface IPropertyDefinition : IItem
   {
      DataType DataType { get; }
      ControlType ControlType { get; }
      bool ReadOnly { get; }
      IFormatter Formatter { get; }
      IValidator Validator { get; }
      IControlContentProvider CustomControl { get; }
   }

   public interface IProperty
    {
      IPropertyDefinition Definition { get; }

      // implementer is responsible for changed notifications, if required
      IDataValue Value { get; set; }
    }

   public interface IGroup : IItem
   {
      ICollection<IGroup> Groups { get; }
      ICollection<IProperty> Properties { get; }
   }

   // Provides the properties that are presented in the UI
   // Also known as the data model
   public interface IPropertiesProvider : IItem
   {
      // providers may have top-level properties
      ICollection<IProperty> Properties { get; }

      // providers may have grouped properties
      ICollection<IGroup> Groups { get; }
   }

   // called by the property presenter when a tool tip needs to be 
   // displayed or hidden; assumes that only one tool tip can
   // be displayed at a time; allows the client to handle enhanced
   // tooltips without introducing an AdWindows link dependency to the
   // properties framework component
   public interface IToolTipPresenter
   {
      bool showToolTip(IProperty property, IPropertiesPresenter presenter, double x, double y);
      bool showToolTip(IGroup group, IPropertiesPresenter presenter, double x, double y);
      bool hideToolTip();
   }

   // Displays a collection of properties in a user interface
   // TODO: needs more definition; need to define appropriate events
   public interface IPropertiesPresenter
   {
      bool applyProperties(IPropertiesProvider provider);
      bool updateProperties();
      IntPtr Window { get; }

      IToolTipPresenter ToolTipPresenter { get; set; }
   }
}
