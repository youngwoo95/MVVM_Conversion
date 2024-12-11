using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using Microsoft.Xaml.Behaviors;

namespace MDMBase.Helpers
{
    public class PasswordBoxBehavior : Behavior<PasswordBox>
    {
        public static readonly DependencyProperty BoundPasswordProperty =
           DependencyProperty.Register(
               "BoundPassword",
               typeof(string),
               typeof(PasswordBoxBehavior),
               new PropertyMetadata(string.Empty, OnBoundPasswordChanged));

        public string BoundPassword
        {
            get => (string)GetValue(BoundPasswordProperty);
            set => SetValue(BoundPasswordProperty, value);
        }

        protected override void OnAttached()
        {
            base.OnAttached();
            AssociatedObject.PasswordChanged += OnPasswordChanged;
        }

        protected override void OnDetaching()
        {
            base.OnDetaching();
            AssociatedObject.PasswordChanged -= OnPasswordChanged;
        }

        private void OnPasswordChanged(object sender, RoutedEventArgs e)
        {
            if (AssociatedObject.Password != BoundPassword)
            {
                BoundPassword = AssociatedObject.Password;

                // PropertyChanged 알림을 강제로 발생시켜 ViewModel 업데이트
                var binding = BindingOperations.GetBindingExpression(this, BoundPasswordProperty);
                binding?.UpdateSource();
            }
        }

        private static void OnBoundPasswordChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (d is PasswordBoxBehavior behavior && behavior.AssociatedObject != null)
            {
                var passwordBox = behavior.AssociatedObject;

                // PasswordBox.Password가 BoundPassword 값과 다르면 업데이트
                if (passwordBox.Password != (string)e.NewValue)
                {
                    passwordBox.PasswordChanged -= behavior.OnPasswordChanged; // 이벤트 중첩 방지
                    passwordBox.Password = (string)e.NewValue;
                    passwordBox.PasswordChanged += behavior.OnPasswordChanged;
                }
            }
        }
    }
}
