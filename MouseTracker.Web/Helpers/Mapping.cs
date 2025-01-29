using MouseTracker.Domain.Models;
using MouseTracker.Web.Models;

namespace MouseTracker.Web.Helpers
{
    public static class Mapping
    {
        public static MouseData ToMouseData(this MouseDataVM mouseDataVM)
        {
            return new MouseData
            {
                X = mouseDataVM.X,
                Y = mouseDataVM.Y,
                T = mouseDataVM.T
            };
        }

        public static List<MouseData> ToMouseDataList(this List<MouseDataVM> mouseDataVM)
        {
            var MouseDataList = new List<MouseData>();
            foreach (var mouseData in mouseDataVM)
                MouseDataList.Add(ToMouseData(mouseData));

            return MouseDataList;
        }
    }
}
