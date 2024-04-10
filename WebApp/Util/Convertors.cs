using MudBlazor;
using System.Text;

namespace WebApp.Util
{
    public static class Convertors
    {
        public static string GetParameterString<T>(this GridState<T> gridState)
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append("?");
            foreach (var item in gridState.FilterDefinitions)
            {
                stringBuilder.AppendFormat("{0}={1}&", item.Column, item.Value);
            }
            stringBuilder.AppendFormat("{0}={1}&", nameof(gridState.PageSize), gridState.PageSize);
            stringBuilder.AppendFormat("{0}={1}", nameof(gridState.Page), gridState.Page+1);
            return stringBuilder.ToString();

        }
    }
}
