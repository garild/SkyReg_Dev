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
        public string Error { get; set; }

        private T _value { get; set; }
        public bool IsError { get; set; }

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
                    IsError = true;
                    Error = "Brak danych.";
                    _value = default(T);
                    return;
                }

                IsSuccess = true;
                _value = value;
                IsError = false;
                Error = string.Empty;
            }
        }
    }

    public class ColletionResult<T>
    {
        public ColletionResult()
        {
            IsSuccess = false;
        }

        public bool IsSuccess { get; set; }
        public string Error { get; set; }


        private List<T> _value { get; set; }
        public bool IsError { get; set; } 

        public List<T> Value
        {
            get
            {
                return _value;
            }
            set
            {
                if (value == null || value.Count == 0)
                {
                    IsSuccess = false;
                    IsError = true;
                    Error = "Brak danych.";
                    _value = new List<T>();
                    return;
                }

                IsSuccess = true;
                _value = value;
                IsError = false;
                Error = string.Empty;
            }
        }
    }
}
