using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using LunarBase.WebData.Models;
using LunarBase.WebData;

namespace LunarBase.WebApp
{
    public partial class Install : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            var resources = new ObservableCollection<Resource>();
            resources.Add(new Resource()
                {
                    Name = "Gold",
                });
            resources.Add(new Resource()
                {
                    Name = "Aluminium",
                });
            resources.Add(new Resource()
                {
                    Name = "Helium-3",
                });
            resources.ForEach(r => MongoHelpers.SaveData(r));


            var buildings = new ObservableCollection<Building>();
            for (var i = 0; i < 3; i++)
            {
                var b = new Building();
                b.Name = "name" + i;
                b.Resources = new ObservableCollection<ResourceInBuilding>()
                    {
                        new ResourceInBuilding(){ ResourceId = resources[i].Id, ProducePerTurn = 0, UsefullType = UsefullTypes.ForBuilding }
                    };
                b.BuildsRequested = i*12;
                b.BuildsCompleted = 0;
                buildings.Add(b);
            }

            buildings.ForEach(b => MongoHelpers.SaveData(b));
        }
    }
}