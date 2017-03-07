using System;
using System.IO;
using System.Linq;
using NUnit.Framework;
using Xamarin.UITest;
using Xamarin.UITest.Queries;
using System.Threading;

namespace MarshSupermarkets
{
	[TestFixture(Platform.Android)]
	[TestFixture(Platform.iOS)]
	public class Tests
	{
		IApp app;
		Platform platform;

		public Tests(Platform platform)
		{
			this.platform = platform;
		}

		[SetUp]
		public void BeforeEachTest()
		{
			app = AppInitializer.StartApp(platform);
		}

		[Test]
		public void Repl()
		{
			app.Repl();
		}

		[Test]
		public void FirstTest()
		{
			app.Tap("locate store");
			app.Screenshot("Tapped on 'Locate Store'");

			app.Tap(x => x.Class("android.widget.ImageButton").Index(2));
			app.Screenshot("Tapped on Search Button");

			app.EnterText("46204");
			app.Screenshot("Typed in my zip-code");

			app.Tap(x => x.Id("store_search_view"));
			app.Screenshot("Tapped on Store Seatch Button");

			app.DismissKeyboard();
			app.Screenshot("Dismissed Keyboard");
			Thread.Sleep(7000);

			app.Tap("Marsh");
			app.Screenshot("Selected my supermarket");

			app.Tap("continue");
			app.Screenshot("Tapped on 'Continue' Button");

			Thread.Sleep(2000);
			app.Tap("Digital Coupons");
			app.Screenshot("Tapped on 'Digital Coupons'");

			Thread.Sleep(2000);
			app.ScrollDown();
			app.Screenshot("Scrolling down to 'Olay'");

			app.Tap("Olay");
			app.Screenshot("Tapped on 'Olay'");

			app.Back();
			app.Screenshot("Tapped out of the 'Olay' Coupon");

			Thread.Sleep(2000);
			app.ScrollDown();
			app.Screenshot(	"Scrolling down to 'Depend'");

			app.Tap("DEPEND®");
			app.Screenshot("Tapped on 'Depend'");

			app.Back();
			app.Screenshot("Tapped out of the 'Depend' Coupon");

			Thread.Sleep(2000);
			app.ScrollDown();
			app.Screenshot("Scrolling down to 'Unstopables'");

			app.Tap("Unstopables");
			app.Screenshot("Tapped on 'Unstopables'");

			app.Back();
			app.Screenshot("Tapped out of the 'Unstopables' Coupon");

		}






	}
}
