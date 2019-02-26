namespace Caixa.Classes
{
    static class Backup
    {
        static string localBackup, dataBackup;

        public static string DataBackup
        {
            get { return dataBackup; }
            set { dataBackup = value; }
        }
        public static string LocalBackup
        {
            get { return localBackup; }
            set { localBackup = value; }
        }
    }
}
