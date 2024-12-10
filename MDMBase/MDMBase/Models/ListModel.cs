using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace MDMBase.Models
{
    /// <summary>
    /// 리스트 모델
    /// </summary>
    public class ListModel : INotifyPropertyChanged
    {
        /* 전송시간 */
        private string? datetime;
        /* 사번 */
        private string? sabun;
        /* 전송결과 */
        private string? sendresult;

        /// <summary>
        /// 전송시간
        /// </summary>
        public string? DateTime 
        {
            get
            {
                return datetime;
            }
            set
            {
                datetime = value;
                OnPropertyChanged("DateTime");
            }
        }

        /// <summary>
        /// 사번
        /// </summary>
        public string? Sabun 
        {
            get
            {
                return sabun;
            }
            set
            {
                sabun = value;
                OnPropertyChanged("Sabun");
            } 
        }
        
        /// <summary>
        /// 전송결과
        /// </summary>
        public string? SendResult
        {
            get
            {
                return sendresult;
            }
            set
            {
                sendresult = value;
                OnPropertyChanged("SendResult");
            } 
        }

        public event PropertyChangedEventHandler? PropertyChanged;
        
        private void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

    }
}
