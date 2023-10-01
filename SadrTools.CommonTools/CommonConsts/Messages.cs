namespace SadrTools.CommonConsts;

public static class Messages
{
    public static class Information
    {
        /// <summary>
        /// نام کاربری یا کلمه عبور صحیح نمیباشد
        /// </summary>
        public static readonly string WrongUsernamePassword = "نام کاربری یا کلمه عبور اشتباه است";

        /// <summary>
        /// ورود ناموفق
        /// </summary>
        public static readonly string UnSuccessfulLogin = "ورود ناموفق";

        public static readonly string NotLoggedIn = "کارمندی لاگین نشده است";

        public static readonly string SqlException = "وقوع مشکل در هنگام کار با دیتایس";

        public static readonly string SqlExceptionCaption = "خطای بانک اطلاعاتی";

        public static readonly string Exception = "وقوع مشکل در سیستم";

        public static readonly string ExceptionCaption = "خطای سیستمی";

        /// <summary>
        /// این نام کاربری قبلا ثبت شده است
        /// </summary>
        public static readonly string DuplicateUsername = "این نام کاربری قبلا ثبت شده است";

        /// <summary>
        /// کلمه عبور فعلی درست نمیباشد
        /// </summary>
        public static readonly string InvalidCurrentPassword = "کلمه عبور فعلی درست نمیباشد";


        public static readonly string NewUsername = "انتخاب نام کاربری جدید";

        public static readonly string Welcome = " خوش آمدید ";

        /// <summary>
        /// برای این شخص قبلا نام کاربری ثبت شده است
        /// </summary>
        public static readonly string PersonHasUsername = "برای این شخص قبلا نام کاربری ثبت شده است";

        public static readonly string LoginToSystem = "ورود به سیستم";

        public static readonly string Warning = "هشدار";

        public static readonly string Delete = "آیا از حذف رکورد جاری مطمئن هستید؟";

        public static readonly string NoRowSelected = "! ردیفی انتخاب نشده است";

        public static readonly string AllFormsShouldBeClosed = "تمام فرم ها بسته خواهند شد آیا مطمئن هستید؟";

        public static readonly string SuccessBackup = "تهیه نسخه پشتیبان با موفقیت انجام گردید";

        public static readonly string Backup = "پشتیبان";

        public static readonly string Restore = "بازیابی";

        public static readonly string BackupAuto = "قبل از بازیابی، از اطلاعات شما در مسیر زیر نسخه پشتیبان تهیه گردید" + "\n";

        public static readonly string SuccessRestore = "نسخه پشتیبان با موفقیت بازیابی گردید";

        /// <summary>
        /// لطفا یک مورد را انتخاب کنید
        /// </summary>
        public static readonly string PlzChoose = "لطفا یک مورد را انتخاب کنید";

        /// <summary>
        /// مبلغ وارد نشده است
        /// </summary>
        public static readonly string NoAmount = "مبلغ وارد نشده است";

        /// <summary>
        /// مبلغ درخواستی در رنج تعریف شده نمیباشد
        /// </summary>
        public static readonly string NotInRangeAmount = "مبلغ درخواستی در رنج تعریف شده نمیباشد";


        /// <summary>
        /// کلمات عبور یکسان نیستند
        /// </summary>
        public static readonly string PasswordsNotEqual = "کلمات عبور یکسان نیستند";

    }

    public static class Exception
    {
        /// <summary>
        /// عبارت مورد نظر قابل تبدیل به عدد صحیح نمیباشد
        /// </summary>
        public static readonly string ToInt = "عبارت مورد نظر قابل تبدیل به عدد صحیح نمیباشد";

        /// <summary>
        /// عبارت مورد نظر قابل تبدیل به عدد اعشاری نمیباشد
        /// </summary>
        public static readonly string ToFloat = "عبارت مورد نظر قابل تبدیل به عدد اعشاری نمیباشد";

        /// <summary>
        /// آبجکت مورد نظر معتبر نمیباشد
        /// </summary>
        public static readonly string InvalidObject = "آبجکت مورد نظر معتبر نمیباشد";

        /// <summary>
        /// لیست مورد نظر فقط خواندنی میباشد
        /// </summary>
        public static readonly string ReadOnlyList = "لیست مورد نظر فقط خواندنی میباشد";

    }
}

public static class Names
{
    public static readonly string Year = "سال";

    public static readonly string Month = "ماه";

    public static readonly string Day = "روز";

    /// <summary>
    /// امروز
    /// </summary>
    public static readonly string Today = "امروز";

    public static readonly string RSA_KEY = "MyInstaAccIs@iCode4dotnet";
}
