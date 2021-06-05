using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp8
{
    class Program
    {
        static void Main(string[] args)
        {
            string NameSpaceName = "MatplotLibCLR";
            //Желаемы КлассНейм
            string ClassName = "Graph";
            //То как библиотека подключется в файле
            string LibInclude = "#include <matplot/matplot.h>";
            //Путь для обёртываемого файла
            string path = @"..\..\..\..\..\matplotplusplus 1.0.1\include\matplot\freestanding";
            //Название обёртываемого файла
            string FileName = "plot.h";
            string FolderInApp = "Wrapp";
            Generator gen = new Generator(NameSpaceName, ClassName, LibInclude, path, FileName, FolderInApp);
            gen.Run();
        }
    }
}
