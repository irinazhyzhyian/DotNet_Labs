using System;
using System.Runtime.Serialization;

namespace Lab6
{
    internal class InvalidCoupleArguments : Exception
    {

        public InvalidCoupleArguments(string message) : base(message)
        {
        }

    }
}