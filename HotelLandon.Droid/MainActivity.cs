using System;
using Android;
using Android.App;
using Android.OS;
using Android.Runtime;
using Android.Support.Design.Widget;
using Android.Support.V7.App;
using Android.Views;
using Android.Widget;

namespace HotelLandon.Droid
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme.NoActionBar", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            /* SetContentView(Resource.Layout.activity_main);

             Android.Support.V7.Widget.Toolbar toolbar = FindViewById<Android.Support.V7.Widget.Toolbar>(Resource.Id.toolbar);
             SetSupportActionBar(toolbar);

             FloatingActionButton fab = FindViewById<FloatingActionButton>(Resource.Id.fab);
             fab.Click += FabOnClick;
             */
            Button button = new Button(this)
            {
                Text = "Hello World"
            };
            this.AddContentView(button, new Android.Views.ViewGroup.LayoutParams(600,200)); // 300 dpi 50dpi
            button.Click += Button_Click;

            if ((int)Build.VERSION.SdkInt >= 23)
            {
                if (CheckSelfPermission(Manifest.Permission.Internet)
                    != Android.Content.PM.Permission.Denied)
                {
                    RequestPermissions(new string[]
                    {
                        Manifest.Permission.Internet
                    },0);
                    Toast.MakeText(this, "Permission accordée oar l'utilisateur",ToastLength.Short).Show();
                }
                else
                {
                    Toast.MakeText(this, "Permission déjà accordée", ToastLength.Long).Show();
                }
            }
        }

        private void Button_Click(object sender, EventArgs e)
        {
            var clickedButton = (Button)sender;
            clickedButton.Text += "!";
        }

        public override bool OnCreateOptionsMenu(IMenu menu)
        {
            MenuInflater.Inflate(Resource.Menu.menu_main, menu);
            return true;
        }

        public override bool OnOptionsItemSelected(IMenuItem item)
        {
            int id = item.ItemId;
            if (id == Resource.Id.action_settings)
            {
                return true;
            }

            return base.OnOptionsItemSelected(item);
        }

        private void FabOnClick(object sender, EventArgs eventArgs)
        {
            View view = (View) sender;
            Snackbar.Make(view, "Replace with your own action", Snackbar.LengthLong)
                .SetAction("Action", (Android.Views.View.IOnClickListener)null).Show();
        }
        /*
         * appelé lorsque l'activité devient visible pour l'utilisateur 
         */
        protected override void OnStart()
        {
            base.OnStart();
        }
        /*
         *  appelé lorsque l'activité commence à manipuler votre activité
         */
        protected override void OnResume()
        {
            base.OnResume();
        }
        /*
         *  Ensuite, lorsque l'utilisateur aura cessé d'interagir avec votre activité, 
         *  aucune autre activité ne prend le dessus, la méthode OnStart est appelée
         * 
         */
        protected override void OnPause()
        {
            base.OnPause();
        }
        /**
         * quand l'activité n'est plus du tout visible
         * aucun traitement ne peut etre fait
         */
        protected override void OnStop()
        {
            base.OnStop();
        }
        /*
         * Si le système a besoin de libérer de la mémoire, le système va appeler la méthode OnDestroy. 
         * A ce moment-là, l'activité sera totalement détruite, de cette manière, elle ne sera plus récupérable. 
         */
        protected override void OnDestroy()
        {
            base.OnDestroy();
        }
        /*
         * si l'activité n'est pas detruit on peut redemarrer l'activité
         */
        protected override void OnRestart()
        {
            base.OnRestart();
        }

    }
}

