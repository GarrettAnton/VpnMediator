using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace VPNMediator
{
    class InvalidInstructionException : Exception
    {
        string invalidInstruction;
        public InvalidInstructionException (string message)
        {
            invalidInstruction = message;
        }
        public override string Message
        {
            get
            {
                return "The instruction '" + invalidInstruction  + "' does not exist";
            }
        }
    }

    class InvalidConvertExeption : Exception
    {
        string classType,pathFile;
        public InvalidConvertExeption(string classType, string pathFile)
        {
            this.classType = classType;
            this.pathFile = pathFile;
        }
        public override string Message
        {
            get
            {
                return "The file '" + pathFile + "' can not convert to class '"  + classType + "'";
            }
        }
    }

    class ListsIsEmptytExeption : Exception
    {
        string classType;
        public ListsIsEmptytExeption(string classType)
        {
            this.classType = classType;            
        }
        public override string Message
        {
            get
            {
                return "The '" + classType + "' is empty";
            }
        }
    }
}
