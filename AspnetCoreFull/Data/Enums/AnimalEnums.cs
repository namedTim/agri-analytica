using System.ComponentModel;
using System.Reflection;

namespace AspnetCoreFull.Data.Enums;

public static class EnumExtensions
{
  public static string GetDescription(this Enum value)
  {
    FieldInfo field = value.GetType().GetField(value.ToString());

    DescriptionAttribute attribute
      = Attribute.GetCustomAttribute(field, typeof(DescriptionAttribute))
        as DescriptionAttribute;

    return attribute == null ? value.ToString() : attribute.Description;
  }
}


public enum eAgriType
{
  [Description("Živinoreja")]
  Zivinoreja = 1,


}


