using Client.DataService;
using Client.Models;
using Client.Views.Templates.CatalogTree;
using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.Input;

namespace Client.ViewsModels
{
    public partial class CatalogVM : BaseVM
    {
    
        public ObservableCollection<CatalogTreeModel> CatalogItems { get; set; }
        public CatalogVM()           
        {
            CatalogItems = new ObservableCollection<CatalogTreeModel>();
            LoadCatalog();
        }
     

        public async void LoadCatalog()
        {
           List<Category> categories = await CategoryService.categoryService.GetCategories();
           foreach(var item in categories)
            {
                CatalogTreeModel itemtoadd = new CatalogTreeModel();
                itemtoadd.CategoryInfo = item as Category;
               
                CatalogItems.Add(itemtoadd);
            }
        }

    }
}
