using GalaSoft.MvvmLight;

namespace RedRing.Model
{
    public class カメラ : ObservableObject
    {
        public カメラ()
        {
            位置 = new 位置ベクトル(5, 5, 5);
            方向 = new ベクトル(-1, -1, -1);

            位置.PropertyChanged +=
                (sender, e) =>
            {
                RaisePropertyChanged(() => 位置);
            };

            方向.PropertyChanged +=
    (sender, e) =>
            {
                RaisePropertyChanged(() => 方向);
            };
        }

        public 位置ベクトル 位置 { get; set; }
        public ベクトル 方向 { get; set; }
    }
}
