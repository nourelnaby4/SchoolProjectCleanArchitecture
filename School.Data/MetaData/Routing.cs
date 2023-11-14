using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School.Data.MetaData
{
    public static class Routing
    {
        public const string root = $"Api/v1";
    }



    public static class StudentRouting
    {
        public const string Prefix = $"{Routing.root}/Student";
        public const string GetAll = $"{Prefix}";
        public const string GetById = $"{Prefix}/" + "{id}";
        public const string Paginated = $"{Prefix}/" +"Paginated";

    }
}
