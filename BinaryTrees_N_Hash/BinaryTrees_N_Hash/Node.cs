using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinaryTrees_N_Hash
{
    public class Node
    {
        /* Structs */
        public struct UserInfo
        {
            string sName;
            string sAddress;
            string sPhone;
        }

        /* Data Members */
        public  uint     u32ID;
        public  Node     pLeft;
        public  Node     pRight;
        private UserInfo stUserInfo;

        /* Functions */
        public Node()
        {
            Random getRandom = new Random();
            u32ID = (UInt32)getRandom.Next(1000);
            Console.WriteLine("NODE Created with ID " + u32ID);
        }

        ~Node()
        {

        }
    }
}
