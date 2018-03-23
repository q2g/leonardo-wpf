using leonardo.Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace leonardo.Resources
{
    public enum LUIiconsEnum
    {
        lui_icon_none,
        ui_icon_plus,
        lui_icon_calendar,
        lui_icon_menu,
        lui_icon_table,
        lui_icon_triangle_bottom,
        lui_icon_triangle_right,
        lui_icon_info,
        lui_icon_expression,
        lui_icon_bin,
        lui_icon_link,
        lui_icon_search,
        lui_icon_cross
    }    
}
public static class LUIiconsEnumExtensions
{
    public static string GetIconText(this LUIiconsEnum icon)
    {
        string icontext = "";
        switch (icon)
        {
            case LUIiconsEnum.lui_icon_none:
                icontext = "";
                break;
            case LUIiconsEnum.lui_icon_calendar:
                icontext="G";
                break;
            case LUIiconsEnum.ui_icon_plus:
                icontext = "P";
                break;
            case LUIiconsEnum.lui_icon_menu:
                icontext = "o";
                break;
            case LUIiconsEnum.lui_icon_table:
                icontext = "'"; 
                break;
            case LUIiconsEnum.lui_icon_triangle_bottom:
                icontext = "S";
                break;
            case LUIiconsEnum.lui_icon_triangle_right:
                icontext = "U";
                break;
            case LUIiconsEnum.lui_icon_info:
                icontext = "]";
                break;
            case LUIiconsEnum.lui_icon_expression:
                icontext = "3";
                break;
            case LUIiconsEnum.lui_icon_bin:
                icontext = "Ö";
                break;
            case LUIiconsEnum.lui_icon_link:
                icontext = "é";
                break;
            case LUIiconsEnum.lui_icon_search:
                icontext = "F";
                break;
            case LUIiconsEnum.lui_icon_cross:
                icontext = "‰";
                break;
            default:
                icontext = "";
                break;
        }
        return icontext;

    }
}
