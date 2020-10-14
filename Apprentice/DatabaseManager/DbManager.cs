using log4net;
using System;
using System.Collections.Generic;
using Microsoft.Win32;
using System.Data;
using System.Linq;
using Entity;
using ClassLibrary;
using System.Data.Common;

namespace DatabaseManager
{
    public class DbManager
    {
        private static readonly ILog logger = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        #region データベース設定

        // 接続文字列のレジストリーキー
        public static string registryKeyPath_ProductSettings = @"SOFTWARE\U'sTEC_Practice\PracticePG";

        // 接続文字列のレジストリ値
        public static string RegistryValueName_DbConnectionString = "DbConnectionString";

        // デフォルトのデータベース接続文字列
        public readonly static string DefaultDbConnectionString = @"Data Source=.\sqlexpress;Initial Catalog=Study_db;Integrated Security=True;";
        
        public static string RegistryValueName_DbProviderFactoryName = "DbProviderFactoryName";

        public static string DefaultDbProviderFactoryName = "System.Data.SqlClient";

        //プロバイダファクトリの設定
        public static string DbProviderFactoryName
        {
            get
            {
                string retv = "";

                try
                {
                    using (RegistryKey key = Registry.LocalMachine.OpenSubKey(registryKeyPath_ProductSettings))
                    {
                        if (key != null)
                        {
                            //レジストリから読み込む
                            retv = Convert.ToString(key.GetValue(RegistryValueName_DbProviderFactoryName, ""));
                        }
                    }
                }
                catch (Exception e)
                {
                    logger.Fatal(e);
                }

                if (retv == "")
                {
                    retv = DefaultDbProviderFactoryName;
                }

                return retv;
            }
        }       

        //データベース接続文字列の設定
        public static string DbConnectionString
        {
            get
            {
                string retv = "";

                try
                {
                    using (RegistryKey key = Registry.LocalMachine.OpenSubKey(registryKeyPath_ProductSettings))
                    {
                        if (key != null)
                        {
                            //レジストリから読み込む
                            retv = Convert.ToString(key.GetValue(RegistryValueName_DbConnectionString, ""));
                        }
                    }
                }
                catch (Exception e)
                {
                    logger.Fatal(e);
                }

                if (retv == "")
                {
                    retv = DefaultDbConnectionString;
                }

                return retv;
            }
        }

        #endregion

        #region 共通
        /// <summary>
        /// データベース接続
        /// </summary>
        /// <returns></returns>
        public static IDbConnection CreateConnection()
        {
            var factory = DbProviderFactories.GetFactory(DbProviderFactoryName);
            IDbConnection connection = factory.CreateConnection();
            connection.ConnectionString = DbConnectionString;

            return connection;
        }

        public static void AddQueryParam(IDbCommand cmd, string name, object value)
        {
            var param = cmd.CreateParameter();
            param.ParameterName = name;
            param.Value = value;
            cmd.Parameters.Add(param);
        }

        #endregion

        #region CSVファイルの患者情報取り込み
        /// <summary>
        /// 患者テーブルに取り込んだ患者情報を新規登録もしくは更新
        /// </summary>
        /// <param name="patient"></param>
        /// <returns></returns>
        public static string ImportPatientInfo(Patients patient)
        {
            using (IDbConnection connection = CreateConnection())
            {
                connection.Open();

                using (IDbCommand cmd = connection.CreateCommand())
                {
                    cmd.CommandText = @"
SELECT COUNT(*) FROM dbo.Patients 
WHERE patientId = @patientId;";

                    AddQueryParam(cmd, "PatientId", patient.PatientId);

                    if ((int)cmd.ExecuteScalar() == 0)
                    {
                        //新規登録
                        InsertPatient(connection, patient);
                    }
                    else
                    {
                        //上書き機能
                        UpdatePatient(connection, patient);
                    }

                    return patient.PatientId;
                }
            }
        }

        /// <summary>
        /// 患者情報を新規登録
        /// </summary>
        /// <param name="connection"></param>
        /// <param name="patient"></param>
        private static void InsertPatient(IDbConnection connection, Patients patient)
        {
            using (IDbCommand cmd = connection.CreateCommand())
            {
                cmd.CommandText = @"
INSERT INTO dbo.Patients (PatientId, PatientKanjiName, PatientKanaName, PatientBirthDate, PatientGender, CreatedAt, UpdatedAt) 
VALUES (@PatientId, @PatientKanjiName, @PatientKanaName, @PatientBirthDate, @PatientGender, GETDATE(), GETDATE());";

                AddQueryParam(cmd, "PatientId", patient.PatientId);
                AddQueryParam(cmd, "PatientKanjiName", patient.PatientKanjiName);
                AddQueryParam(cmd, "PatientKanaName", patient.PatientKanaName);
                AddQueryParam(cmd, "PatientBirthDate", patient.PatientBirthDate);
                AddQueryParam(cmd, "PatientGender", patient.PatientGender);

                cmd.ExecuteNonQuery();
            }
        }       

        /// <summary>
        /// 患者情報を更新
        /// </summary>
        /// <param name="connection"></param>
        /// <param name="patient"></param>
        private static void UpdatePatient(IDbConnection connection, Patients patient)
        {
            using (IDbCommand cmd = connection.CreateCommand())
            {
                cmd.CommandText = @"
UPDATE dbo.Patients
SET PatientKanjiName = @PatientKanjiName, PatientKanaName = @PatientKanaName, PatientBirthDate = @PatientBirthDate, PatientGender = @PatientGender, UpdatedAt = GETDATE()
WHERE PatientId = @PatientId;";

                AddQueryParam(cmd, "PatientId", patient.PatientId);
                AddQueryParam(cmd, "PatientKanjiName", patient.PatientKanjiName);
                AddQueryParam(cmd, "PatientKanaName", patient.PatientKanaName);
                AddQueryParam(cmd, "PatientBirthDate", patient.PatientBirthDate);
                AddQueryParam(cmd, "PatientGender", patient.PatientGender);

                cmd.ExecuteNonQuery();
            }
        }

        #endregion

        #region CSVファイルの検査情報取り込み

        /// <summary>
        /// 検査テーブルに取り込んだ検査情報を新規登録もしくは更新
        /// </summary>
        /// <param name="patientId"></param>
        /// <param name="studyitems"></param>
        public static void ImportStudyInfo(string patientId, ValidatedStudyItems studyitems)
        {
            using (IDbConnection connection = CreateConnection())
            {
                connection.Open();

                using (IDbCommand cmd = connection.CreateCommand())
                {
                    using (var trn = connection.BeginTransaction())
                    {
                        cmd.Transaction = trn;

                        cmd.CommandText = @"
SELECT COUNT(*) FROM dbo.StudyOrders
WHERE OrderNumber = @OrderNumber;";

                        AddQueryParam(cmd, "OrderNumber", studyitems.OrderNumber);

                        if ((int)cmd.ExecuteScalar() == 0)
                        {
                            //新規登録
                            InsertStudy(cmd, trn, patientId, studyitems);
                        }
                        else
                        {
                            //上書き機能
                            UpdateStudy(cmd, trn, studyitems);
                        }
                    }
                }
            }
        }

        /// <summary>
        /// 検査情報を新規登録
        /// </summary>
        /// <param name="cmd"></param>
        /// <param name="trn"></param>
        /// <param name="studyitems"></param>
        private static void InsertStudy(IDbCommand cmd, IDbTransaction trn, string patientId, ValidatedStudyItems studyitems)
        {

            cmd.CommandText = @"
INSERT INTO dbo.StudyOrders (OrderNumber, PatientId, ProcessingDivision, ScheduledOn, StudyTypeCode, StudyTypeName, CreatedAt, UpdatedAt) 
VALUES (@OrderNumber, @PatientId, @ProcessingDivision, @ScheduledOn, @StudyTypeCode, @StudyTypeName, GETDATE(), GETDATE());";

            AddQueryParam(cmd, "PatientId", patientId);
            AddQueryParam(cmd, "ProcessingDivision", studyitems.ProcessingDivision);
            AddQueryParam(cmd, "ScheduledOn", studyitems.ScheduledOn);
            AddQueryParam(cmd, "StudyTypeCode", studyitems.StudyTypeCode);
            AddQueryParam(cmd, "StudyTypeName", studyitems.StudyTypeName);

            cmd.ExecuteNonQuery();

            SaveShotItems(cmd, studyitems);
        }      

        /// <summary>
        /// 検査情報を更新
        /// </summary>
        /// <param name="cmd"></param>
        /// <param name="trn"></param>
        /// <param name="studyitems"></param>
        private static void UpdateStudy(IDbCommand cmd, IDbTransaction trn, ValidatedStudyItems studyitems)
        {
            cmd.CommandText = @"
UPDATE dbo.StudyOrders
SET ProcessingDivision = @ProcessingDivision, ScheduledOn = @ScheduledOn, StudyTypeCode = @StudyTypeCode, StudyTypeName = @StudyTypeName, UpdatedAt = GETDATE()
WHERE OrderNumber = @OrderNumber;";

            AddQueryParam(cmd, "ProcessingDivision", studyitems.ProcessingDivision);
            AddQueryParam(cmd, "ScheduledOn", studyitems.ScheduledOn);
            AddQueryParam(cmd, "StudyTypeCode", studyitems.StudyTypeCode);
            AddQueryParam(cmd, "StudyTypeName", studyitems.StudyTypeName);

            cmd.ExecuteNonQuery();

            cmd.CommandText = @"
DELETE FROM dbo.ShotItems
WHERE OrderNumber = @OrderNumber;";

            cmd.ExecuteNonQuery();

            //撮影項目の登録
            SaveShotItems(cmd, studyitems);

        }

        /// <summary>
        /// 撮影項目登録
        /// </summary>
        /// <param name="cmd"></param>
        /// <param name="studyitems"></param>
        private static void SaveShotItems(IDbCommand cmd, ValidatedStudyItems studyitems)
        {           
            int n = 0;
            foreach (var shotitem in studyitems.ShotItemSet)
            {
                cmd.CommandText = $@"
INSERT INTO dbo.ShotItems (OrderNumber, ShotItemCode, ShotItemName) 
VALUES (@OrderNumber{n}, @ShotItemCode{n}, @ShotItemName{n})";

                AddQueryParam(cmd, $"OrderNumber{n}", studyitems.OrderNumber);
                AddQueryParam(cmd, $"ShotItemCode{n}", shotitem.ShotItemCode);
                AddQueryParam(cmd, $"ShotItemName{n}", shotitem.ShotItemName);

                cmd.ExecuteNonQuery();

                n++;
            }
        }
        #endregion

        #region ユーザーID取得
        /// <summary>
        /// ユーザーID取得
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public static Users FindUserId(string userId)
        {
            List<Users> result = new List<Users>();

            using (IDbConnection connection = CreateConnection())
            {
                connection.Open();

                using (IDbCommand cmd = connection.CreateCommand())
                {
                    cmd.CommandText = @"
SELECT * FROM dbo.Users
WHERE UserId = @UserId;";

                    AddQueryParam(cmd, "UserId", userId);

                    using (IDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            result.Add(GetUser(reader));
                        }
                    }

                    return result.SingleOrDefault();
                }
            }
        }

        #endregion

        #region 検査日検索
        /// <summary>
        /// 日付検索
        /// </summary>
        /// <param name="fromStudyDate"></param>
        /// <param name="toStudyDate"></param>
        /// <returns></returns>
        public static List<WorkItem> SearchStudyListByStudyDate(DateTime fromStudyDate, DateTime toStudyDate)
        {
            List<WorkItem> result = new List<WorkItem>();

            using (IDbConnection connection = CreateConnection())
            {
                connection.Open();

                using (IDbCommand cmd = connection.CreateCommand())
                {
                    cmd.CommandText = @"
SELECT SO.OrderNumber, SO.StudyStatus, SO.ScheduledOn, P.PatientId, P.PatientKanjiName, P.PatientKanaName, SO.StudyTypeName,
STUFF((SELECT ', ' + ShotItemName FROM ShotItems as SI Where SO.OrderNumber = SI.OrderNumber FOR XML PATH('')), 1, 1, '') AS ShotItemName
FROM dbo.StudyOrders AS SO INNER JOIN 
dbo.Patients AS P 
ON SO.PatientId = P.PatientId
WHERE SO.ScheduledOn between @FromStudyDate and @ToStudyDate AND SO.IsDeleted = 0
ORDER BY SO.ScheduledOn desc;";

                    AddQueryParam(cmd, "FromStudyDate", fromStudyDate);
                    AddQueryParam(cmd, "ToStudyDate", toStudyDate);

                    IDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        WorkItem workitem = new WorkItem(GetPatient(reader), GetStudy(reader), GetShot(reader));

                        result.Add(workitem);
                    }

                    return result;
                }
            }
        }
        #endregion

        #region 患者ID検索

        /// <summary>
        /// 患者ID検索
        /// </summary>
        /// <param name="patientId"></param>
        /// <returns></returns>
        public static List<WorkItem> SearchStudyListByPatientId(string patientId)
        {
            List<WorkItem> result = new List<WorkItem>();

            using (IDbConnection connection = CreateConnection())
            {
                connection.Open();

                using (IDbCommand cmd = connection.CreateCommand())
                {
                    cmd.CommandText = @"
SELECT SO.OrderNumber, SO.StudyStatus, SO.ScheduledOn, P.PatientId, P.PatientKanjiName, P.PatientKanaName, SO.StudyTypeName,
STUFF((SELECT ', ' + ShotItemName FROM ShotItems as SI Where SO.OrderNumber = SI.OrderNumber FOR XML PATH('')), 1, 1, '') AS ShotItemName
FROM dbo.StudyOrders AS SO INNER JOIN
dbo.Patients AS P
ON SO.PatientId = P.PatientId
WHERE SO.PatientId = @PatientId AND SO.IsDeleted = 0
ORDER BY SO.ScheduledOn desc; ";

                    AddQueryParam(cmd, "PatientId", patientId);

                    IDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        WorkItem workitem = new WorkItem(GetPatient(reader), GetStudy(reader), GetShot(reader));

                        result.Add(workitem);
                    }

                    return result;
                }
            }
        }

        #endregion

        #region 検査状況検索
        /// <summary>
        /// 検査状況検索
        /// </summary>
        /// <param name="stadyStatus"></param>
        /// <returns></returns>
        public static List<WorkItem> SearchStudyListByStudyStatus(string studyStatus)
        {
            List<WorkItem> result = new List<WorkItem>();

            using (IDbConnection connection = CreateConnection())
            {
                connection.Open();

                using (IDbCommand cmd = connection.CreateCommand())
                {
                    cmd.CommandText = @"
SELECT SO.OrderNumber, SO.StudyStatus, SO.ScheduledOn, P.PatientId, P.PatientKanjiName, P.PatientKanaName, SO.StudyTypeName,
STUFF((SELECT ', ' + ShotItemName FROM ShotItems as SI Where SO.OrderNumber = SI.OrderNumber FOR XML PATH('')), 1, 1, '') AS ShotItemName
FROM dbo.StudyOrders AS SO INNER JOIN
dbo.Patients AS P
ON SO.PatientId = P.PatientId
WHERE SO.StudyStatus = @StudyStatus AND SO.IsDeleted = 0
ORDER BY SO.ScheduledOn desc; ";

                    AddQueryParam(cmd, "StudyStatus", studyStatus);

                    IDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        WorkItem workitem = new WorkItem(GetPatient(reader), GetStudy(reader), GetShot(reader));

                        result.Add(workitem);
                    }

                    return result;
                }
            }
        }
        #endregion

        #region 検査日＆検査状況検索

        /// <summary>
        /// 検査日＆検査状況検索
        /// </summary>
        /// <param name="fromStudyDate"></param>
        /// <param name="toStudyDate"></param>
        /// <param name="studyStatus"></param>
        /// <returns></returns>
        public static List<WorkItem> SearchStudyListByStudyDateAndStudyStatus(DateTime fromStudyDate, DateTime toStudyDate, string studyStatus)
        {
            List<WorkItem> result = new List<WorkItem>();

            using (IDbConnection connection = CreateConnection())
            {
                connection.Open();

                using (IDbCommand cmd = connection.CreateCommand())
                {
                    cmd.CommandText = @"
SELECT SO.OrderNumber, SO.StudyStatus, SO.ScheduledOn, P.PatientId, P.PatientKanjiName, P.PatientKanaName, SO.StudyTypeName,
STUFF((SELECT ', ' + ShotItemName FROM ShotItems as SI Where SO.OrderNumber = SI.OrderNumber FOR XML PATH('')), 1, 1, '') AS ShotItemName
FROM dbo.StudyOrders AS SO INNER JOIN
dbo.Patients AS P
ON SO.PatientId = P.PatientId
WHERE SO.ScheduledOn between @FromStudyDate and @ToStudyDate
AND SO.StudyStatus = @StudyStatus AND SO.IsDeleted = 0
ORDER BY SO.ScheduledOn desc; ";

                    AddQueryParam(cmd, "FromStudyDate", fromStudyDate);
                    AddQueryParam(cmd, "ToStudyDate", toStudyDate);
                    AddQueryParam(cmd, "StudyStatus", studyStatus);

                    IDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        WorkItem workitem = new WorkItem(GetPatient(reader), GetStudy(reader), GetShot(reader));

                        result.Add(workitem);
                    }

                    return result;
                }
            }
        }
        #endregion

        #region 検査日＆患者ID検索

        /// <summary>
        /// 検査日＆患者ID検索
        /// </summary>
        /// <param name="fromStudyDate"></param>
        /// <param name="toStudyDate"></param>
        /// <param name="patientId"></param>
        /// <returns></returns>
        public static List<WorkItem> SearchStudyListByStudyDateAndPatientId(DateTime fromStudyDate, DateTime toStudyDate, string patientId)
        {
            List<WorkItem> result = new List<WorkItem>();

            using (IDbConnection connection = CreateConnection())
            {
                connection.Open();

                using (IDbCommand cmd = connection.CreateCommand())
                {
                    cmd.CommandText = @"
SELECT SO.OrderNumber, SO.StudyStatus, SO.ScheduledOn, P.PatientId, P.PatientKanjiName, P.PatientKanaName, SO.StudyTypeName,
STUFF((SELECT ', ' + ShotItemName FROM ShotItems as SI Where SO.OrderNumber = SI.OrderNumber FOR XML PATH('')), 1, 1, '') AS ShotItemName
FROM dbo.StudyOrders AS SO INNER JOIN
dbo.Patients AS P
ON SO.PatientId = P.PatientId
WHERE SO.ScheduledOn between @FromStudyDate and @ToStudyDate
AND SO.PatientId = @PatientId AND SO.IsDeleted = 0
ORDER BY SO.ScheduledOn desc; ";

                    AddQueryParam(cmd, "FromStudyDate", fromStudyDate);
                    AddQueryParam(cmd, "ToStudyDate", toStudyDate);
                    AddQueryParam(cmd, "PatientId", patientId);

                    IDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        WorkItem workitem = new WorkItem(GetPatient(reader), GetStudy(reader), GetShot(reader));

                        result.Add(workitem);
                    }

                    return result;
                }
            }
        }
        #endregion

        #region 検査状況＆患者ID検索
        /// <summary>
        /// 検査状況＆患者ID検索
        /// </summary>
        /// <param name="studyStatus"></param>
        /// <param name="patientId"></param>
        /// <returns></returns>
        public static List<WorkItem> SearchStudyListByStudyStatusAndPatientId(string studyStatus, string patientId)
        {
            List<WorkItem> result = new List<WorkItem>();

            using (IDbConnection connection = CreateConnection())
            {
                connection.Open();

                using (IDbCommand cmd = connection.CreateCommand())
                {
                    cmd.CommandText = @"
SELECT SO.OrderNumber, SO.StudyStatus, SO.ScheduledOn, P.PatientId, P.PatientKanjiName, P.PatientKanaName, SO.StudyTypeName,
STUFF((SELECT ', ' + ShotItemName FROM ShotItems as SI Where SO.OrderNumber = SI.OrderNumber FOR XML PATH('')), 1, 1, '') AS ShotItemName
FROM dbo.StudyOrders AS SO INNER JOIN
dbo.Patients AS P
ON SO.PatientId = P.PatientId
WHERE SO.StudyStatus = @StudyStatus AND SO.PatientId = @PatientId AND SO.IsDeleted = 0
ORDER BY SO.ScheduledOn desc; ";

                    AddQueryParam(cmd, "PatientId", patientId);
                    AddQueryParam(cmd, "StudyStatus", studyStatus);

                    IDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        WorkItem workitem = new WorkItem(GetPatient(reader), GetStudy(reader), GetShot(reader));

                        result.Add(workitem);
                    }

                    return result;
                }
            }
        }
        #endregion

        #region 検査日＆検査状況＆患者ID検索

        /// <summary>
        /// 検査日＆検査状況＆患者ID検索
        /// </summary>
        /// <param name="fromStudyDate"></param>
        /// <param name="toStudyDate"></param>
        /// <param name="patientId"></param>
        /// <param name="studyStatus"></param>
        /// <returns></returns>
        public static List<WorkItem> SearchStudyListByStudyDateAndStudyStatusAndPatientId(DateTime fromStudyDate, DateTime toStudyDate, string patientId, string studyStatus)
        {
            List<WorkItem> result = new List<WorkItem>();

            using (IDbConnection connection = CreateConnection())
            {
                connection.Open();

                using (IDbCommand cmd = connection.CreateCommand())
                {
                    cmd.CommandText = @"
SELECT SO.OrderNumber, SO.StudyStatus, SO.ScheduledOn, P.PatientId, P.PatientKanjiName, P.PatientKanaName, SO.StudyTypeName,
STUFF((SELECT ', ' + ShotItemName FROM ShotItems as SI Where SO.OrderNumber = SI.OrderNumber FOR XML PATH('')), 1, 1, '') AS ShotItemName
FROM dbo.StudyOrders AS SO INNER JOIN
dbo.Patients AS P
ON SO.PatientId = P.PatientId
WHERE SO.ScheduledOn between @FromStudyDate and @ToStudyDate
AND SO.PatientId = @PatientId AND SO.StudyStatus = @StudyStatus AND SO.IsDeleted = 0
ORDER BY SO.ScheduledOn desc; ";

                    AddQueryParam(cmd, "FromStudyDate", fromStudyDate);
                    AddQueryParam(cmd, "ToStudyDate", toStudyDate);
                    AddQueryParam(cmd, "PatientId", patientId);
                    AddQueryParam(cmd, "StudyStatus", studyStatus);

                    IDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        WorkItem workitem = new WorkItem(GetPatient(reader), GetStudy(reader), GetShot(reader));

                        result.Add(workitem);
                    }

                    return result;
                }
            }
        }
        #endregion

        #region 詳細表示
        /// <summary>
        /// 詳細表示
        /// </summary>
        /// <param name="patientId"></param>
        /// <returns></returns>
        public static WorkItemDetails SearchItemDetails(string patientId)
        {
            WorkItemDetails itemDetails = null;
            
            using (IDbConnection connection = CreateConnection())
            {
                connection.Open();

                using (IDbCommand cmd = connection.CreateCommand())
                {
                    cmd.CommandText = @"
SELECT SO.StudiedAt, P.PatientBirthDate, P.PatientGender
FROM dbo.StudyOrders AS SO INNER JOIN 
dbo.Patients AS P 
ON SO.PatientId = P.PatientId
WHERE SO.PatientId = @PatientId;";

                    AddQueryParam(cmd, "PatientId", patientId);

                    IDataReader reader = cmd.ExecuteReader(); 

                    if (reader.Read())
                    {
                        itemDetails = new WorkItemDetails();
                        itemDetails.StudiedAt = (DateTime)reader["StudiedAt"];
                        itemDetails.PatientBirthDate = (DateTime)reader["PatientBirthDate"];
                        itemDetails.PatientGender = (string)reader["PatientGender"];                       
                    }

                    return itemDetails;
                }
            }
        }


        #endregion

        #region 保留
        /// <summary>
        /// 保留
        /// </summary>
        /// <param name="orderNumber"></param>
        public static void HoldStudy(string orderNumber)
        {
            using (IDbConnection connection = CreateConnection())
            {
                connection.Open();

                using (IDbCommand cmd = connection.CreateCommand())
                {
                    cmd.CommandText = @"
UPDATE dbo.StudyOrders
SET IsDeleted = 1, UpdatedAt = GETDATE()
WHERE OrderNumber = @OrderNumber;";

                    AddQueryParam(cmd, "OrderNumber", orderNumber);

                    cmd.ExecuteNonQuery();
                }
            }
        }
        #endregion

        #region 新規ユーザー登録
        /// <summary>
        /// ユーザー情報登録
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="userId"></param>
        /// <param name="hashedNewPassword"></param>
        /// <param name="startDate"></param>
        /// <param name="endingDate"></param>
        public static void RegisterUser(string userName, string userId, string hashedNewPassword, DateTime startDate, DateTime endingDate)
        {
            using (IDbConnection connection = CreateConnection())
            {
                connection.Open();

                using (IDbCommand cmd = connection.CreateCommand())
                {
                    cmd.CommandText = @"
INSERT INTO dbo.Users (UserId, UserName, Password, StartedOn, ExpiredOn, CreatedAt, UpdatedAt) 
VALUES (@UserId, @UserName, @Password, @StartedOn, @ExpiredOn, GETDATE(), GETDATE());";

                    AddQueryParam(cmd, "UserId", userId);
                    AddQueryParam(cmd, "UserName", userName);
                    AddQueryParam(cmd, "Password", hashedNewPassword);
                    AddQueryParam(cmd, "StartedOn", startDate);
                    AddQueryParam(cmd, "ExpiredOn", endingDate);

                    cmd.ExecuteNonQuery();
                }
            }
        }
        #endregion

        #region ユーザー情報変更

        /// <summary>
        /// ユーザー情報変更
        /// </summary>
        /// <param name="newUserName"></param>
        /// <param name="hashedNewPassword"></param>
        /// <param name="newStartDate"></param>
        /// <param name="newEndingDate"></param>
        public static void UpdateUserInfo(string userId, string newUserName, string hashedNewPassword, DateTime newStartDate, DateTime newEndingDate)
        {
            using (IDbConnection connection = CreateConnection())
            {
                connection.Open();

                using (IDbCommand cmd = connection.CreateCommand())
                {
                    cmd.CommandText = @"
UPDATE dbo.Users 
SET UserName = @UserName, Password = @Password, StartedOn = @StartedOn, ExpiredOn = @ExpiredOn, UpdatedAt = GETDATE()
WHERE userId = @userId;";

                    AddQueryParam(cmd, "UserId", userId);
                    AddQueryParam(cmd, "UserName", newUserName);
                    AddQueryParam(cmd, "Password", hashedNewPassword);
                    AddQueryParam(cmd, "StartedOn", newStartDate);
                    AddQueryParam(cmd, "ExpiredOn", newEndingDate);

                    cmd.ExecuteNonQuery();
                }
            }
        }

        #endregion

        #region 患者情報
        /// <summary>
        /// 患者情報を取得
        /// </summary>
        /// <param name="reader"></param>
        /// <returns></returns>
        private static Patients GetPatient(IDataReader reader)
        {
            Patients patient = new Patients
            {
                PatientId = (string)reader["PatientId"],
                PatientKanjiName = (string)reader["PatientKanjiName"],
                PatientKanaName = (string)reader["PatientKanaName"]               
            };

            return patient;
        }
        #endregion

        #region 検査情報
        /// <summary>
        /// 検査情報を取得
        /// </summary>
        /// <param name="reader"></param>
        /// <returns></returns>
        private static StudyOrders GetStudy(IDataReader reader)
        {
            StudyOrders study = new StudyOrders
            {
                OrderNumber = (string)reader["OrderNumber"],
                StudyStatus = (string)reader["StudyStatus"],
                ScheduledOn = (DateTime)reader["ScheduledOn"],
                StudyTypeName = (string)reader["StudyTypeName"],
            };

            return study;
        }

        #endregion

        #region 撮影項目情報
        /// <summary>
        /// 撮影項目を取得
        /// </summary>
        /// <param name="reader"></param>
        /// <returns></returns>
        private static ShotItems GetShot(IDataReader reader)
        {
            ShotItems shot = new ShotItems
            {
                ShotItemName = (string)reader["ShotItemName"]
            };

            return shot;
        }

        #endregion

        #region 検査状況変更

        /// <summary>
        /// 予約済に遷移
        /// </summary>
        /// <param name="_item"></param>
        public static void ChangeIntoReserved(WorkItem _item)
        {
            using (IDbConnection connection = CreateConnection())
            {
                connection.Open();

                using (IDbCommand cmd = connection.CreateCommand())
                {
                    cmd.CommandText = @"
UPDATE dbo.StudyOrders
SET StudyStatus = '予約済', UpdatedAt = GETDATE()
WHERE OrderNumber = @OrderNumber;";

                    AddQueryParam(cmd, "OrderNumber", _item.OrderNumber);

                    cmd.ExecuteNonQuery();
                }
            }
        }

        /// <summary>
        /// 受付済に遷移
        /// </summary>
        /// <param name="_item"></param>
        public static void ChangeIntoAccepted(WorkItem _item)
        {
            using (IDbConnection connection = CreateConnection())
            {
                connection.Open();

                using (IDbCommand cmd = connection.CreateCommand())
                {
                    cmd.CommandText = @"
UPDATE dbo.StudyOrders
SET StudyStatus = '受付済', UpdatedAt = GETDATE()
WHERE OrderNumber = @OrderNumber;";

                    AddQueryParam(cmd, "OrderNumber", _item.OrderNumber);

                    cmd.ExecuteNonQuery();
                }
            }
        }

        /// <summary>
        /// 撮影済に遷移
        /// </summary>
        /// <param name="_item"></param>
        public static void ChangeIntoPerformed(WorkItem _item)
        {
            using (IDbConnection connection = CreateConnection())
            {
                connection.Open();

                using (IDbCommand cmd = connection.CreateCommand())
                {
                    cmd.CommandText = @"
UPDATE dbo.StudyOrders
SET StudyStatus = '撮影済', UpdatedAt = GETDATE()
WHERE OrderNumber = @OrderNumber;";

                    AddQueryParam(cmd, "OrderNumber", _item.OrderNumber);

                    cmd.ExecuteNonQuery();
                }
            }
        }

        #endregion

        #region ユーザー情報

        public static Users GetUser(IDataReader reader)
        {
            Users user = new Users
            {
                UserId = (string)reader["UserId"],
                UserName = (string)reader["UserName"],
                Password = (string)reader["Password"],
                StartedOn = (DateTime)reader["StartedOn"],
                ExpiredOn = (DateTime)reader["ExpiredOn"],
                CreatedAt = (DateTime)reader["CreatedAt"],
                UpdatedAt = (DateTime)reader["UpdatedAt"]
            };

            return user;
        }

        #endregion

        #region パスワード変更
        /// <summary>
        /// パスワード変更
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="userName"></param>
        /// <param name="password"></param>
        public static void ChangePassword(string userId, string newpassword, DateTime startDate, DateTime endingDate)
        {
            using (IDbConnection connection = CreateConnection())
            {
                connection.Open();

                using (IDbCommand cmd = connection.CreateCommand())
                {
                    cmd.CommandText = @"
UPDATE dbo.Users
SET Password = @Password, StartedOn = @StartedOn, ExpiredOn = @ExpiredOn, UpdatedAt = GETDATE()
WHERE UserId = @UserId";

                    AddQueryParam(cmd, "UserId", userId);
                    AddQueryParam(cmd, "Password", newpassword);
                    AddQueryParam(cmd, "StartedOn", startDate);
                    AddQueryParam(cmd, "ExpiredOn", endingDate);

                    cmd.ExecuteNonQuery();
                }
            }
        }
        #endregion

        #region 1件セットテーブルに挿入
        public static void InsertOneStudyTable(WorkItem item, WorkItemDetails itemDetails)
        {
            using (IDbConnection connection = CreateConnection())
            {
                connection.Open();

                using (IDbCommand cmd = connection.CreateCommand())
                {
                    cmd.CommandText = @"
INSERT INTO OnlyOneStudy(PatientId, PatientKanjiName, PatientKanaName, PatientBirthDate, PatientGender, OrderNumber, StudyStatus, ScheduledOn, StudyTypeName, Comment, ShotItemName) 
VALUES(@PatientId, @PatientKanjiName, @PatientKanaName, @PatientBirthDate, @PatientGender, @OrderNumber, @StudyStatus, @ScheduledOn, @StudyTypeName, @Comment, @ShotItemName);";

                    AddQueryParam(cmd, "PatientId", item.PatientId);
                    AddQueryParam(cmd, "PatientKanjiName", item.PatientKanjiName);
                    AddQueryParam(cmd, "PatientKanaName", item.PatientKanaName);
                    AddQueryParam(cmd, "PatientBirthDate", itemDetails.PatientBirthDate);
                    AddQueryParam(cmd, "PatientGender", itemDetails.PatientGender);
                    AddQueryParam(cmd, "OrderNumber", item.OrderNumber);
                    AddQueryParam(cmd, "StudyStatus", item.StudyStatus);
                    AddQueryParam(cmd, "ScheduledOn", item.ScheduledOn);
                    AddQueryParam(cmd, "StudyTypeName", item.StudyTypeName);
                    AddQueryParam(cmd, "Comment", item.Comment);
                    AddQueryParam(cmd, "ShotItemName", item.ShotItemName);

                    cmd.ExecuteNonQuery();
                }
            }
        }
        #endregion

        #region 1件セットテーブルから削除
        public static void DeleteOneStudyTable(WorkItem item)
        {
            using (IDbConnection connection = CreateConnection())
            {
                connection.Open();

                using (IDbCommand cmd = connection.CreateCommand())
                {
                    cmd.CommandText = @"
DELETE FROM OnlyOneStudy 
WHERE OrderNumber = @OrderNumber;";

                    AddQueryParam(cmd, "OrderNumber", item.OrderNumber);

                    cmd.ExecuteNonQuery();
                }
            }
        }
        #endregion

    }
}
