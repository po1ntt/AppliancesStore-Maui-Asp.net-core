using Client.DataService;
using Client.Models;
using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client.Views.Templates.CatalogTree
{
    public partial class CatalogTreeModel : ObservableObject
    {
        public int Rotation => IsVisible ? 270 : 90;

        [ObservableProperty]
        [NotifyPropertyChangedFor(nameof(Rotation))]
        private bool isVisible;
        public Category CategoryInfo { get; set; }
        [ObservableProperty]
        private ObservableCollection<Subcategory> childsElements;

        public Byte[] imgByteSourse { get; set; }  = new Byte[Byte.MaxValue]; 
       

        public CatalogTreeModel()
        {
        }
      
        [CommunityToolkit.Mvvm.Input.RelayCommand]
        private void OpenData(CatalogTreeModel catalogTree)
        {
            catalogTree.ChildsElements = new ObservableCollection<Subcategory>();
            catalogTree.IsVisible = !catalogTree.IsVisible;
            foreach(var item in catalogTree.CategoryInfo.subcategories)
            {
               catalogTree.ChildsElements.Add(item);
            }
           
        }
        private async void LoadImage()
        {
            imgByteSourse = await ImageService.imageService.GetImageByte(CategoryInfo.categoryImage);

        }
        [CommunityToolkit.Mvvm.Input.RelayCommand]
        private async Task gotoProducts(Subcategory subcategory)
        {
            await Shell.Current.DisplayAlert("Проверка", subcategory.nameSubCategory, "Ок");
        }

    }
}
