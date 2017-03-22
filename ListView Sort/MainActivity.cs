using System;
using Android.App;
using Android.Widget;
using Android.OS;

namespace ListView_Sort
{
    [Activity(Label = "ListView Sort", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {
        //VIEWS
        private ListView lv;
        private Button sortBtn;


        //DATA
        private readonly string[] spacecrafts = { "Kepler", "Casini", "Voyager", "New Horizon", "James Web", "Apollo 15", "Enterprise", "WMAP", "Spitzer", "Galileo" };
        private bool ascending = true;

        //CALLED WHEN ACTIVITY IS CREATED
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);
            this.InitializeViews();
            this.SortData(ascending);
            this.ascending = !ascending;

            sortBtn.Click += sortBtn_Click;

        }

        //SORT BUTTON CLICKED
        void sortBtn_Click(object sender, EventArgs e)
        {
            SortData(ascending);
            this.ascending = !ascending;
        }

        //INITIALIZE VIEWS
        private void InitializeViews()
        {
            lv = FindViewById<ListView>(Resource.Id.lv);
            sortBtn = FindViewById<Button>(Resource.Id.sortBtn);
        }

        //POPULATE Listview
        private void Populate()
        {
            lv.Adapter = new ArrayAdapter(this, Android.Resource.Layout.SimpleListItem1, spacecrafts);
        }

        /*
         * SORT
         */
        private void SortData(bool asc)
        {
            //SORT ARRAY ASCENDING AND DESCENDING
            if (asc)
            {
                Array.Sort(spacecrafts);
            }
            else
            {
                Array.Reverse(spacecrafts);
            }

            //CLEAR AND POPULATE LISTBOX
            Populate();

        }
    }

}


