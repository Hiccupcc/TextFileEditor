using System.Text.RegularExpressions; 
using System.IO; 
// I will ask about what the user would like to do here
// most likely I will have the user use numbers to select a method
int Program = 1; 
while (Program == 1) // So the program doesn't close if other letters have not been pressed
{
  Console.Clear(); 
  Console.WriteLine("A) Find how many times a word has been repeated in a sentence/paragraph. \nB) Replace existing words with new ones. \nC) Merge two text files together. \nD) Read content from a text file.\nE) Access folders.");
  if (Console.ReadKey(true).Key == ConsoleKey.A) // calls the method once A has been pressed
  {
       Console.Clear(); 
       RepeatedWord(); 
  }
  else if (Console.ReadKey(true).Key == ConsoleKey.B) // calls the method once B has been called
  { 
       Console.Clear(); 
       ChangeWord(); 
  }  
  else if (Console.ReadKey(true).Key == ConsoleKey.C) // calls the method once C has been called
  {
    Console.Clear();
    MergeFiles(); 
  }
  else if (Console.ReadKey(true).Key == ConsoleKey.D)
  {
    Console.Clear(); 
    ReadFiles(); 
  }
  else if (Console.ReadKey(true).Key == ConsoleKey.E)
  {
    Console.Clear();
   AccessFolder();
  }
  else // to avoid Console.WriteLine lines when other letters are pressed 
  {
     Console.Clear();
  }
}

static void AccessFolder()
{
  try
  {
    Console.Write("Enter the path to your directory: ");
    string path = Console.ReadLine(); 
    foreach (var SelectedDirectory in System.IO.Directory.GetDirectories(path))
    {
      var dir = new DirectoryInfo(SelectedDirectory);
      var DirectoryName = dir.Name;
      Console.WriteLine(DirectoryName+"\n");
      
    }
    Console.ReadKey(); 
  }
  catch (Exception e3)
  {
    Console.WriteLine("Something went wrong.");
    Console.ReadKey();
    return; 
  }
}

static void ReadFiles()
{
  Console.WriteLine("Enter the path of the file you want to read text from.");
  Console.ForegroundColor = ConsoleColor.Green;
      Console.WriteLine(@"Example: c:\temp\MyTest.txt");
      Console.ResetColor();
  try
  { 
  string? ChosenFile = Console.ReadLine(); 
  string FileContent = System.IO.File.ReadAllText(ChosenFile);
  Console.Clear();  
  Console.WriteLine(FileContent); 
  Console.ReadLine();
  }
  catch (Exception e2)
  {
    Console.WriteLine("Invalid path or non-existent file.");
    Console.ReadKey(); 
    return;
  }
}


static void MergeFiles()
{
  Console.WriteLine("Enter the path of the file you want to copy text from.");
  Console.ForegroundColor = ConsoleColor.Green;
      Console.WriteLine(@"Example: c:\temp\MyTest.txt");
      Console.ResetColor(); 
  try 
   {
   string? FirstPath = Console.ReadLine(); 
   string FirstPathText = System.IO.File.ReadAllText(FirstPath);
   Console.WriteLine("Enter the path of the file you want to paste text to.");
   string? SecondPath = Console.ReadLine(); 
   string SecondPathText = System.IO.File.ReadAllText(SecondPath); 
   Console.WriteLine(SecondPathText + FirstPathText); 
   Console.ReadKey();
   Console.Write("Would you like to save this as a new textfile? Y/N");
     if (Console.ReadKey(true).Key == ConsoleKey.Y)
     {
       Console.Clear(); 
      Console.WriteLine("Type the path where you want to save the text file. Please include the name you want it to be saved as");
      Console.ForegroundColor = ConsoleColor.Green;
      Console.WriteLine(@"Example: c:\temp\MyTest.txt");
      Console.ResetColor(); 
      Console.Write("Your path: ");
      string? Mpath = Console.ReadLine(); 
      string? FinishedM = FirstPathText + " " + SecondPathText; 
      File.WriteAllText(Mpath, FinishedM);
    }
    else
    {
      return; 
    }
   }
    catch (Exception e)
  {
    Console.WriteLine("Invalid path or non-existent file.");
    Console.ReadKey();
    return;
  } 
}


static void ChangeWord() //changes a word 
{
  Console.Write("Type the word that will be changed: ");
  string? ExistingWord = Console.ReadLine(); 
  Console.Write("What do you want to change it to?: ");
  string? ChangedWord = Console.ReadLine(); 
  Console.WriteLine("Insert your paragraph: "); 
  string? paragraphC = Console.ReadLine();
   if (paragraphC.Contains(@ExistingWord))
  {
    Console.Clear(); 
    Console.WriteLine(paragraphC.Replace(ExistingWord, ChangedWord)); 
    Console.ReadKey();
    Console.Write("Would you like to save this as a new textfile? Y/N");
      if (Console.ReadKey(true).Key == ConsoleKey.Y)
     {
        Console.Clear(); 
       Console.WriteLine("Type the path where you want to save the text file. Please include the name you want it to be saved as");
       Console.ForegroundColor = ConsoleColor.Green;
       Console.WriteLine(@"Example: c:\temp\MyTest.txt");
       Console.ResetColor(); 
       Console.Write("Your path: ");
       string? CPath = Console.ReadLine(); 
       File.WriteAllText(CPath, paragraphC.Replace(ExistingWord, ChangedWord));
     }
     else
     {
       return; 
     }
     Console.ReadKey(); 
    }
      else 
    {
     Console.WriteLine(ExistingWord+" is not found in your paragraph."); 
     Console.ReadKey();
     Console.Clear(); 
     ChangeWord(); 
    }
  }



static void RepeatedWord() //checks the amount of times a word has been repeated for. 
{ 
Console.Write("Type the word: ");
string? InputWordR = Console.ReadLine(); 
Console.Clear(); 
Console.WriteLine("Paste your sentence here: ");
string? InputSentenceR = Console.ReadLine(); 
Regex MatchingWordR = new Regex(@InputWordR);
var resultsR = MatchingWordR.Matches(@InputSentenceR);
Console.ForegroundColor = ConsoleColor.Green; 
Console.WriteLine("The word is repeated "+resultsR.Count+" Times!"); 
Console.ResetColor(); 
Console.ReadKey(); 
}