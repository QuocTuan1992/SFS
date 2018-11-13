using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SFS_FV
{
   public class Yield
    {
        public List<ListVariables> ListOK=new List<ListVariables>(), ListNG=new List<ListVariables>();             
        public string Name;      
        public string valYield;
        
        public Yield(string Name,string valYield, List< ListVariables> ListOK, List<ListVariables> ListNG)
        {
            this.Name = Name;
           
            this.ListOK = ListOK;
            this.ListNG = ListNG;
            this.valYield = valYield;
          
           

        }
    }
}
