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
            Console.WriteLine("Q: Quit | S: Search | D: Delete | Add node ");
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
                        Console.WriteLine(cTNode.sGetName());
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
                    uint name;
                    Random getRandom = new Random();
                    name = (UInt32)getRandom.Next(1000);
                    Console.WriteLine("NODE Created with ID " + name);
                    myHT.Add(new Node(name.ToString(), "LastName", "Address", "36XXXXXX", "33XXXXXXXX"));
                }
                cKey = Console.ReadLine();
            }
        }
    }
}
