using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.Models
{
    public class AllEvaluationForManager
    {
        public int ManagerId { get; set; }
        public string ManagerName { get; set; }
        public string ManagerEmail { get; set; }
        public string ManagerRole { get; set; }
        public List<AllEvaluationForOneEmployeeModel> allEvaluationForOneEmployeeModelsList { get; set; }   
    }
}
