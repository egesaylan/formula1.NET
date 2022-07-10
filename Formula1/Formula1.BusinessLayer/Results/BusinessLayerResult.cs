using Formula1.Entities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Formula1.BusinessLayer.Results
{
    public class BusinessLayerResult<T> where T: class
    {
        public List<ErrorMessageO> Errors { get; set; }
        public T Result { get; set; }

        public BusinessLayerResult()
        {
            Errors = new List<ErrorMessageO>();
        }

        public void AddError (ErrorMessage code, string message)
        {
            Errors.Add(new ErrorMessageO() { Code = code, Message = message });
        }
    }
}
