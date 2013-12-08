using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestaurantOrderingSystem;

namespace RestaurantOrderingSystem.UI
{
    public class MenuCategory : ViewModelBase
    {
        //adding list of items to ComboBox selection
        public ObservableCollection<Dessert> MenuList {get;set;}
        public Dessert selectedItem;

        public MenuCategory()
        {
            this.MenuList = new ObservableCollection<Dessert>();
            Dessert currentDesert = new Dessert() { Name="Cake", DessertType=DessertType.Cake, Quantity=1, ItemDescription="Dessert", Price=5};//TODO problem with decimal usage need Fix!!
            Dessert currentDesert2 = new Dessert() { Name = "Fruit", DessertType = DessertType.Fruit, Quantity = 1, ItemDescription = "Dessert", Price = 3};
            Dessert currentDesert3 = new Dessert() { Name = "IceCream", DessertType = DessertType.IceCream, Quantity = 1, ItemDescription = "Dessert", Price = 2};
            MenuList.Add(currentDesert);
            MenuList.Add(currentDesert2);
            MenuList.Add(currentDesert3);
        }

        public Dessert PSelectedItem
        {
            get
            {
                return this.selectedItem;
            }
            set
            {
                this.selectedItem = value;
                OnPropertyChanged("PSelectedItem");
            }
        }
    }
}
