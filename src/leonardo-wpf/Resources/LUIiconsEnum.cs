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
        lui_icon_plus,
        lui_icon_calendar,
        lui_icon_menu,
        lui_icon_table,
        lui_icon_triangle_bottom,
        lui_icon_triangle_right,
        lui_icon_triangle_left,
        lui_icon_info,
        lui_icon_expression,
        lui_icon_bin,
        lui_icon_link,
        lui_icon_search,
        lui_icon_select_alternative,
        lui_icon_cross,
        lui_icon_sheet,
        lui_icon_stream,
        lui_icon_arrow_up,
        lui_icon_arrow_down,
        lui_icon_arrow_left,
        lui_icon_arrow_right,
        lui_icon_grid,
        lui_icon_list,
        lui_icon_ascending,
        lui_icon_descending,
        lui_icon_person

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
                icontext = "G";
                break;
            case LUIiconsEnum.lui_icon_plus:
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
            case LUIiconsEnum.lui_icon_triangle_left:
                icontext = "T";
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
            case LUIiconsEnum.lui_icon_select_alternative:
                icontext = "ö";
                break;
            case LUIiconsEnum.lui_icon_sheet:
                icontext = "4";
                break;
            case LUIiconsEnum.lui_icon_stream:
                icontext = "ã";
                break;
            case LUIiconsEnum.lui_icon_arrow_down:
                icontext = "¯";
                break;
            case LUIiconsEnum.lui_icon_arrow_up:
                icontext = "˜";
                break;
            case LUIiconsEnum.lui_icon_arrow_left:
                icontext = "ê";
                break;
            case LUIiconsEnum.lui_icon_arrow_right:
                icontext = "ë";
                break;
            case LUIiconsEnum.lui_icon_grid:
                icontext = "ì";
                break;
            case LUIiconsEnum.lui_icon_list:
                icontext = "î";
                break;
            case LUIiconsEnum.lui_icon_ascending:
                icontext = "≈";
                break;
            case LUIiconsEnum.lui_icon_descending:
                icontext = "∆";
                break;
            case LUIiconsEnum.lui_icon_person:
                icontext = "y";
                break;
            default:
                icontext = "";
                break;
        }
        return icontext;

    }
}
