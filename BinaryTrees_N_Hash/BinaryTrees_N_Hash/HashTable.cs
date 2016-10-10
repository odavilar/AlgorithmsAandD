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
        public Node[] au32Array;

        /* Constructor */
        public HashTable()
        {
            au32Array = new Node[HTConst.u32DefaultSize];
            Console.WriteLine("HashTable with size " + HTConst.u32DefaultSize + " has been created");
        }

        public HashTable(UInt32 u32Size)
        {
            au32Array = new Node[u32Size];
            Console.WriteLine("HashTable with size " + u32Size + "has been created");
        }

        private uint HashFunction(UInt32 u32ID)
        {
            return FNV1a.u32Compute(u32ID) % (UInt32)au32Array.Length;
        }

        /* Destructor */
        ~HashTable()
        {
            Console.WriteLine("HashTable Destroyed");
        }

        public void Add(Node cNode)
        {
            UInt32 u32HashTableIndex = 0;
            u32HashTableIndex = HashFunction(cNode.uGetID());
            if (au32Array[u32HashTableIndex] == null)
            {
                au32Array[u32HashTableIndex] = cNode;
                Console.WriteLine("Index Empty");
            }
            else
            {
                Console.WriteLine("Index Already Used");
            }
        }

        public void Delete(UInt32 u32ID)
        {
            UInt32 u32HashTableIndex = 0;

            u32HashTableIndex = HashFunction(u32ID);

            if (au32Array[u32HashTableIndex] == null)
            {
                Console.WriteLine("Not Found");
            }
            else
            {
                au32Array[u32HashTableIndex] = null;
                Console.WriteLine("Deleted");
            }
        }

        public Node Search(UInt32 u32ID)
        {
            UInt32 u32HashTableIndex = 0;
            u32HashTableIndex = HashFunction(u32ID);
            return au32Array[u32HashTableIndex];
        }
    }

    static class FNV1a
    {
        /* http://www.isthe.com/chongo/tech/comp/fnv/index.html */
        /* 32 bit FNV_prime = 224 + 28 + 0x93 = 16777619 */
        /* 32 bit offset_basis = 2166136261 */

        static public UInt32 u32Compute(UInt32 u32ID)
        {
            UInt32 u32Hash = 0;
            byte[] au8Byte;
            const UInt32 u32FNVprime = 16777619;
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
