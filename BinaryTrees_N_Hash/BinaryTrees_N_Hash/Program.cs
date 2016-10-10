using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinaryTrees_N_Hash
{
    class Program
    {
        static void Main(string[] args)
        {
            HashTable myHT = new HashTable();
            string cKey;
            string sID;

            cKey = Console.ReadLine();
            while (cKey != "q")
            {
                if (cKey == "s")
                {
                    Node cTNode;
                    Console.Write("Enter an ID to Search ");
                    sID = Console.ReadLine();
                    cTNode = myHT.Search(Convert.ToUInt32(sID));
                    if (cTNode != null)
                    {
                        Console.WriteLine(cTNode.u32ID);
                    }
                    else { Console.WriteLine("Not found"); }
                }
                else if(cKey == "d")
                {
                    Console.Write("Enter an ID to Delete ");
                    sID = Console.ReadLine();
                    myHT.Delete(Convert.ToUInt32(sID));
                }
                else
                {
                    myHT.Add(new Node());
                }
                cKey = Console.ReadLine();
            }
        }
    }
}
