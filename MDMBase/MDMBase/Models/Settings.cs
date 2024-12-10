namespace MDMBase.Models
{
    /// <summary>
    /// MDM SETTING MDDEL
    /// </summary>
    public class Settings
    {
        /// <summary>
        /// 데이터베이스 IP
        /// </summary>
        public string? DBIpAddress { get; set; }

        /// <summary>
        /// 데이터베이스 PORT
        /// </summary>
        public string? DBPort { get; set; }

        /// <summary>
        /// 데이터베이스 USER
        /// </summary>
        public string? DBUser { get; set; }

        /// <summary>
        /// 데이터베이스 PASSWORD
        /// </summary>
        public string? DBPw { get; set; }

        /// <summary>
        /// 데이터베이스 NAME
        /// </summary>
        public string? DBName { get; set; }

        /// <summary>
        /// MDM URL 주소
        /// </summary>
        public string? Destination { get; set; }
    }
}
