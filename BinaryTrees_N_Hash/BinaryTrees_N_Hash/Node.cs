using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinaryTrees_N_Hash
{
    class Node
    {
        /* Structs */
        public struct UserInfo
        {
            string sName;
            string sAddress;
            string sPhone;
        }

        /* Data Members */
        public  int      iID;
        public  Node     pLeft;
        public  Node     pRight;
        private UserInfo stUserInfo;

        /* Functions */
        public Node()
        {
            Console.WriteLine("NODE Created");
        }

        ~Node()
        {

        }
    }
}
