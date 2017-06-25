using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkyRegHtml
{
    public sealed class HtmlTemplate
    {
        internal static string singleRow = @"<tr>
                                    <td>{Lp}</td>
                                    <td class='text-center'>{UserName}</td>
                                    <td class='text-right'>{ParachuteType}</td>
                                    <td class='text-center'>{UserType}</td>
                                    </tr>";

        internal static string style = @"<style>
    .invoice-title h2,
    .invoice-title h3 {
        display: inline-block;
    }
    
    .table>tbody>tr>.no-line {
        border-top: none;
    }
    
    .table>thead>tr>.no-line {
        border-bottom: none;
    }
    
    .table>tbody>tr>.thick-line {
        border-top: 2px solid;
    }
</style>";
        internal static string TempalteHtml = @"
<div class='container'>
    <div class='row'>
        <div class='col-xs-12'>
            <div class='invoice-title'>
                <h2>Lot: {FlightNr} Lotnisko: {Airport} Samolot: {Airplane}</h2>
                </h2>
                <h3 class='pull-right'>Data: {FlyDate}</h3>
            </div>
            <hr>
        </div>
    </div>

    <div class='row'>
        <div class='col-md-12'>
            <div class='panel panel-default'>
                <div class='panel-heading'>
                    <h3 class='panel-title'><strong>Lista załadowcza</strong></h3>
                </div>
                <div class='panel-body'>
                    <div class='table-responsive'>
                        <table class='table table-condensed'>
                            <thead>
                                <tr>
                                    <td><strong>LP</strong></td>
                                    <td class='text-center'><strong>Nazwisko i imię</strong></td>
                                    <td class='text-center'><strong>Spachron</strong></td>
                                    <td class='text-right'><strong>Typ</strong></td>
                                </tr>
                            </thead>
                            <tbody>

                               {singleRow}

                            </tbody>
                        </table>
                    </div>
                </div>
            </div>
        </div>
    </div>
</div>";
    }
}
