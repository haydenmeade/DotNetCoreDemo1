using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace vroom.Extensions
{
    public static class IEnumerableExtensions
    {
        public static IEnumerable<SelectListItem> ToSelectListItem<T>(this IEnumerable<T> items)
        {
            List<SelectListItem> List = new List<SelectListItem>();
            SelectListItem sli = new SelectListItem
            {
                Text = "-------Select------",
                Value = "0"
            };
            List.Add(sli);
            foreach (T item in items)
            {
                sli = new SelectListItem
                {
                    Text = item.GetType().GetProperty("Name").GetValue(item).ToString(),
                    Value = item.GetType().GetProperty("Id").GetValue(item).ToString()
                };
                List.Add(sli);
            }
            return List;
        }
    }
}
