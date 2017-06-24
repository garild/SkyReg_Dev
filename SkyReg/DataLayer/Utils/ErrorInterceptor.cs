using System.Data.Entity.Infrastructure;
using System.Data.SqlClient;

namespace DataLayer
{

    public class ErrorInterceptor
    {
        public static int GetErrorCode(DbUpdateException e)
        {
            SqlException sql = e.InnerException.InnerException as SqlException;
            return sql.Number;
        }

        public static bool IsDuplicateInsertError(DbUpdateException e)
        {
            return GetErrorCode(e) == 2601;
        }

        public static bool IsUniqueConstraint(DbUpdateException e)
        {
            return GetErrorCode(e) == 2627;
        }

        public static bool IsForeignKeyError(DbUpdateException e)
        {
            return GetErrorCode(e) == 547;
        }

        //    public static void ErrorHandler(FormatException ex, Form form)
        //    {
        //        StackTrace stackTrace = new StackTrace();
        //        if (AppSettings.GreenSysConnection)
        //        {
        //            GreenSysDataLayer.Log logs = new GreenSysDataLayer.Log();
        //            logs.UserId = AppSettings.LoggedUserId;
        //            logs.TypeId = 1;
        //            logs.DepotId = AppSettings.DepotId;
        //            logs.ApplicationName = "Green - " + form.Name;
        //            logs.ObjectId = 0;
        //            logs.ObjectValue = ex.Message.ToString();
        //            logs.OldValue = "Metoda : " + stackTrace.GetFrame(1).GetMethod().Name.ToString();
        //            logs.NewValue = ex.GetType().Name.ToString();
        //            logs.ComputerName = Environment.MachineName.ToString();

        //            logs.Add();
        //            KryptonMessageBox.Show("Wystąpił nieoczekiwany błąd w aplikacji Green. Błąd ten został zapisany w centralnej bazie Speedmail w celu naprawy.", "Informacja", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
        //        }
        //        else
        //            KryptonMessageBox.Show("Brak połączenia z siecią.", "Informacja", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
        //    }
        //    public static void ErrorHandler(Exception Ex, string methodName)
        //    {
        //        StringBuilder baseBuilder = new StringBuilder();
        //        StringBuilder innerExceptionBuilder = new StringBuilder();
        //        if (Ex != null)
        //        {
        //            baseBuilder.AppendLine("BASE - Exception type: " + Ex.GetType().FullName);
        //            baseBuilder.AppendLine("Message       : " + Ex.Message);
        //            baseBuilder.AppendLine("Stacktrace:");
        //            baseBuilder.AppendLine(Ex.StackTrace);
        //            baseBuilder.AppendLine("TargetSite:");
        //            baseBuilder.AppendLine();
        //        }
        //        if (Ex.InnerException != null)
        //        {
        //            innerExceptionBuilder.AppendLine("InnerException - type: " + Ex.InnerException.GetType().FullName);
        //            innerExceptionBuilder.AppendLine("Message       : " + Ex.InnerException.Message);
        //            innerExceptionBuilder.AppendLine("Stacktrace:");
        //            innerExceptionBuilder.AppendLine(Ex.InnerException.StackTrace);
        //            innerExceptionBuilder.AppendLine("TargetSite:");
        //            innerExceptionBuilder.AppendLine();
        //        }

        //        if (AppSettings.GreenSysConnection)
        //        {
        //            GreenSysDataLayer.Log logs = new GreenSysDataLayer.Log();
        //            logs.UserId = AppSettings.LoggedUserId;
        //            logs.TypeId = 1;
        //            logs.DepotId = AppSettings.DepotId;
        //            logs.ApplicationName = "Green - " + methodName;
        //            logs.ObjectId = 0;
        //            logs.ObjectValue = "";
        //            logs.OldValue = baseBuilder.ToString();
        //            logs.NewValue = innerExceptionBuilder.ToString();
        //            logs.ComputerName = Environment.MachineName.ToString();

        //            logs.Add();
        //            KryptonMessageBox.Show("Wystąpił nieoczekiwany błąd w aplikacji Green. Błąd ten został zapisany w centralnej bazie Speedmail w celu naprawy.", "Informacja", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
        //        }
        //        else
        //            KryptonMessageBox.Show("Brak połączenia z siecią.", "Informacja", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
        //    }

        //    public static void SqlErrorHandle(SqlException ex, Form form)
        //    {
        //        StackTrace stackTrace = new StackTrace();
        //        if (AppSettings.GreenSysConnection)
        //        {
        //            GreenSysDataLayer.Log logs = new GreenSysDataLayer.Log();
        //            logs.UserId = AppSettings.LoggedUserId;
        //            logs.TypeId = 1;
        //            logs.DepotId = AppSettings.DepotId;
        //            logs.ApplicationName = "Green - " + form.Name;
        //            logs.ObjectId = 0;
        //            logs.ObjectValue = ex.Message.ToString();
        //            logs.OldValue = "Metoda : " + stackTrace.GetFrame(1).GetMethod().Name.ToString();
        //            logs.NewValue = ex.GetType().Name.ToString();
        //            logs.ComputerName = Environment.MachineName.ToString();

        //            logs.Add();
        //            KryptonMessageBox.Show("Wystąpił nieoczekiwany błąd w aplikacji Green. Błąd ten został zapisany w centralnej bazie Speedmail w celu naprawy.", "Informacja", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
        //        }
        //        else
        //            KryptonMessageBox.Show("Brak połączenia z siecią.", "Informacja", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
        //    }
        //}
    }
}
