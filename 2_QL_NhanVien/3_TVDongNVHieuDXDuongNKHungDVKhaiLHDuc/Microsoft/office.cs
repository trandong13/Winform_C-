namespace Microsoft
{
    internal class Office
    {
        internal class Interop
        {
            internal class Excel
            {
                internal class Worksheet
                {
                    public object Cells { get; internal set; }
                }

                internal class Range
                {
                }

                internal class Workbook
                {
                    public object Worksheets { get; internal set; }
                }

                internal class Application
                {
                    public bool Visible { get; internal set; }
                    public object Workbooks { get; internal set; }
                }
            }
        }
    }
}