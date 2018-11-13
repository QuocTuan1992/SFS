using SFS_FV.Local;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SFS_FV
{
  public  class ListVariables
    {
        public LisPLC Device;
        public AreaKey AreaKey;
        public string bit, Area;
        public string Name,Val="0";
        public isBit isBit;
        public typeBit typeBit;
        public typeVariable2 typeVariable;
        public CycleTime CycleTime;
        public Yield Yield;
        //  public ListVariables ListVariables;
        public ListVariables(string Name,LisPLC Device, string  Area,string bit,string Val, isBit isBit,typeBit typeBit,typeVariable2 typeVariable)
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
       // public CycleTime LocalVariable;
        
        public ListVariables(CycleTime CycleTime, typeVariable2 typeVariable)
        {
            this.CycleTime = CycleTime;
            this.typeVariable = typeVariable;
        }
        public LostTime LostTime;
        public ListVariables(LostTime LostTime, typeVariable2 typeVariable)
        {
            this.LostTime = LostTime;
            this.typeVariable = typeVariable;
        }
        public ListVariables(Yield Yield, typeVariable2 typeVariable)
        {
            this.Yield = Yield;
            this.typeVariable = typeVariable;
        }

    }
}
