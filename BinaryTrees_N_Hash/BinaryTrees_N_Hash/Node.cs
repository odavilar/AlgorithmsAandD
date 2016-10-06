using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinaryTrees_N_Hash
{

    /* Structs */
    struct UserInfo
    {
        public string sName;
        public string sAddress;
        public string sPhone;
    }

    /* Node Class */
    class Node
    {
        /* Unique ID Generator */
        private uint uUniqueID = 1U;

        /* Data Members */
        public  uint     uID;
        public  Node     pLeft;
        public  Node     pRight;
        private UserInfo stUserInfo;

        /* Functions */
        public Node()
        {
            uID    = uUniqueID++;
            pLeft  = null;
            pRight = null;
            stUserInfo.sAddress = "";
            stUserInfo.sName    = "";
            stUserInfo.sPhone   = "";
            Console.WriteLine("Node " + uID);
        }

        ~Node()
        {

        }
    }
}
