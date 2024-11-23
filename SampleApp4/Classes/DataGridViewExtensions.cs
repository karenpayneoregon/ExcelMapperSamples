using System.Text.RegularExpressions;

namespace SampleApp4.Classes;

/// <summary>
/// Methods to move current row up/down
/// </summary>
public static partial class DataGridViewExtensions
{

    /// <summary>
    /// Expands the columns of the specified <see cref="DataGridView"/> to fit their content.
    /// </summary>
    /// <param name="source">The <see cref="DataGridView"/> whose columns are to be expanded.</param>
    /// <param name="sizable">
    /// A boolean value indicating whether the columns should be resizable after being expanded.
    /// If <c>true</c>, the columns will be resizable; otherwise, they will not be resizable.
    /// </param>
    public static void ExpandColumns(this DataGridView source, bool sizable = true)
    {
        foreach (DataGridViewColumn col in source.Columns)
        {
            if (col.ValueType.Name != "ICollection`1")
            {
                col.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            }
        }

        if (!sizable) return;

        for (int index = 0; index <= source.Columns.Count - 1; index++)
        {
            int columnWidth = source.Columns[index].Width;

            source.Columns[index].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;

            // Set Width to calculated AutoSize value:
            source.Columns[index].Width = columnWidth;
        }
    }
    /// <summary>
    /// Split on upper-cased letters
    /// </summary>
    /// <param name="source"></param>
    public static void FixHeaders(this DataGridView source)
    {
        string SplitCamelCase(string sender)
            => string.Join(" ", SplitCamelCaseRegex().Matches(sender).Select(m => m.Value));

        for (int index = 0; index < source.Columns.Count; index++)
        {
            source.Columns[index].HeaderText = SplitCamelCase(source.Columns[index].HeaderText);
        }
    }

    [GeneratedRegex(@"([A-Z][a-z]+)")]
    private static partial Regex SplitCamelCaseRegex();
}