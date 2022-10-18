using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ВЯ
{
    internal class Program
    {
        static void Main(string[] args)
        {


            File settings = new File("настройки.config");
            Folder doc = new Folder("Мои документы", settings);

            Folder c = new Folder("C:/", doc);

            ShowIntoFolder(c, -1);

            Console.ReadKey();
        }

        public static void ShowIntoFolder(Folder folder, int otstyp)
        {
            otstyp++;
            string tab = new string(' ', otstyp * 2);
            foreach (var element in folder)
            {
                Console.WriteLine(tab + element);

                if(element is Folder)
                {
                    Folder current = element as Folder;
                    ShowIntoFolder(current, otstyp);
                }
            }
        }
    }



    interface IntoObject
    {
        string Name { get; }
    }

    class File : IntoObject
    {
        public string Name { get; set; }
        public File(string name)
        {
            Name = name;
        }

        public override string ToString()
        {
            return Name;
        }
    }

    class Folder : IntoObject
    {
        public string Name { get; set; }
        public List<IntoObject> Into { get; set; }

        public Folder(string name, params IntoObject[] into)
        {
            Into = into.ToList();
            Name = name;
        }

        public IEnumerator GetEnumerator()
        {
            return Into.GetEnumerator();
        }

        public override string ToString()
        {
            return Name;
        }
    }
}
