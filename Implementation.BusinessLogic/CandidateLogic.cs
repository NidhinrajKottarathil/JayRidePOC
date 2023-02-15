using Contracts.BusinessLogic;
using Implementation.BusinessLogic.Base;
using Model.Candidate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Implementation.BusinessLogic
{
    public class CandidateLogic : BaseLogic, ICandidateLogic
    {
        public Candidate GetCandidateInfo()
        {
            return new Candidate { Name = "test", Phone = "test" };
        }
    }
}
