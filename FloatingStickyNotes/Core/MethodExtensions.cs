using System.Collections;
using System.Drawing;
using System.Reflection;
using System.Text;

namespace FloatingStickyNotes.Core
{
  public static class MethodExtensions
  {
    //DO_NOTHING
  }

  public static class ClassesMethods
  {
    public static string PropertiesToString<T>(this T obj, int depth = 0) where T : class
    {
      StringBuilder sb = new StringBuilder();
      PropertyInfo[] properties = obj.GetType().GetProperties();

      foreach (PropertyInfo property in properties)
      {
        object value = property.GetValue(obj, null);
        string indent = new string(' ', depth * 2);

        if (value is IList list)
        {
          sb.AppendLine($"{indent}{property.Name}:");
          for (int i = 0; i < list.Count; i++)
          {
            if (list[i] is IList || list[i] is IDictionary || (list[i] is object && !list[i].GetType().IsPrimitive && list[i].GetType() != typeof(string)))
            {
              sb.AppendLine($"{indent}- {i}: {list[i].GetType().Name}:");
              sb.Append(PropertiesToString(list[i], depth + 1));
            }
            else
            {
              sb.AppendLine($"{indent}- {i}: {list[i]}");
            }
          }
        }
        else if (value is IDictionary dict)
        {
          sb.AppendLine($"{indent}{property.Name}:");
          foreach (DictionaryEntry entry in dict)
          {
            if (entry.Value is IList || entry.Value is IDictionary || (entry.Value is object && !entry.Value.GetType().IsPrimitive && entry.Value.GetType() != typeof(string)))
            {
              sb.AppendLine($"{indent}- {entry.Key}: {entry.Value.GetType().Name}:");
              sb.Append(PropertiesToString(entry.Value, depth + 1));
            }
            else
            {
              sb.AppendLine($"{indent}- {entry.Key}: {entry.Value}");
            }
          }
        }
        else if (property.PropertyType == typeof(Color))
        {
          Color color = (Color)value;
          sb.AppendLine($"{indent}{property.Name}: R:{color.R}, G:{color.G}, B:{color.B}");
        }
        else if (property.PropertyType == typeof(Point))
        {
          Point point = (Point)value;
          sb.AppendLine($"{indent}{property.Name}: X:{point.X}, Y:{point.Y}");
        }
        else if (property.PropertyType == typeof(Size))
        {
          Size size = (Size)value;
          sb.AppendLine($"{indent}{property.Name}: Width:{size.Width}, Height:{size.Height}");
        }
        else if (value is object && !property.PropertyType.IsPrimitive && property.PropertyType != typeof(string))
        {
          sb.AppendLine($"{indent}{property.Name}: {value.GetType().Name}:");
          sb.Append(PropertiesToString(value, depth + 1));
        }
        else
        {
          sb.AppendLine($"{indent}{property.Name}: {value}");
        }
      }

      return sb.ToString();
    }
  }
}
