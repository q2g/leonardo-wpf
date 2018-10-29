namespace leonardo.Resources
{
    public enum LuiIconsEnum
    {
        lui_icon_none,
        lui_icon_plus,
        lui_icon_calendar,
        lui_icon_menu,
        lui_icon_table,
        lui_icon_pivot_table,
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
        lui_icon_person,
        lui_icon_edit,
        lui_icon_tick,
        lui_icon_back,
        lui_icon_forward,
        lui_icon_indent,
        lui_icon_undent,
        lui_icon_more,
        lui_icon_comment,
        lui_icon_selectiontool,
        lui_icon_clear_selection,
        lui_icon_selection_back,
        lui_icon_selection_forward,
        lui_icon_remove,
        lui_icon_lock,
        lui_icon_unlock,
        lui_icon_select_all,
        lui_icon_excluded,
        lui_icon_export,
        lui_icon_database,
        lui_icon_box,
        lui_icon_drop,
        lui_icon_warning_triangle,
        lui_icon_warning,
        lui_icon_help
    }

    public static class LuiIconsEnumExtensions
    {
        public static string GetIconText(this LuiIconsEnum icon)
        {            
            switch (icon)
            {
                case LuiIconsEnum.lui_icon_none:
                    return "";
                case LuiIconsEnum.lui_icon_calendar:
                    return "G";
                case LuiIconsEnum.lui_icon_plus:
                    return "P";
                case LuiIconsEnum.lui_icon_menu:
                    return "o";
                case LuiIconsEnum.lui_icon_table:
                    return "'";
                case LuiIconsEnum.lui_icon_pivot_table:
                    return "(";
                case LuiIconsEnum.lui_icon_triangle_bottom:
                    return "S";
                case LuiIconsEnum.lui_icon_triangle_right:
                    return "U";
                case LuiIconsEnum.lui_icon_triangle_left:
                    return "T";
                case LuiIconsEnum.lui_icon_info:
                    return "]";
                case LuiIconsEnum.lui_icon_expression:
                    return "3";
                case LuiIconsEnum.lui_icon_bin:
                    return "Ö";
                case LuiIconsEnum.lui_icon_link:
                    return "é";
                case LuiIconsEnum.lui_icon_search:
                    return "F";
                case LuiIconsEnum.lui_icon_cross:
                    return "‰";
                case LuiIconsEnum.lui_icon_select_alternative:
                    return "ö";
                case LuiIconsEnum.lui_icon_sheet:
                    return "4";
                case LuiIconsEnum.lui_icon_stream:
                    return "ã";
                case LuiIconsEnum.lui_icon_arrow_down:
                    return "¯";
                case LuiIconsEnum.lui_icon_arrow_up:
                    return "˜";
                case LuiIconsEnum.lui_icon_arrow_left:
                    return "ê";
                case LuiIconsEnum.lui_icon_arrow_right:
                    return "ë";
                case LuiIconsEnum.lui_icon_grid:
                    return "ì";
                case LuiIconsEnum.lui_icon_list:
                    return "î";
                case LuiIconsEnum.lui_icon_ascending:
                    return "≈";
                case LuiIconsEnum.lui_icon_descending:
                    return "∆";
                case LuiIconsEnum.lui_icon_person:
                    return "y";
                case LuiIconsEnum.lui_icon_edit:
                    return "@";
                case LuiIconsEnum.lui_icon_tick:
                    return "m";
                case LuiIconsEnum.lui_icon_back:
                    return "B";
                case LuiIconsEnum.lui_icon_forward:
                    return "C";
                case LuiIconsEnum.lui_icon_indent:
                    return "À";
                case LuiIconsEnum.lui_icon_undent:
                    return "Ã";
                case LuiIconsEnum.lui_icon_more:
                    return "¥";
                case LuiIconsEnum.lui_icon_comment:
                    return "…";
                case LuiIconsEnum.lui_icon_clear_selection:
                    return ":";
                case LuiIconsEnum.lui_icon_selectiontool:
                    return "9";
                case LuiIconsEnum.lui_icon_selection_back:
                    return "<";
                case LuiIconsEnum.lui_icon_selection_forward:
                    return "=";
                case LuiIconsEnum.lui_icon_remove:
                    return "E";
                case LuiIconsEnum.lui_icon_lock:
                    return "[";
                case LuiIconsEnum.lui_icon_unlock:
                    return "\\";
                case LuiIconsEnum.lui_icon_select_all:
                    return "|";
                case LuiIconsEnum.lui_icon_excluded:
                    return "x";
                case LuiIconsEnum.lui_icon_export:
                    return "I";
                case LuiIconsEnum.lui_icon_database:
                    return "H";
                case LuiIconsEnum.lui_icon_box:
                    return "ò";
                case LuiIconsEnum.lui_icon_drop:
                    return "∑";
                case LuiIconsEnum.lui_icon_warning_triangle:
                    return "è";
                case LuiIconsEnum.lui_icon_warning:
                    return "ù";
                case LuiIconsEnum.lui_icon_help:
                    return "D";
                default:
                    return "";                                        
            }
        }
    }
}