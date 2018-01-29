using DM.Gentlemens.Repository.Core;
using DM.Gentlemens.RepositoryAbstraction.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DM.Gentlemens.RepositoryFactory
{
    public class Getter
    {
        public static IRepositoryContext GetRepository()
        {
            //Get data from config.
            bool isADONetRepositoryRequested = true;
            if (isADONetRepositoryRequested)
                return new RepositoryContext();
            return default(IRepositoryContext);
        }
    }
}
