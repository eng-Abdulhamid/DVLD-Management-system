using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;

namespace DVLD.DataSeeder
{
    internal class Program
    {
        // عدّل نص الاتصال بقاعدة البيانات لديك
        private const string ConnectionString = "Server=.;Database=DVLD;Integrated Security=True;TrustServerCertificate=True;";
        private const int TotalRecords = 40000;
        private const int BatchSize = 10000;

        // مصفوفات توليد الأسماء والبيانات الواقعية
        private static readonly string[] MaleFirstNames = { "أحمد", "محمد", "محمود", "يوسف", "إبراهيم", "عمر", "علي", "خالد", "حسن", "حسين", "طارق", "بلال", "كريم", "سامي", "رامي", "فادي", "مازن", "سعيد", "أيمن", "أمجد" };
        private static readonly string[] FemaleFirstNames = { "فاطمة", "مريم", "سارة", "نور", "هدى", "آية", "منى", "رنا", "دينا", "ياسمين", "رندة", "شهد", "روان", "ليلى", "زينب", "سناء", "إيمان", "خلود", "هبة", "ندى" };
        private static readonly string[] MiddleNames = { "عبد الله", "عبد الرحمن", "جمال", "كمال", "سالم", "صالح", "ماجد", "منير", "عادل", "رفيق", "شريف", "باسم", "فارس", "ناجي", "عماد", "نبيل", "تيسير", "وليد", "ماهر", "عصام" };
        private static readonly string[] FamilyNames = { "النجار", "المصري", "البردويل", "الزعنون", "الأغا", "الأسطل", "فرحات", "حمودة", "دغمش", "حلس", "عاشور", "أبو طه", "أبو عيطة", "اليازجي", "قاسم", "العرعير", "السكني", "الشنطي", "شعت", "حجاج" };
        private static readonly string[] Cities = { "غزة - الرمال", "غزة - النصر", "خانيونس - البلد", "رفح - تل السلطان", "شمال غزة - جباليا", "دير البلح - المحطة", "غزة - تل الهوى", "خانيونس - القرارة", "النصيرات - المخيم" };

        static async Task Main(string[] args)
        {
            Console.Title = "DVLD Data Seeder - 40K Massive Data Engine";
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("===============================================================================");
            Console.WriteLine("                DVLD MASSIVE DATABASE SEEDER (40,000 RECORDS)                  ");
            Console.WriteLine("===============================================================================\n");
            Console.ResetColor();

            Stopwatch globalWatch = Stopwatch.StartNew();

            try
            {
                using SqlConnection connection = new(ConnectionString);
                await connection.OpenAsync();

                // 1. قراءة المعرفات الحالية للمطابقة وضمان عدم حدوث تعارض
                Console.WriteLine("[INFO] Reading database current identity offsets...");
                int personStartId = await GetNextIdentityAsync(connection, "People");
                int userStartId = await GetNextIdentityAsync(connection, "Users");
                int driverStartId = await GetNextIdentityAsync(connection, "Drivers");
                int appStartId = await GetNextIdentityAsync(connection, "Applications");
                int ldlAppStartId = await GetNextIdentityAsync(connection, "LocalDrivingLicenseApplications");
                int apptStartId = await GetNextIdentityAsync(connection, "TestAppointments");
                int testStartId = await GetNextIdentityAsync(connection, "Tests");
                int licStartId = await GetNextIdentityAsync(connection, "Licenses");

                int countryId = await GetValidCountryIdAsync(connection);
                int adminUserId = await GetAdminUserIdAsync(connection);

                Console.WriteLine($"[INFO] Offset Check: Base Person ID starts at #{personStartId}\n");

                Random rnd = new(1337);

                // معالجة البيانات على دفعات للحفاظ على الذاكرة
                for (int offset = 0; offset < TotalRecords; offset += BatchSize)
                {
                    int currentBatch = Math.Min(BatchSize, TotalRecords - offset);
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine($"\n>>> Generating Batch: Records {offset + 1} to {offset + currentBatch} of {TotalRecords}...");
                    Console.ResetColor();

                    Stopwatch batchWatch = Stopwatch.StartNew();

                    // جداول الذاكرة
                    DataTable dtPeople = CreatePeopleTable();
                    DataTable dtUsers = CreateUsersTable();
                    DataTable dtDrivers = CreateDriversTable();
                    DataTable dtApps = CreateApplicationsTable();
                    DataTable dtLdlApps = CreateLdlApplicationsTable();
                    DataTable dtAppts = CreateAppointmentsTable();
                    DataTable dtTests = CreateTestsTable();
                    DataTable dtLicenses = CreateLicensesTable();
                    DataTable dtDetained = CreateDetainedTable();
                    DataTable dtInternational = CreateInternationalTable();

                    for (int i = 0; i < currentBatch; i++)
                    {
                        int currentIndex = offset + i;

                        // IDs المحسوبة مسبقاً للربط
                        int currentPersonId = personStartId + currentIndex;
                        int currentAppId = appStartId + currentIndex;
                        int currentLdlAppId = ldlAppStartId + currentIndex;
                        int currentApptId = apptStartId + currentIndex;
                        int currentLicenseId = licStartId + currentIndex;
                        int currentDriverId = driverStartId + currentIndex;

                        // بيانات الشخص
                        bool isMale = rnd.Next(0, 2) == 0;
                        string fName = isMale ? MaleFirstNames[rnd.Next(MaleFirstNames.Length)] : FemaleFirstNames[rnd.Next(FemaleFirstNames.Length)];
                        string sName = MiddleNames[rnd.Next(MiddleNames.Length)];
                        string tName = MiddleNames[rnd.Next(MiddleNames.Length)];
                        string lName = FamilyNames[rnd.Next(FamilyNames.Length)];
                        string natNo = $"N{(10000000 + currentIndex)}";
                        DateTime dob = DateTime.Now.AddYears(-rnd.Next(20, 60)).AddDays(-rnd.Next(1, 365));
                        string phone = $"+97059{rnd.Next(1000000, 9999999)}";
                        string email = $"user_{currentIndex}@dvld-demo.ps";
                        string address = Cities[rnd.Next(Cities.Length)];

                        dtPeople.Rows.Add(natNo, fName, sName, tName, lName, dob, (byte)(isMale ? 0 : 1), address, phone, email, countryId, DBNull.Value);

                        // مستخدم لكل 10 أشخاص
                        if (currentIndex % 10 == 0)
                        {
                            dtUsers.Rows.Add(currentPersonId, $"User_{currentIndex}", "User@123", true);
                        }

                        // سائق لكل شخص
                        DateTime driverDate = DateTime.Now.AddMonths(-rnd.Next(6, 48));
                        dtDrivers.Rows.Add(currentPersonId, adminUserId, driverDate);

                        // طلب رخصة جديد مكتمل (Status = 3)
                        DateTime appDate = driverDate.AddDays(-14);
                        dtApps.Rows.Add(currentPersonId, appDate, 1, (byte)3, appDate.AddDays(7), 15.0000m, adminUserId);

                        // طلب رخصة محلية (فئة 3 - عادي)
                        dtLdlApps.Rows.Add(currentAppId, 3);

                        // موعد فحص مقفل
                        DateTime testDate = appDate.AddDays(3);
                        dtAppts.Rows.Add(1, currentLdlAppId, testDate, 10.0000m, adminUserId, true, DBNull.Value);

                        // فحص عملي ناجح
                        dtTests.Rows.Add(currentApptId, true, "تم اجتياز الفحص بنجاح", adminUserId);

                        // رخصة قيادة نشطة
                        DateTime issueDate = appDate.AddDays(7);
                        DateTime expDate = issueDate.AddYears(10);
                        dtLicenses.Rows.Add(currentAppId, currentDriverId, 3, issueDate, expDate, "رخصة سارية - فحص تلقائي", 20.0000m, true, (byte)1, adminUserId);

                        // حجز رخصة لكل 20 رخصة
                        if (currentIndex % 20 == 0)
                        {
                            dtDetained.Rows.Add(currentLicenseId, issueDate.AddMonths(2), 250.0000m, adminUserId, false, DBNull.Value, DBNull.Value, DBNull.Value);
                        }

                        // رخصة دولية لكل 15 سائق
                        if (currentIndex % 15 == 0)
                        {
                            dtInternational.Rows.Add(currentAppId, currentDriverId, currentLicenseId, issueDate.AddMonths(1), issueDate.AddMonths(13), true, adminUserId);
                        }
                    }

                    // ضخ البيانات بالترتيب الصحيح لقيود المفاتيح الأجنبية
                    Console.WriteLine("    -> Bulk copying People...");
                    await BulkInsertAsync(connection, "People", dtPeople);

                    Console.WriteLine("    -> Bulk copying Users & Drivers...");
                    await BulkInsertAsync(connection, "Users", dtUsers);
                    await BulkInsertAsync(connection, "Drivers", dtDrivers);

                    Console.WriteLine("    -> Bulk copying Base Applications & LDL Applications...");
                    await BulkInsertAsync(connection, "Applications", dtApps);
                    await BulkInsertAsync(connection, "LocalDrivingLicenseApplications", dtLdlApps);

                    Console.WriteLine("    -> Bulk copying Appointments & Tests...");
                    await BulkInsertAsync(connection, "TestAppointments", dtAppts);
                    await BulkInsertAsync(connection, "Tests", dtTests);

                    Console.WriteLine("    -> Bulk copying Licenses, Detained & International...");
                    await BulkInsertAsync(connection, "Licenses", dtLicenses);
                    await BulkInsertAsync(connection, "DetainedLicenses", dtDetained);
                    await BulkInsertAsync(connection, "InternationalLicenses", dtInternational);

                    batchWatch.Stop();
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine($" [SUCCESS] Batch completed in: {batchWatch.Elapsed.TotalSeconds:F2} seconds.");
                    Console.ResetColor();
                }

                globalWatch.Stop();
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("\n===============================================================================");
                Console.WriteLine($" COMPLETED ALL 40,000 RECORDS IN: {globalWatch.Elapsed.TotalSeconds:F2} SECONDS!");
                Console.WriteLine("===============================================================================\n");
                Console.ResetColor();
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"\n[ERROR] Seeding failed: {ex.Message}");
                if (ex.InnerException != null)
                {
                    Console.WriteLine($"Inner: {ex.InnerException.Message}");
                }
                Console.ResetColor();
            }

            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }

        #region Bulk Insert Engine

        private static async Task BulkInsertAsync(SqlConnection connection, string tableName, DataTable dataTable)
        {
            using SqlBulkCopy bulkCopy = new(connection)
            {
                DestinationTableName = tableName,
                BatchSize = dataTable.Rows.Count,
                BulkCopyTimeout = 300
            };

            foreach (DataColumn column in dataTable.Columns)
            {
                bulkCopy.ColumnMappings.Add(column.ColumnName, column.ColumnName);
            }

            await bulkCopy.WriteToServerAsync(dataTable);
        }

        #endregion

        #region Table Definitions

        private static DataTable CreatePeopleTable()
        {
            DataTable dt = new();
            dt.Columns.Add("NationalNo", typeof(string));
            dt.Columns.Add("FirstName", typeof(string));
            dt.Columns.Add("SecondName", typeof(string));
            dt.Columns.Add("ThirdName", typeof(string));
            dt.Columns.Add("LastName", typeof(string));
            dt.Columns.Add("DateOfBirth", typeof(DateTime));
            dt.Columns.Add("Gendor", typeof(byte));
            dt.Columns.Add("Address", typeof(string));
            dt.Columns.Add("Phone", typeof(string));
            dt.Columns.Add("Email", typeof(string));
            dt.Columns.Add("NationalityCountryID", typeof(int));
            dt.Columns.Add("ImagePath", typeof(string));
            return dt;
        }

        private static DataTable CreateUsersTable()
        {
            DataTable dt = new();
            dt.Columns.Add("PersonID", typeof(int));
            dt.Columns.Add("UserName", typeof(string));
            dt.Columns.Add("Password", typeof(string));
            dt.Columns.Add("IsActive", typeof(bool));
            return dt;
        }

        private static DataTable CreateDriversTable()
        {
            DataTable dt = new();
            dt.Columns.Add("PersonID", typeof(int));
            dt.Columns.Add("CreatedByUserID", typeof(int));
            dt.Columns.Add("CreatedDate", typeof(DateTime));
            return dt;
        }

        private static DataTable CreateApplicationsTable()
        {
            DataTable dt = new();
            dt.Columns.Add("ApplicantPersonID", typeof(int));
            dt.Columns.Add("ApplicationDate", typeof(DateTime));
            dt.Columns.Add("ApplicationTypeID", typeof(int));
            dt.Columns.Add("ApplicationStatus", typeof(byte));
            dt.Columns.Add("LastStatusDate", typeof(DateTime));
            dt.Columns.Add("PaidFees", typeof(decimal));
            dt.Columns.Add("CreatedByUserID", typeof(int));
            return dt;
        }

        private static DataTable CreateLdlApplicationsTable()
        {
            DataTable dt = new();
            dt.Columns.Add("ApplicationID", typeof(int));
            dt.Columns.Add("LicenseClassID", typeof(int));
            return dt;
        }

        private static DataTable CreateAppointmentsTable()
        {
            DataTable dt = new();
            dt.Columns.Add("TestTypeID", typeof(int));
            dt.Columns.Add("LocalDrivingLicenseApplicationID", typeof(int));
            dt.Columns.Add("AppointmentDate", typeof(DateTime));
            dt.Columns.Add("PaidFees", typeof(decimal));
            dt.Columns.Add("CreatedByUserID", typeof(int));
            dt.Columns.Add("IsLocked", typeof(bool));
            dt.Columns.Add("RetakeTestApplicationID", typeof(int));
            return dt;
        }

        private static DataTable CreateTestsTable()
        {
            DataTable dt = new();
            dt.Columns.Add("TestAppointmentID", typeof(int));
            dt.Columns.Add("TestResult", typeof(bool));
            dt.Columns.Add("Notes", typeof(string));
            dt.Columns.Add("CreatedByUserID", typeof(int));
            return dt;
        }

        private static DataTable CreateLicensesTable()
        {
            DataTable dt = new();
            dt.Columns.Add("ApplicationID", typeof(int));
            dt.Columns.Add("DriverID", typeof(int));
            dt.Columns.Add("LicenseClass", typeof(int));
            dt.Columns.Add("IssueDate", typeof(DateTime));
            dt.Columns.Add("ExpirationDate", typeof(DateTime));
            dt.Columns.Add("Notes", typeof(string));
            dt.Columns.Add("PaidFees", typeof(decimal));
            dt.Columns.Add("IsActive", typeof(bool));
            dt.Columns.Add("IssueReason", typeof(byte));
            dt.Columns.Add("CreatedByUserID", typeof(int));
            return dt;
        }

        private static DataTable CreateDetainedTable()
        {
            DataTable dt = new();
            dt.Columns.Add("LicenseID", typeof(int));
            dt.Columns.Add("DetainDate", typeof(DateTime));
            dt.Columns.Add("FineFees", typeof(decimal));
            dt.Columns.Add("CreatedByUserID", typeof(int));
            dt.Columns.Add("IsReleased", typeof(bool));
            dt.Columns.Add("ReleaseDate", typeof(DateTime));
            dt.Columns.Add("ReleasedByUserID", typeof(int));
            dt.Columns.Add("ReleaseApplicationID", typeof(int));
            return dt;
        }

        private static DataTable CreateInternationalTable()
        {
            DataTable dt = new();
            dt.Columns.Add("ApplicationID", typeof(int));
            dt.Columns.Add("DriverID", typeof(int));
            dt.Columns.Add("IssuedUsingLocalLicenseID", typeof(int));
            dt.Columns.Add("IssueDate", typeof(DateTime));
            dt.Columns.Add("ExpirationDate", typeof(DateTime));
            dt.Columns.Add("IsActive", typeof(bool));
            dt.Columns.Add("CreatedByUserID", typeof(int));
            return dt;
        }

        #endregion

        #region Database Utilities

        private static async Task<int> GetNextIdentityAsync(SqlConnection connection, string tableName)
        {
            string query = $"SELECT ISNULL(IDENT_CURRENT('{tableName}'), 0) + 1";
            using SqlCommand cmd = new(query, connection);
            object? res = await cmd.ExecuteScalarAsync();
            return Convert.ToInt32(res);
        }

        private static async Task<int> GetValidCountryIdAsync(SqlConnection connection)
        {
            string query = "SELECT TOP 1 CountryID FROM Countries";
            using SqlCommand cmd = new(query, connection);
            object? res = await cmd.ExecuteScalarAsync();
            return res != null ? Convert.ToInt32(res) : 1;
        }

        private static async Task<int> GetAdminUserIdAsync(SqlConnection connection)
        {
            string query = "SELECT TOP 1 UserID FROM Users";
            using SqlCommand cmd = new(query, connection);
            object? res = await cmd.ExecuteScalarAsync();
            return res != null ? Convert.ToInt32(res) : 1;
        }

        #endregion
    }
}