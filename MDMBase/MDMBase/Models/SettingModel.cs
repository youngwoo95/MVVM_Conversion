namespace MDMBase.Models
{
    /// <summary>
    /// MDM SETTING MDDEL
    /// </summary>
    public class SettingModel
    {
        /// <summary>
        /// 데이터베이스 IP
        /// </summary>
        public string? DBIpAddress { get; set; } = String.Empty;

        /// <summary>
        /// 데이터베이스 PORT
        /// </summary>
        public string? DBPort { get; set; } = String.Empty;

        /// <summary>
        /// 데이터베이스 USER
        /// </summary>
        public string? DBUser { get; set; } = String.Empty;

        /// <summary>
        /// 데이터베이스 PASSWORD
        /// </summary>
        public string? DBPw { get; set; } = String.Empty;

        /// <summary>
        /// 데이터베이스 NAME
        /// </summary>
        public string? DBName { get; set; } = String.Empty;

        /// <summary>
        /// MDM URL 주소
        /// </summary>
        public string? Destination { get; set; } = String.Empty;
    }
}
