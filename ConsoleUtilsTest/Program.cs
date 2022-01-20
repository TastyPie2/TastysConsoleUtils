using static TastysConsoleUtils.Writer;
using static TastysConsoleUtils.Prompts;

class Program
{
    static void Main()
    {
        WriteLines(new string[] {"Wow", "alternating", "colors", "do you like it?" });
        
        if(YesNoArrowPrompt(false))
        {
            WriteLine("Thanks.");
        }
        else
        {
            WriteLine("Well i guess its needs more work.");
        }

        PromptOptions(new string[] { "Eine", "Zwei", "Drei" });
    }
}
