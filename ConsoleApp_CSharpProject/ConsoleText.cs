namespace ConsoleApp_CSharpProject
{
    public class ConsoleTextOptions
    {
        public bool centered = false;
        public int boxPadding = 1;
        public int wallThickness = 1;
    }
    public class ConsoleText
    {

        // A function that takes an input Array of lines to write to the console and wraps it in a box
        public static void CreateBox(string[] linesToWrite, ConsoleTextOptions? options = null)
        {
            // Checking if options was provided or not, and if not then we just create one using the default values
            options ??= new ConsoleTextOptions();

            int longestLine = linesToWrite.OrderByDescending(s => s.Length).First().Length;
            int boxWidth = ((options.wallThickness + options.boxPadding) * 2) + longestLine;

            int totalLines = linesToWrite.Length;

            // Make a string made out of - signs that is long enough to fit the longest string, padding and wall thickness
            string boxWidthLine = String.Concat(Enumerable.Repeat("-", boxWidth));

            Console.WriteLine(boxWidthLine);

            foreach (string line in linesToWrite)
            {
                int lengthDifference = longestLine - line.Length;

                string linePaddingLeft;
                string linePaddingRight;

                // Runs differently depending on if the text should be centered or not
                if (options.centered == true)
                {
                    int linePaddingAmount = options.boxPadding + (lengthDifference / 2);

                    linePaddingLeft = String.Concat(Enumerable.Repeat(" ", linePaddingAmount));
                    linePaddingRight = String.Concat(Enumerable.Repeat(" ", linePaddingAmount));

                    // This is a fix to when a string is an uneven length and will add a single " " at the end if it is, so the wall lines up
                    if (lengthDifference % 2 != 0)
                    {
                        linePaddingRight += " ";
                    }
                }
                else
                {
                    linePaddingLeft = String.Concat(Enumerable.Repeat(" ", options.boxPadding));
                    linePaddingRight = String.Concat(Enumerable.Repeat(" ", lengthDifference + options.boxPadding));
                }


                Console.WriteLine($"|{linePaddingLeft}{line}{linePaddingRight}|");
            }

            Console.WriteLine(boxWidthLine);

        }

        // Simple function to create one or more spacing lines
        public static void CreateSpacer(int amount = 1) {
            for (int i = 0; i < amount; i++) 
            {
                Console.WriteLine("");
            }
        
        }
    }
}
