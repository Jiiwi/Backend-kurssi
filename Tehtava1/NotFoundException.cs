using System;

namespace Tehtava1
{
    public class NotFoundException : Exception 
    {
        public NotFoundException() : base("Station not found")
        {
            
        }
    }


}