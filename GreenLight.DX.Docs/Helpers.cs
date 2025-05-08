using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreenLight.DX.Docs
{
    public static class Helpers
    {
        public static string GenerateMarkdownLink(string label, string reference)
        {
            return string.Format("[{0}]({1})", label, reference);
        }
        public static string GenerateMarkdownTable(DataTable table)
        {
            string output = "| ";
            foreach (DataColumn col in table.Columns)
            {
                output += col.ColumnName + " | ";
            }
            output = output.Trim() + "\n| " + string.Join("|", Enumerable.Range(0, table.Columns.Count).Select(x => " --- ")) + " |\n";
            foreach (DataRow row in table.Rows)
            {
                output += "| ";
                foreach (DataColumn col in table.Columns)
                {
                    output += row[col].ToString() + " | ";
                }
                output = output.Trim() + "\n";
            }
            return output;
        }

        public static string GenerateMarkdownTable(IEnumerable<object> list, string listName)
        {
            string output = "| " + listName + " |" + Environment.NewLine +
                "| --- |" + Environment.NewLine;

            foreach (object item in list)
            {
                output += "| " + item.ToString() + " |" + Environment.NewLine;

            }
            return output;
        }
    }
}
