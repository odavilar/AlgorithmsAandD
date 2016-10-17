using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

namespace BinaryTrees_N_Hash
{
    static class HTConst
    {
        public const int u32DefaultSize = 5;
    }

    public class HashTable
    {
        public BTree[] acArray;

        /* Constructor */
        public HashTable()
        {
            acArray = new BTree[HTConst.u32DefaultSize];
        }

        public HashTable(UInt32 u32Size)
        {
            acArray = new BTree[u32Size];
        }

        private uint HashFunction(UInt32 u32ID)
        {
            return FNV1a.u32Compute(u32ID) % (UInt32)acArray.Length;
        }

        /* Destructor */
        ~HashTable()
        {
        }

        public void Add(Node cNode)
        {
            UInt32 u32HashTableIndex = 0;
            u32HashTableIndex = HashFunction(cNode.uGetID());
            if (acArray[u32HashTableIndex] == null)
            {
                acArray[u32HashTableIndex] = new BTree();
            }
            acArray[u32HashTableIndex].vInsertData(cNode);
        }

        public void Delete(UInt32 u32ID)
        {
            UInt32 u32HashTableIndex = 0;

            u32HashTableIndex = HashFunction(u32ID);
            if (acArray[u32HashTableIndex].bDeleteData(u32ID))
            {
                Console.WriteLine("Deleted");
            }
            else
            {
                Console.WriteLine("Not Found");
            }
        }

        public Node cSearchUser(string sName, string sLastName)
        {
            UInt32 u32HashTableIndex = 0;
            Node   cFound            = new Node();
            uint   u32ID             = cFound.uGenerateID(sName, sLastName);
            u32HashTableIndex        = HashFunction(u32ID);

            if (null != acArray[u32HashTableIndex])
            {
                cFound = acArray[u32HashTableIndex].cGetNode(u32ID);
            }

            return cFound;
        }

        public Node Search(UInt32 u32ID)
        {
            UInt32 u32HashTableIndex = 0;
            u32HashTableIndex = HashFunction(u32ID);
            return acArray[u32HashTableIndex].cGetNode(u32ID);
        }
    }

    static class FNV1a
    {
        /* http://www.isthe.com/chongo/tech/comp/fnv/index.html */
        /* 32 bit FNV_prime    = 224 + 28 + 0x93 = 16777619 */
        /* 32 bit offset_basis = 2166136261 */

        static public UInt32 u32Compute(UInt32 u32ID)
        {
            UInt32 u32Hash = 0;
            byte[] au8Byte;
            const UInt32 u32FNVprime    = 16777619;
            const UInt32 u32OffsetBasis = 2166136261;

            au8Byte = BitConverter.GetBytes(u32ID);
            u32Hash = u32OffsetBasis;
            for (var i = 0; i < au8Byte.Length; i++)
            {
                u32Hash = u32Hash ^ au8Byte[i];
                u32Hash = u32Hash * u32FNVprime;
            }

            return u32Hash;
        }
    }
}
