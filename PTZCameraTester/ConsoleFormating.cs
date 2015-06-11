using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PTZCameraTester
{
    class ConForm
    {
        public static string AddColor(string text, string color)
        {
            return "<span style='color:" + color + "'>" + text + "</span>";
        }

        public static string AddSize(string text, int size)
        {
            string sSize = size.ToString();
            return "<span style='font-size:" + sSize + "px'>" + text + "</span>";
        }

        public static string AddColorAndSize(string text, string color, int size)
        {
            string sSize = size.ToString();
            return "<span style='text-size:" + sSize + "px;color:"+color+"'>" + text + "</span>";
        }

        public static string AddBold(string text)
        {
            return "<strong>" + text + "</strong>";
        }

        public static string AddUnderline(string text)
        {
            return "<em>" + text + "</em>";
        }

        public static string AddImage(string url)
        {
            return "<img src='"+url+"' />";
        }

        public static string LineFinalize(string text)
        {
            return "<tr><td valign='top' align='left'>" + DateTime.Now.ToString() + "</td> <td align='left'>" + text + "</td></tr>";
        }

        public static string TabSpace = "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;";

        public static string FileStart = "<table cellpadding='2' cellspacing='2' width='100%'><tr><th width='170'>Time</th><th>Log Message</th></tr>";

        public static string FileEnd = "</table>";

        //Output Results
        public static string ResultsCSS = @"<style>
.entry { padding:3px; width:700px;}
.entry div{ padding:1px 5px;}
.entry .one{float:left;width:125px;}
.entry .two{margin-left:138px;width:550px;}
.Success {background-color:#00C227;}
.Success .one {background-color:#7DFF97;color:#007818;}
.Warning {background-color:#B2C200;}
.Warning .one {background-color:#F4FF7D;color:#6E7800;}
.Failure {background-color:#C20000;}
.Failure .one {background-color:#FF7D7D;color:#780000;}
.Disabled {background-color:#333;}
.Disabled .one {background-color:#ccc;color:#333;}
.clear{clear:both;}
.two {background-color:#FFFFFF;}
.resrow td{ padding:3px;}
h3 {margin:1px;}
</style>";

        public static string ResultGroupTemplate = @"<h2>{groupname}</h2>";

        public static string ResultTemplate = @"<div class='entry {status}'>	
	<div class='one' align='center'> 
		<strong>{status}</strong> 
	</div>
	<div class='two'><h3>{testname}</h3>{testresult}</div>
</div>";

        public static string ResultsHeaderTemplate = @"<h1>Test Suite Complete</h1><table cellpadding='0' cellspacing='2' width='600'>
	<tr>
		<td colspan='3'><strong>Total Tests run: {total}</strong></td>
	</tr>
	<tr class='resrow'>
		<td class='Success' width='25%'><div class='one'>Successful: {success}</div></td>
		<td class='Warning' width='25%'><div class='one'>Warning: {warn}</div></td>
		<td class='Failure' width='25%'><div class='one'>Failed: {fail}</div></td>
		<td class='Disabled' width='25%'><div class='one'>Skipped: {disabled}</div></td>
	</tr>
</table>";
        
        public static String ParseResultIntoTemplate(ResultTypes type, String test_name, String test_info)
        {
            String result = ResultTemplate;
            result = result.Replace("{status}", ResultTypeToString(type));
            result = result.Replace("{testname}", test_name);
            result = result.Replace("{testresult}", test_info);
            return result;
        }

        public static String ParseGroupIntoTemplate(String title)
        {
            String result = ResultGroupTemplate;
            result = result.Replace("{groupname}", title);
            return result;
        }

        public static String ParseHeaderIntoTemplate(int success, int warn, int fail, int disabled)
        {
            String result = ResultsHeaderTemplate;
            result = result.Replace("{total}", (success+warn+fail).ToString());
            result = result.Replace("{success}", success.ToString());
            result = result.Replace("{warn}", warn.ToString());
            result = result.Replace("{fail}", fail.ToString());
            result = result.Replace("{disabled}", disabled.ToString());
            return result;
        }

        static String ResultTypeToString(ResultTypes type)
        {
            switch (type)
            {
                case ResultTypes.Failure:
                    return "Failure";
                case ResultTypes.Success:
                    return "Success";
                case ResultTypes.Warning:
                    return "Warning";
                case ResultTypes.Disabled:
                    return "Disabled";
                default:
                    return "";
           }
        }

        public enum ResultTypes {
            Success,
            Warning,
            Failure,
            Disabled,
        };
    }
}
