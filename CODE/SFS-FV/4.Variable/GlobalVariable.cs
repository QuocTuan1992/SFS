using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SFS_FV
{
   public  class GlobalVariable
    {

        public LisPLC Device;
        public AreaKey AreaKey;
        public string bit, Area;
        public string Name, Val;
        public isBit isBit;
        public typeBit typeBit;
        public typeVariable typeVariable;
        //  public ListVariables ListVariables;
        public GlobalVariable(string Name, LisPLC Device, string Area, string bit, string Val, isBit isBit, typeBit typeBit, typeVariable typeVariable)
        {
            this.Device = Device;
            this.Area = Area;
            this.bit = bit;
            this.Val = Val;
            this.isBit = isBit;
            this.typeBit = typeBit;
            this.Name = Name;
            this.typeVariable = typeVariable;
        }
    }
}
