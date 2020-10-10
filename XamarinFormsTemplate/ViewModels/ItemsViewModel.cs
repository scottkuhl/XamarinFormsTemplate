﻿using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;

using Xamarin.Forms;

using XamarinFormsTemplate.Models;
using XamarinFormsTemplate.Views;

namespace XamarinFormsTemplate.ViewModels
{
    public class ItemsViewModel : BaseViewModel
    {
        private bool _addItemCommandFired = false;
        private Item _selectedItem;

        public ItemsViewModel()
        {
            Title = "Browse";
            Items = new ObservableCollection<Item>();
            LoadItemsCommand = new Command(async () => await ExecuteLoadItemsCommand());

            ItemTapped = new Command<Item>(OnItemSelected);

            AddItemCommand = new Command(OnAddItem);
        }

        public Command AddItemCommand { get; }
        public ObservableCollection<Item> Items { get; }
        public Command<Item> ItemTapped { get; }
        public Command LoadItemsCommand { get; }

        public Item SelectedItem
        {
            get => _selectedItem;
            set
            {
                SetProperty(ref _selectedItem, value);
                OnItemSelected(value);
            }
        }

        public void OnAppearing()
        {
            IsBusy = true;
            SelectedItem = null;
        }

        private async Task ExecuteLoadItemsCommand()
        {
            IsBusy = true;

            try
            {
                Items.Clear();
                var items = await DataStore.GetItemsAsync(true);
                foreach (var item in items)
                {
                    Items.Add(item);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
            finally
            {
                IsBusy = false;
            }
        }

        private async void OnAddItem(object obj)
        {
            // HACK: https://github.com/xamarin/Xamarin.Forms/issues/10136
            if (!_addItemCommandFired)
            {
                await Shell.Current.GoToAsync(nameof(NewItemPage));
                _addItemCommandFired = true;
            }
        }

        private async void OnItemSelected(Item item)
        {
            if (item == null)
            {
                return;
            }

            // This will push the ItemDetailPage onto the navigation stack
            await Shell.Current.GoToAsync($"{nameof(ItemDetailPage)}?{nameof(ItemDetailViewModel.ItemId)}={item.Id}");
        }
    }
}