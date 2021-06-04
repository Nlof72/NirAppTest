using System;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;
using System.Globalization;

namespace ConsoleApp8
{
    class Generator
    {
        string NameSpaceName;
        string ClassName;
        string LibInclude;
        string path;
        string FileName;
        string FolderInApp;

        public Generator( string NameSpaceName, string ClassName, string LibInclude, string path, string FileName, string FolderInApp)
        {
            //Желаемый НеймСпейс
            //this.NameSpaceName = "MatplotLibCLR";
            this.NameSpaceName = NameSpaceName;
            //Желаемы КлассНейм
            //this.ClassName = "Graph";
            this.ClassName = ClassName;
            //То как библиотека подключется в файле
            //this.LibInclude = "#include <matplot/matplot.h>";
            this.LibInclude = LibInclude;
            //Путь для обёртываемого файла
            //string path = @"D:\matplotplusplus 1.0.1\include\matplot\freestanding";
            //this.path = @"..\..\..\..\..\matplotplusplus 1.0.1\include\matplot\freestanding";
            this.path = path;
            //Название обёртываемого файла
            //this.FileName = "plot.h";
            this.FileName = FileName;
            //this.FolderInApp = "Wrapp\\";
            this.FolderInApp = FolderInApp + "\\";
        }

        public void Run()
        {



            //Выходной путь
            string OutPutPath = @$"..\..\..\..\..\{FolderInApp}Wrapped{FileName}";
            string[] directoria = Directory.GetFiles(path);
            string[] files = new string[directoria.Length];



            //Словарь для типов данных
            Dictionary<string, string> dictionary = new Dictionary<string, string>()
            {
                { "auto", "auto"},
                { "double", "double"},
                { "std::string", "std::string"},
                {"std::vector","array" },
                {"std::array","array" },
                {"std::string_view", "System::String^"},
            };

            //Словарь того какой должна быть обёртка данного типа данных
            Dictionary<string, string> Wrapper = new Dictionary<string, string>()
            {
                {"std::vector","({0}->Length);\n\t\t\t\tfor (int i = 0; i < {0}->Length; i++) { \n\t\t\t\t\t{1}[i] = {0}[i];\n\t\t\t\t}" },
                {"std::string_view"," = (char*)(void*)Marshal::StringToHGlobalAnsi({0});" },
                {"double"," = {0};" },
                {"std::string"," = {0};" },
                {"std::array"," = { " },
            };

            //Reading last file(should be plot.h)
            //StreamReader streamReader = new StreamReader(path + "\\" + files[^1]);
            StreamReader streamReader = new StreamReader(path + "\\" + FileName);
            string str = "";

            List<string> strs = new List<string>();
            //Чтение файла и избавление от пробелов
            while (!streamReader.EndOfStream)
            {
                strs.Add(streamReader.ReadLine().Trim());
            }
            List<string> s = strs;

            //Чистка списка строк от не нужных или необрабатоваемых данных таких как #include тел функций и т.п.
            strs.RemoveAll(item => item == "");
            strs.RemoveAll(item => item[0] == "/".ToCharArray()[0]);
            strs.RemoveAll(item => item[0] == "*".ToCharArray()[0]);
            strs.RemoveAll(item => item[0] == "#".ToCharArray()[0]);
            strs.RemoveAll(item => item[0] == "}".ToCharArray()[0]);
            strs.RemoveAll(item => item[item.Length - 1] == ";".ToCharArray()[0]);
            strs.RemoveAll(item => item.Substring(0,6) == "return");
            strs.RemoveAll(item => item.Substring(0, 8) == "template");


            //форматирование текста под удобный формат
            for (int i = 0; i < strs.Count; i++)
            {
                if(strs[i][strs[i].Length - 1] == "{".ToCharArray()[0])
                {
                    strs[i] = strs[i].Substring(0, strs[i].Length - 2);
                }

                if (strs[i].Contains(")")) {
                    strs[i] = strs[i].Replace(")", " )");
                }
                if (strs[i].Contains("("))
                {
                    strs[i] = strs[i].Replace("(", " ( ");
                }

                if (strs[i].Contains("<"))
                {
                    int pos = strs[i].IndexOf(">")+1;
                    string a = strs[i][strs[i].IndexOf("<")..pos];
                    if (a.Contains(", "))
                    {
                        strs[i] = strs[i].Replace(a, a.Replace(", ", ",")); ;
                    }
                }

                if (strs[i].Contains("="))
                {

                    while (strs[i].Contains("{"))
                    {
                        int pos = strs[i].IndexOf("}") + 1;
                        strs[i] = strs[i].Replace(strs[i][strs[i].IndexOf("{")..pos], "");
                    }


                    while (true)
                    {
                       
                        if (strs[i].IndexOf("=") <0 ) break;
                        if (strs[i].IndexOf(",", strs[i].IndexOf("=")) < 0) break;
                        int StartPos = strs[i].IndexOf("=") - 1;
                        strs[i] = strs[i].Replace(strs[i][StartPos..strs[i].IndexOf(",", strs[i].IndexOf("="))], "");
                    }

                    while (true)
                    {
                        if (strs[i].IndexOf("=") < 0) break;
                        if (strs[i].IndexOf(")", strs[i].IndexOf("=")) < 0) break;
                        int StartPos = strs[i].IndexOf("=") - 1;
                        strs[i] = strs[i].Replace(strs[i][StartPos..strs[i].IndexOf(")", strs[i].IndexOf("="))], " ");
                    }


                }

                if (strs[i].Contains("{"))
                {
                    strs[i] = strs[i].Substring(0, strs[i].IndexOf("{"));
                }
                
            }

            //Формирование Обёртки и вставка самой ссылки на исходную библиотеку
            str += LibInclude + "\n";
            str += "#include <msclr\\marshal.h>\n#include <cmath>\n\n";
            //Вставка в обёртку неоюходимого неймспейс и того как будут обращаться к обёртке. Также создание Mock для необрабатываемых типов данных
            str += "using namespace System;\nusing namespace System::Runtime::InteropServices;\nusing namespace msclr::interop;\nusing namespace";
            if (strs[0].Substring(0, "namespace".Length) == "namespace") {
                string tmp = strs[0].Split("namespace")[1];
                str += tmp+";\n\n";
                str += strs[0].Substring(0, "namespace".Length) +
                    $" {NameSpaceName}" + "{\n";
                str += "\tpublic ref class Mock {};\n";
                str += $" \tpublic ref class {ClassName}" + 
                    "{\n" + "\tpublic:"; 
            };

            string wrd;
            string stroka;
            int counter = 0;
            string CPlusPlusData = "";
            string WrapperData = "";
            string WrappedCode = "";
            string FunkName = "";
            string TypeDate = "";
            bool CanBeUsed = true;
            int SizeMas = 0;
            string OldFunk = "";
            List<string> param = new List<string>();

            //Обёртывание функций библиотеки
            foreach (string tmp in strs)
            {
                stroka = "";
                //Разбиение строки на слова и проход по ним
                for (int i = 0; i< tmp.Split(" ").Length; i++)
                {
                       
                    wrd = tmp.Split(" ")[i];
                    if (wrd == "") continue;
                    if (wrd == " ") continue;
                    //Начало обработки функций начинающихся с inline
                    if (wrd == "inline")
                    {

                        stroka += "\n\t\t"+wrd+" ";
                        counter++;
                        continue;
                    }
                    // Тип возвращаемого значения
                    if (counter == 1)
                    {
                        stroka += dictionary["auto"] + " ";
                        counter++;
                        continue;
                    }
                    //Название функции
                    if (counter == 2)
                    {

                        FunkName = wrd;
                        stroka += char.ToUpper(wrd[0]) + wrd[1..] + "( ";
                        OldFunk = stroka;
                        counter++;
                        continue;


                    }
                    //Типы данных агрументов функции
                    if(counter == 3)
                    {
                        //Начало обработки типов c < > 
                        if (wrd.Contains("<"))
                        {
                            if (!wrd.Contains(">"))
                            {
                                TypeDate += wrd;
                                continue;
                            }
                            if (dictionary.ContainsKey(wrd.Substring(0, wrd.IndexOf("<"))))
                            {
                                if(!wrd.Contains("std::string"))
                                if (dictionary.ContainsKey(wrd.Substring(wrd.IndexOf("<")+1, wrd.IndexOf(">") - wrd.IndexOf("<")-1)))
                                {

                                    stroka += dictionary[wrd.Substring(0, wrd.IndexOf("<"))] + "<";
                                    stroka += dictionary[wrd.Substring(wrd.IndexOf("<") + 1, wrd.IndexOf(">") - wrd.IndexOf("<") - 1)];
                                    stroka += ">^ ";
                                    CPlusPlusData = wrd + " ";
                                    WrapperData = Wrapper[wrd.Substring(0, wrd.IndexOf("<"))];
                                    SizeMas = 0;
                                    counter++;
                                    continue;
                                }

                                if (wrd[0..wrd.IndexOf("<")] == "std::array")
                                {
                                    stroka += dictionary[wrd[0..wrd.IndexOf("<")]] + "<";
                                    int StartPos = wrd.IndexOf("<") + 1;

                                    stroka += dictionary[wrd[StartPos..wrd.IndexOf(",")]] + ">^";

                                    StartPos = wrd.IndexOf(",") + 1;
                                    
                                    SizeMas = int.Parse(wrd[StartPos..wrd.IndexOf(">")]);
                                    CPlusPlusData = wrd + " ";

                                    WrapperData = Wrapper[wrd.Substring(0, wrd.IndexOf("<"))];
                                    counter++;
                                    continue;
                                }
                            }
                        }

                        if (wrd == "const") continue;

                        if (wrd.Contains("("))
                        {
                            continue;
                        }

                        //Конец типов аргументов. Плюс конец самой обёртки функции
                        if (wrd.Contains(")"))
                        {
                            stroka += ")\n\t\t{";

                            if (CanBeUsed)
                            {

                                WrappedCode += "\t\t\t" + FunkName + "(";
                                foreach (var elem in param)
                                {
                                    WrappedCode += elem + ", ";
                                }
                                if (param.Count > 0)
                                {
                                    WrappedCode = WrappedCode[0..^2];
                                }

                                WrappedCode += ");";
                            }
                            WrappedCode += "\n\t\t}";

                            CanBeUsed = true;
                            stroka += "\n" + WrappedCode;
                            WrappedCode = "";
                            CPlusPlusData = "";
                            param.Clear();

                            counter = 0;
                            continue;
                        }

                        //Проверка на возможность создать обёртку иначе создаётся Mock
                        if (dictionary.ContainsKey(wrd))
                        {
                            stroka += dictionary[wrd] + " ";
                            
                            if (Wrapper.ContainsKey(wrd))
                            {
                                WrapperData = Wrapper[wrd];
                                CPlusPlusData = wrd + " ";
                            }
                            
                            counter++;
                            continue;
                        }else
                        {
                            stroka += "Mock ";

                            CPlusPlusData = "Mock";
                            counter++;
                            continue;
                        }

                    }

                    //Обработка переменных
                    if (counter == 4)
                    {
                        string variable = wrd;


                        if (CPlusPlusData == "Mock")
                        {
                            CanBeUsed = false;
                           if( variable[0] == "&".ToCharArray()[0])
                            {
                                variable = variable[1..];
                                stroka += variable + " ";
                            }
                            else
                            {
                                stroka += variable + " ";

                            }

                            counter--;
                            continue;

                        }
                        if (variable[0] == "&".ToCharArray()[0])
                        {
                            variable = wrd[1..];
                            stroka += variable+" ";

                            if (wrd.Contains(","))
                            {
                                variable = variable[0..^1];
                            }


                            CPlusPlusData += variable+"1";
                            
                            if (WrapperData.Contains("{1}"))
                            {
                                if (variable.Contains(","))
                                {
                                    variable = variable.Split(",")[0];
                                }
                                WrapperData = WrapperData.Replace("{0}",variable);
                                WrapperData = WrapperData.Replace("{1}",variable+"1");
                                param.Add(variable + "1");
                            }
                            else
                            {
                                if (variable.Contains(","))
                                {
                                    variable = variable.Split(",")[0];
                                }


                                if (CPlusPlusData.Contains("std::array"))
                                {
                                    for(int schet =0; schet< SizeMas; schet++)
                                    {
                                        WrapperData += variable + $"[{schet}], ";
                                    }
                                    WrapperData += "};";
                                    param.Add(variable + "1");
                                    WrappedCode += "\t\t\t" + CPlusPlusData + WrapperData + "\n";

                                    counter--;
                                    continue;
                                }
                                WrapperData = WrapperData.Replace("{0}", variable);
                                param.Add(variable + "1");
                            }

                            WrappedCode += "\t\t\t"+CPlusPlusData + WrapperData + "\n";
                            
                            counter--;
                            continue;
                        }
                        else
                        {
                            stroka += variable + " ";


                            if (variable.Contains(","))
                            {
                                variable = variable.Split(",")[0];
                            }
                            CPlusPlusData += variable + "1";
                            if (WrapperData.Contains("{1}"))
                            {
 
                                WrapperData = WrapperData.Replace("{0}", variable);
                                WrapperData = WrapperData.Replace("{1}", variable + "1");
                                param.Add(variable + "1");
                            }
                            else
                            {

                                if (CPlusPlusData.Contains("std::array"))
                                {
                                    int EndPos = CPlusPlusData.IndexOf("<") - 1;

                                    if (CPlusPlusData[0..EndPos] == "std::array")
                                    {
                                        for (int schet = 0; schet < SizeMas; schet++)
                                        {
                                            WrapperData += variable + "1" + $"[{schet}], ";
                                        }
                                        WrapperData += "};\n\t\t\t";
                                        param.Add(variable + "1");
                                        WrappedCode += "\t\t\t" + CPlusPlusData + WrapperData + "\n";

                                        counter--;
                                        continue;
                                    }
                                }
                                WrapperData = WrapperData.Replace("{0}", variable);
                                param.Add(variable + "1");
                            }
                            WrappedCode += "\t\t\t" + CPlusPlusData + WrapperData + "\n";
                            counter--;
                            continue;
                        }

                    }
                }

                //Ищем повторяющиеся перегруженные функции и удаляем из-за отсутствия значений по умолчанию
                if (str.Contains("inline"))
                {
                    if (stroka.Contains(")"))
                    {
                        string t = str + stroka;
                        int StartPos = t.LastIndexOf("inline");
                        int EndPos = t.IndexOf(")",StartPos) + 1;
                        //Console.WriteLine(t[StartPos..]);
                        if (str.Contains(t[StartPos..EndPos]))
                        {
                            //Console.WriteLine(1);
                            str = str.Remove(StartPos);
                            stroka = "";
                        }
                    }
                }
                str += stroka;
            }

            str += "\n\t};\n}";
            File.WriteAllText(OutPutPath, str, Encoding.UTF8);

        }
    }
}
