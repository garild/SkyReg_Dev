using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataLayer.Result
{
    public class ResultType<T>
    {
        public ResultType()
        {
            IsSuccess = false;
        }

        public bool IsSuccess { get; set; }

        private T _value { get; set; }

        public T Value
        {
            get
            {
                return _value;
            }
            set
            {
                if (value.Equals(default(T)) || value.Equals(Activator.CreateInstance<T>()))
                {
                    IsSuccess = false;
                    _value = default(T);
                    return;
                }

                IsSuccess = true;
                _value = value;
            }
        }
    }
}
