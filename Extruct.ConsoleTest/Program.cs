// See https://aka.ms/new-console-template for more information
using Shell.IconExtractor;
using Shell.IconExtractor.Enumes;
using Shell.IconExtractor.Strucrure;


IcoExtractorOptions opt = new IcoExtractorOptions()
{
    path = @"C:\Users\UnderKo\Downloads\Letragon.exe",
    type = ItemType.File,
    iconSize = IconSize.ExtraLarge,
    state = ItemState.Undefined,
};
string str_newfilename = "test.png";

using (IcoExtractor extr = new IcoExtractor(opt))
{

    if (extr.SaveToFile(str_newfilename))
    {
        Console.WriteLine(extr.GetIcon?.Size.ToString());
        Console.WriteLine("Курто!");
    }
    else
    {
        Console.WriteLine("Error!");
    }



}

