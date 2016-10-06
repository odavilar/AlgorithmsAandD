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

    static class HelperFuncs
    {
        public static bool HasMethod(this object objectToCheck, string methodName)
        {
            try
            {
                var type = objectToCheck.GetType();
                return type.GetMethod(methodName) != null;
            }
            catch (AmbiguousMatchException)
            {
                return true;
            }
        }

        public static bool HasProperty(this object objectToCheck, string propertyName)
        {
            try
            {
                var type = objectToCheck.GetType();
                return type.GetProperty(propertyName) != null;
            }
            catch (AmbiguousMatchException)
            {
                return true;
            }
        }
    }

    public class HashTable<T>
    {
        public T[] tArray;
        /* Constructor */
        public HashTable()
        {
            tArray = new T[HTConst.u32DefaultSize];
            if(tArray[0].GetType() != typeof(int))
            {
                if (!HelperFuncs.HasProperty(tArray[0], "id"))
                {
                    throw new ArgumentException("Object type not support; missing property id.");
                }
            }

            Console.WriteLine("HashTable with size " + HTConst.u32DefaultSize + "has been created");
        }

        /* Destructor */
        ~HashTable()
        {
            Console.WriteLine("HashTable Destroyed");
        }

        public int Add(T tObject)
        {
            int i32Error = 0;

            return i32Error;
        }

        public int Delete(T tObject)
        {
            return 0;
        }

        public int Search(T tObject)
        {
            return 0;
        }
    }
}
