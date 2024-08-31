
## Shell.IconExtractor
Библиотека для экспорта иконок из приложений, файлов и прочего...

## Оишбки
Никогда не проверяйте на Ярлыках!

## Build and Include 
При сборек укажите тип проекта 
```xaml
<TargetFramework>net8.0-windows</TargetFramework>
```


Example:
```C#
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
```