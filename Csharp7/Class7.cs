using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Csharp7
{

    public class Prop
    {
        public Prop(string name1, string path1, bool folder1)
        {
            name = name1;
            path = path1;
            papka = folder1;
        }
        public string name;
        public string path;
        public bool papka;
    }
    public static class Papka
    {
        public static List<Prop> Get(string path)
        {
            List<Prop> propers = new List<Prop>();
            foreach (string file in Directory.GetFiles(path))
                propers.Add(new Prop(file, file, false));
            foreach (string file in Directory.GetDirectories(path))
                propers.Add(new Prop(file, file, true));
            return propers;
        }
    }

    public class Strelka
    {
        public int pos;
        public int minpos;
        public int maxpos;
    }
}

