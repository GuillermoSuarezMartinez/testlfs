using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Orbita.Utiles;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            OTupla tupla = new OTupla();
            tupla.Add("long1", -100L);
            tupla.Add("long2", 200L);
            tupla.Add("double1", 100.100d);
            tupla.Add("double2", -222.222d);
            tupla.Add("double3", 312.333d);
            tupla.Add("string1", "ab85d_cd");
            tupla.Add("string2", "ef90.ghij");
            tupla.Add("string3", "xy$z");
            tupla.Add("int1", 100);
            tupla.Add("int2", -222);
            tupla.Add("int3", 312);
            tupla.Add("date", DateTime.Now);
            tupla.Add("bool1", true);
            tupla.Add("bool2", false);
            string str = tupla.ToString();
            OTupla tupla2 = new OTupla("demo", str);


            string strCodigos = tupla2.ToCodigoString();
            string strValores = tupla2.ToValorString();
            OTupla tupla3 = new OTupla("demo", strCodigos, strValores);
            Console.WriteLine(tupla2.ToString());
            Console.WriteLine(tupla3.ToString());
            Console.WriteLine(tupla2.ToCodigoString());
            Console.WriteLine(tupla3.ToCodigoString());
            Console.WriteLine(tupla2.ToValorString());
            Console.WriteLine(tupla3.ToValorString());
            Console.ReadKey();

        }
    }
}
