using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkyReg.Common.Prints.DaysSum
{
    public sealed class HtmlTemplate
    {
        internal static string singleRow = @"<tr>
                                    <td style='width:100px; text-align:left'><strong>{Element1}</strong></td>
                                    <td style='width:80px; text-align:right'>{Element2}</td>
                                    </tr>";
        internal static string UserTypesRow = @"<tr>
                                    <td style='width:200px; text-align:left'><strong>{Element1}</strong></td>
                                    <td style='width:80px; text-align:right'>{Element2}</td>
                                    <td style='width:80px; text-align:right'>{Element3}</td>
                                    <td style='width:80px; text-align:right'>{Element4}</td>
                                    </tr>";
        internal static string AssemblyRow = @"<tr>
                                    <td style='width:80px; text-align:right'><strong>{Element1}</strong></td>
                                    <td style='width:80px; text-align:right'>{Element2}</td>
                                    <td style='width:80px; text-align:right'>{Element3}</td>
                                    </tr>";
        internal static string PilotsRow = @"<tr>
                                    <td style='width:200px; text-align:left'>{Element1}</td>
                                    <td style='width:200px; text-align:left'>{Element2}</td>
                                    <td style='width:80px; text-align:right'>{Element3}</td>
                                    <td style='width:80px; text-align:right'>{Element4}</td>
                                    <td style='width:80px; text-align:right'>{Element5}</td>
                                    </tr>";
        internal static string CameraRow = @"<tr>
                                    <td style='width:200px; text-align:left'><strong>{Element1}</strong></td>
                                    <td style='width:80px; text-align:right'>{Element2}</td>
                                    <td style='width:80px; text-align:right'>{Element3}</td>
                                    <td style='width:80px; text-align:right'>{Element4}</td>
                                    </tr>";

        internal static string TempalteHtml = @"
<div class='container'>
    <div class='row'>
        <div class='col-xs-12'>
            <div class='invoice-title'>
                <h2>Zestawienie za okres od {DateSince} do {DateTo} </h2>
            </div>
            <hr>
            <div class='invoice-title'>
            <p><strong>Zestawienie KP/KW</strong></p>
            </div>
        </div>
    </div>
</div>";

        internal static string TableStart = @"<table class='table table-condensed' border = 1>";
        internal static string TableEnd = @"</table>";
        internal static string DrawLine = @"<hr>";
        internal static string Title = @"
<div class='invoice-title'>
    <p><strong>
        {Title}
    </strong></p>
</div>";


    }
}
