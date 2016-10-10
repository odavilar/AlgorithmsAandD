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
            BTree  cTree = new BTree();
            Node[] cNode = new Node[10];

            for (int i = 0; i < 9; i++)
            {
                cNode[i] = new Node(i.ToString(), "TEST", "TEST");
                cTree.vInsertData(cNode[i]);
            }

            cTree.vPrintInorder(cTree.cGetRoot());
            Console.ReadKey();


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
                        Console.WriteLine(cTNode.uGetID());
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
