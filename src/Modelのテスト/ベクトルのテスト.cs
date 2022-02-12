using NUnit.Framework;

namespace RedRing.Model.Test
{
    [TestFixture]
    [System.Obsolete]
    public class ベクトルのテスト : AssertionHelper
    {
        ベクトル テスト対象;
        string 変更済みプロパティ名;

        [SetUp]
        public void SetUp()
        {
            テスト対象 = new ベクトル(0, 0, 0);
            変更済みプロパティ名 = null;

            テスト対象.PropertyChanged +=
            (sender, e) =>
            {
                変更済みプロパティ名 = e.PropertyName;
            };
        }

        [Test]
        public void Xに値を設定できます()
        {
            テスト対象.X = 1.0;

            Expect(テスト対象.X, Is.EqualTo(1.0));
        }

        [Test]
        public void Xの変更は通知されます()
        {
            テスト対象.X = 1.0;

            Expect(変更済みプロパティ名, Is.EqualTo("X"));
        }

        [Test]
        public void Yに値を設定できます()
        {
            テスト対象.Y = 1.0;

            Expect(テスト対象.Y, Is.EqualTo(1.0));
        }

        [Test]
        public void Yの変更は通知されます()
        {
            テスト対象.Y = 1.0;

            Expect(変更済みプロパティ名, Is.EqualTo("Y"));
        }

        [Test]
        public void Zに値を設定できます()
        {
            テスト対象.Z = 1.0;

            Expect(テスト対象.Z, Is.EqualTo(1.0));
        }

        [Test]
        public void Zの変更は通知されます()
        {
            テスト対象.Z = 1.0;

            Expect(変更済みプロパティ名, Is.EqualTo("Z"));
        }

        [Test]
        public void 足し算ができます()
        {
            テスト対象.X = 1.0;
            テスト対象.Y = 2.0;
            テスト対象.Z = 3.0;

            Expect((テスト対象 + テスト対象).X, Is.EqualTo(2.0));
            Expect((テスト対象 + テスト対象).Y, Is.EqualTo(4.0));
            Expect((テスト対象 + テスト対象).Z, Is.EqualTo(6.0));
        }
    }
}
