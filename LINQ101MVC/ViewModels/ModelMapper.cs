using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Cryptography;
using System.Web;

namespace LINQ101MVC.ViewModels
{
    public class ModelMapper
    {
        // Todo: Evaluate to implement an object mapper, eg: AutoMapper
        public static void Map<T>(T source, T target)
        {
            if (source == null) return;
            foreach (var propInfo in typeof(T).GetProperties())
            {
                var targetProp = typeof(T).GetProperty(propInfo.Name);
                targetProp?.SetValue(target, propInfo.GetValue(source));
            }
        }

    }
}